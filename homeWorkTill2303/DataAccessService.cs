namespace homeWorkTill2303
{
    public class DataAccessService
    {
        public static IDataRepo GetIDataRepo()
        {
            return new DataAccessRepository();
        }
    }
}
