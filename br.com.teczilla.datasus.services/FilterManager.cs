using br.com.teczilla.lib.ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace br.com.teczilla.datasus.services
{
    public static class FilterManager
    {
        private static string getNumber(int val)
        {
            return new string(("0" + val).Reverse().Take(2).Reverse().ToArray());
        }

        private static int getYear(string value)
        {
            int v = int.Parse(value);
            if (v > 99)
                throw new ArgumentOutOfRangeException();
            v += 1900;
            int year = int.Parse(DateTime.Now.ToString("yy"));
            if (v <= year + 1900)
                v += 100;
            return v;
        }

        public static RepositoryFilter ReverseFilter<F>(this IEnumerable<F> files) where F : IFTPFile
        {
            // uf ano mes
            Regex regFilter = new Regex(@"^(?<nome>[a-z]+)(?<uf>[a-z]{2})(?<ano>\d{2})(?<mes>\d{2})?\.\w{2,3}$", RegexOptions.IgnoreCase);
            var matches = files.Select(f => new FilteredItem (f.Name.ToUpper(), regFilter.Match(f.Name)) ).ToArray();

            var filter =  new RepositoryFilter();

            filter.Unmatched = matches.Where(m => !m.Match.Success).Select(m => m.Name).ToArray();
            matches = matches.Where(m => m.Match.Success).ToArray();
            int[] ivalues = matches.Where(m=>m.Match.Groups["mes"].Success).Select(m => int.Parse(m.Match.Groups["mes"].Value)).Distinct().ToArray();
            Array.Sort(ivalues);
            filter.Months = ivalues;

            ivalues = matches.Select(m => getYear(m.Match.Groups["ano"].Value)).Distinct().ToArray();
            //Array.Sort(ivalues);
            filter.MinYear = ivalues.Min();
            filter.MaxYear = ivalues.Max();

            string[] svalues = matches.Select(m => m.Match.Groups["nome"].Value.ToUpper()).Distinct().ToArray();
            Array.Sort(svalues);
            filter.Prefixes = svalues;

            svalues = matches.Select(m => m.Match.Groups["uf"].Value.ToUpper()).Distinct().ToArray();
            Array.Sort(svalues);
            filter.UFs = svalues;

            filter.FilteredItems = matches;

            return filter;

        }
        
        public static IEnumerable<F> ApplyFilter<F>(this IEnumerable<F> files, RepositoryFilter filter) where F : IFTPFile
        {
            if (filter == null || files == null || files.Count() == 0 )
                return files;

            var names = files.Select(f => f.Name);
            string pattern = "";

            
            if(filter.Prefixes?.Any() == true)
            {
                pattern += "(" + string.Join("|", filter.Prefixes) + ")";
            }
            else
            {
                pattern += "([a-z]+)";
            }

            // uf ano mes

            if(filter.UFs?.Any() == true)
            {
                pattern += "(" + string.Join("|", filter.UFs) + ")";
            }
            else
            {
                pattern += "([a-z]{2})";
            }

            if(filter.GetYears()?.Any() == true)
            {
                pattern += "(" + string.Join("|", filter.GetYears().Select(y => getNumber(y)).ToArray()) + ")";
            }
            else
            {
                pattern += @"(\d{2})";
            }

            if(filter.Months?.Any() == true)
            {
                pattern += "(" + string.Join("|", filter.Months.Select(m => getNumber(m)).ToArray()) + ")";
            }
            else
            {
                pattern += @"(\d{2})?";
            }
            pattern = "^" + pattern + @"\.\w{2,3}$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            names = names.Where(n => regex.IsMatch(n)).ToArray();
            return (from f in files join n in names on f.Name equals n select f).ToArray();
        }

    }
}
