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
        private readonly Settings _settings;

        public DataAccessRepository(Settings settings)
        {
            _settings = settings;
        }

        public IEnumerable<AttributesModel> GetAllParameterObjects()
        {
            try
            {
                using (var conn = new SqlConnection(_settings.ConnectionStrings.DefaultConnection))
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
                using (var conn = new SqlConnection(_settings.ConnectionStrings.DefaultConnection))
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
