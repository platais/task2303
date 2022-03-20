namespace homeWorkTill2303
{
    public class AttributesModel
    {
        public int Id { get; set; }
        public string Attribute { get; set; }
        public string Type { get; set; }

        public AttributesModel()
        {
        }

        public AttributesModel(string attribute, string type)
        {
            Attribute = attribute;
            Type = type;
        }
    }
}
