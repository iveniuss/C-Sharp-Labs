

namespace ClassLibLab10
{
    public class TreeFamily
    {
        public string TreeName { get; set; }
        public string Family { get; set; }

        public TreeFamily(string name, string type)
        {
            TreeName = name;
            Family = type;
        }
    }
}
