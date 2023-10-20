using System;

namespace ToolSupportCoding.Model
{
    [Serializable]
    public class ItemModel
    {
        public string name { get; set; }

        public string key { get; set; }

        public string value { get; set; }

        public ItemModel()
        {
        }

        public ItemModel(string name, string key, string value)
        {
            this.name = name;
            this.key = key;
            this.value = value;
        }
    }
}
