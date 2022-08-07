using System;
using System.Collections.Generic;

namespace ToolSupportCoding.Model
{
    [Serializable]
    public class ToolSupportModel
    {
        public List<SekkeiModel> lstSekkei { get; set; }

        public List<ItemModel> lstItem { get; set; }

        public int modeLanguage { get; set; }
    }
}
