using System;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace homeWorkTill2303
{
    public interface IDataRepo
    {
        IEnumerable<AttributesModel> GetAllParameterObjects();
        bool SaveParametersInDb(List<AttributesModel> modelList);
    }

    public class DataAccessRepository : IDataRepo
    {
        private readonly string connString = "Server=localhost;User id=sa;Password=Passw0rd!;TrustServerCertificate=true";

        public IEnumerable<AttributesModel> GetAllParameterObjects()
        {
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    return conn.Query<AttributesModel>("select * from taskAttributes");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Enumerable.Empty<AttributesModel>();
        }

        public bool SaveParametersInDb(List<AttributesModel> modelList)
        {
            var isSaved = false;
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    string processQuery = "INSERT INTO taskAttributes VALUES (@Attribute, @Type)";
                    if (conn.Execute(processQuery, modelList) > 0)
                        isSaved = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return isSaved;
        }
    }
}
