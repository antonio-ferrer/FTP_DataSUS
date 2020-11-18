using br.com.teczilla.teczftp.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace br.com.teczilla.teczftp
{
    public static class JsonConfigReader
    {
        public static JsonConfig Read()
        {
            string configJs = Environment.GetCommandLineArgs().FirstOrDefault() ?? "todo.js";
            if (!System.IO.File.Exists(configJs))
            {
                throw new Exception("arquivo de configuração não encontrado!");
            }
            string config = System.IO.File.ReadAllText(configJs);
            JsonConfig myDeserializedClass = JsonConvert.DeserializeObject<JsonConfig>(config);
            return myDeserializedClass;
        }
    }
}
