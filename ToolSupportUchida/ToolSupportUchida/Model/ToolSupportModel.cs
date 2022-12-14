using System;
using System.Collections.Generic;
using ToolCommon.Models;

namespace ToolSupportCoding.Model
{
    [Serializable]
    public class ToolSupportModel
    {
        public List<SekkeiModel> lstSekkei { get; set; }

        public List<ItemModel> lstItem { get; set; }

        public int modeLanguage { get; set; }

        public AppSettingModel appSettingModel { get; set; }
    }
}
