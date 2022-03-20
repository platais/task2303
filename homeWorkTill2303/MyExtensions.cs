namespace homeWorkTill2303
{
    public static class MyExtensions
    {
        public static dynamic MyAddOneToAnotherAttribute(this object o1, object o2)
        {
            var isO1AndO2String = o1.GetType() == typeof(string) && o2.GetType() == typeof(string);
            var isO1AndO2Int = o1.GetType() == typeof(int) && o2.GetType() == typeof(int);

            if (isO1AndO2String)
                return o1.ToString() + o2.ToString();
            if (isO1AndO2Int)
                return (int)o1 + (int)o2;

            if (o1.GetType() != o2.GetType())
                return "error, types youre adding didnt match, \n adding different types not supported";
            return "error, not supported types to add";
        }
    }
}
