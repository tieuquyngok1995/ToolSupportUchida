using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSupportUchida.Model
{
    public class AdapterModel
    {
        public string type { get; set; }

        public string key { get; set; }

        public string value { get; set; }

        public AdapterModel()
        {
        }

        public AdapterModel(string type, string key, string value)
        {
            this.type = type;
            this.key = key;
            this.value = value;
        }
    }
}
