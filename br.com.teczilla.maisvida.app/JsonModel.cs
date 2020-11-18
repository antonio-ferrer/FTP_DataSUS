using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.teczilla.teczftp.models
{
    public class Credentials
    {
        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("pwd")]
        public string Pwd { get; set; }
    }

    public class Exec
    {
        [JsonProperty("program")]
        public string Program { get; set; }

        [JsonProperty("params")]
        public string Params { get; set; }
    }

    public class Download
    {
        [JsonProperty("ftp")]
        public string Ftp { get; set; }

        [JsonProperty("directory")]
        public string Directory { get; set; }

        [JsonProperty("files")]
        public List<string> Files { get; set; }

        [JsonProperty("whenFinished")]
        public List<Exec> WhenFinished { get; set; }
    }

    public class JsonConfig
    {
        [JsonProperty("credentials")]
        public Credentials Credentials { get; set; }

        [JsonProperty("passive")]
        public bool? Passive { get; set; }

        [JsonProperty("downloads")]
        public List<Download> Downloads { get; set; }

        [JsonProperty("whenDone")]
        public List<Exec> WhenDone { get; set; }
    }


}
