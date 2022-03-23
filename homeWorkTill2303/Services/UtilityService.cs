using System;
using System.Collections.Generic;
using System.Text.Json;
using homeWorkTill2303.Services;

namespace homeWorkTill2303
{
    public class UtilityService
    {
        private static IDataRepo _dataRepo = GetIDataRepo();

        public static string DisplayAdditionOfTwoValidParameters<T, T1>(T param1, T1 param2)
        {
            return Convert.ToString(param1.AddOneToAnother(param2));
        }

        public static IEnumerable<AttributesModel> GetSavedAttributes()
        {
            return _dataRepo.GetAllParameterObjects();
        }

        public static bool FillSaveModelAndSaveInDb<T, T1>(T parameter1, T1 parameter2)
        {
            return _dataRepo.SaveParametersInDb(new List<AttributesModel>() {
                new AttributesModel(JsonSerializer.Serialize(parameter1), parameter1.GetType().ToString()),
                new AttributesModel(JsonSerializer.Serialize(parameter2), parameter2.GetType().ToString())
            });
        }

        public static string CheckInputShowAddition(string parameter1, string parameter2)
        {
            var isBothParametersInt = CheckIfBothInputIntAndGetValues(parameter1, parameter2, out int parameterInt1, out int parameterInt2);
            if (isBothParametersInt)
                return DisplayAdditionOfTwoValidParameters(parameterInt1, parameterInt2);
            else
                return DisplayAdditionOfTwoValidParameters(parameter1, parameter2);
        }

        public static bool CheckIfBothInputIntAndGetValues(string parameter1, string parameter2, out int outIntOne, out int outIntTwo)
        {
            var isFirstInt = int.TryParse(parameter1, out int outInt1);
            outIntOne = outInt1;
            var isSecondInt = int.TryParse(parameter2, out int outInt2);
            outIntTwo = outInt2;
            return isFirstInt && isSecondInt;
        }

        public static IDataRepo GetIDataRepo()
        {
            return new DataAccessRepository(ConfigurationService.GetSettings(), LoggerService.GetLogger());
        }
    }
}
