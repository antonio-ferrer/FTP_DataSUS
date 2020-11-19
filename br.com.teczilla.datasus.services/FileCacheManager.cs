using br.com.teczilla.lib.ftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace br.com.teczilla.datasus.services
{
    public static class FileCacheManager
    {
        /*
         <cache>
            <repository name="">
                <file name="dbsdsd" size="" date="">
                    <url>...</url>
                    <dir>...</dir>
                </file>
            </repository>
        <cache>
         */

        private static IEnumerable<IFTPFile> GetOutDatedFiles(
            DiscoverRepository repManager,
            string repositoryName,
            IEnumerable<IFTPFile> files)
        {
            var dir = repManager.GetRepositoryWorkingFolder(repositoryName);
            var cachePath = Path.Combine(dir, "cache-control.xml");
            if (!File.Exists(cachePath))
                return files;
            var rxXML = new Regex(@"\<\w+(\s\w+\=\"".+\"")*\>.*\<\/\w+\>");
            string strContent = File.ReadAllText(cachePath);
            if (!rxXML.IsMatch(strContent))
                return files;
            var xmlCache = XElement.Parse(strContent);
            var xmlRepository = xmlCache.Elements("repository")?
                .FirstOrDefault(x => x?.Attribute("name")?.Value?.ToLower() == repositoryName.ToLower());
            if (xmlRepository == null)
                return files;

            var cached = xmlRepository.Elements("file")
                .Select(f => new CachedFile(f))
                .Where(f => File.Exists(f.LocalPath));

            var hash = (from c in cached
                        join f in files
       on GetHashFile(c) equals GetHashFile(f)
                        select GetHashFile(c)).ToArray();

            var data =  files.Where(f => !hash.Contains(GetHashFile(f))).ToArray();
            return data;
        }

        private static void WriteCache(DiscoverRepository repManager, string repositoryName, IEnumerable<CachedFile> files)
        {
            var wkf = repManager.GetRepositoryWorkingFolder(repositoryName);
            var cachePath = Path.Combine(wkf, "cache-control.xml");
            if (!File.Exists(cachePath))
            {
                File.WriteAllText(cachePath, "<cache></cache>");
            }
            XElement xmlCache = XElement.Load(cachePath);
            XElement xmlRepository = xmlCache.Elements("repository").FirstOrDefault(r => r?.Attribute("name")?.Value.ToLower() == repositoryName.ToLower());
            if (xmlRepository == null)
            {
                xmlRepository = new XElement("repository", new XAttribute("name", repositoryName));
                xmlCache.Add(xmlRepository);
            }
            var urlFiles = files.Select(f => f.URL.ToLower()).Distinct().ToArray();
            var xmlFilesToRemove = xmlRepository?.Elements("file")?.
                Where(f => urlFiles.Contains(f?.Element("url")?.Value?.ToLower() ?? ""));
            if (xmlFilesToRemove?.Any() == true)
            {
                foreach (var node in xmlFilesToRemove)
                    node.Remove();
            }
            foreach (var f in files)
                xmlRepository.Add(XElement.Parse(f.ToXML()));
            File.WriteAllText(cachePath, xmlCache.ToString());
        }

        public static IEnumerable<CachedFile> DownloadCache(this DiscoverRepository rep, string repositoryName, DiscoveredRepositoryCache target, IEnumerable<IFTPFile> files)
        {
            var wk = rep.GetRepositoryWorkingFolder(repositoryName, target);
            var outDatedFiles = GetOutDatedFiles(rep, repositoryName, files);
            
            var cachedFiles = files.Select(f => new CachedFile(XElement.Parse(ToXMLCache(f, Path.Combine(wk, f.Name))))).ToArray();
            if ((outDatedFiles?.Count() ?? 0) == 0)
                return cachedFiles;
            outDatedFiles = outDatedFiles.Select(f => (IFTPFile)new CachedFile(XElement.Parse(ToXMLCache(f, Path.Combine(wk, f.Name)))));
            if(rep.Download(repositoryName, target, outDatedFiles))
            {
                WriteCache(rep, repositoryName, cachedFiles);
            }
            return cachedFiles;
        }

        public static IEnumerable<FileInfo> CopyCacheTo(this DiscoverRepository rep, IEnumerable<CachedFile> cachedFiles, string directory)
        {
            List<FileInfo> files = new List<FileInfo>();
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            foreach (var f in cachedFiles)
            {
                FileInfo file = new FileInfo(Path.Combine(directory, f.Name));
                File.Copy(f.LocalPath, file.FullName, true);
                files.Add(file);
            }
            return files;
        }

        private static string GetHashFile(IFTPFile file)
        {
            return CachedFile.GetHashFile(file);
        }

        private static string GetHashFileCode(IFTPFile file)
        {
            return CachedFile.GetHashFileCode(file);
        }

        private static string ToXMLCache(IFTPFile file, string localPath)
        {
            XElement xmlFile = XElement.Parse(file.ToXML());
            xmlFile.Add(new XElement("local-path", new XCData(localPath)));
            return xmlFile.ToString();
        }


    }
}
