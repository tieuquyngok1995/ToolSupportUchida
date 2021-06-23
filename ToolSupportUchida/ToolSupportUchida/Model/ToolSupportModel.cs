using System;
using System.Collections.Generic;

namespace ToolSupportUchida.Model
{
    [Serializable]
    public class ToolSupportModel
    {
        public List<SekkeiModel> lstSekkei { get; set; }

        public List<AdapterModel> lstAdapter { get; set; }
    }
}
