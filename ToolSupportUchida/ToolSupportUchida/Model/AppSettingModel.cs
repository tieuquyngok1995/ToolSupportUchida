using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolCommon.Models
{
    [Serializable]
    public class AppSettingModel
    {
        public string sourcePath { get; set; }

        public GenerateSource generateSource { get; set; }

        public List<EditSource> editSource { get; set; }
    }

    public class GenerateSource
    {
        public string[] ignoreFile { get; set; }
    }

    public class EditSource
    {
        public string fileType { get; set; }

        public string functionPattern { get; set; }

        public string functionKeyword { get; set; }
    }
}
