
namespace ToolSupportCoding.Model
{
    public class ViewModel
    {
        public string name { get; set; }

        public string type { get; set; }

       public ViewModel(string _name, string _type) {
            name = _name;
            type = _type;  
        }
    }
}
