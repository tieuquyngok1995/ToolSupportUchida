using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolSupportCoding.Model
{
    [Serializable]
    public class SekkeiModel
    {
        public string logicName { get; set; }

        public string physiName { get; set; }

        public SekkeiModel(string logicName, string physiName)
        {
            this.logicName = logicName;
            this.physiName = physiName;
        }
    }
}
