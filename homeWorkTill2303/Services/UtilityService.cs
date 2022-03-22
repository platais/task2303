using System;
using System.Collections.Generic;
using System.Text.Json;

namespace homeWorkTill2303
{
    public class UtilityService
    {
        private static IDataRepo _dataRepo = GetIDataRepo();

        public static void DisplayAdditionOfTwoValidParameters<T, T1>(T param1, T1 param2)
        {
            Console.WriteLine("\nAddition result (or error message):");
            Console.WriteLine(param1.AddOneToAnother(param2));
        }

        public static void GetAndPrintSavedAttributes()
        {
            var allAttributeModelsSavedInDb = _dataRepo.GetAllParameterObjects();
            Console.WriteLine("\nAttributes that have been saved in db and their types:");
            foreach (var model in allAttributeModelsSavedInDb)
            {
                Console.WriteLine($"attribute: \"{model.Attribute}\", its type: \"{model.Type}\"");
            }
        }

        public static bool FillSaveModelAndSaveInDb<T, T1>(T parameter1, T1 parameter2)
        {
            return _dataRepo.SaveParametersInDb(new List<AttributesModel>() {
                new AttributesModel(JsonSerializer.Serialize(parameter1), parameter1.GetType().ToString()),
                new AttributesModel(JsonSerializer.Serialize(parameter2), parameter2.GetType().ToString())
            });
        }

        public static void CheckInputShowAddition(string parameter1, string parameter2)
        {
            var isBothParametersInt = CheckIfBothInputIntAndGetValues(parameter1, parameter2, out int parameterInt1, out int parameterInt2);
            if (isBothParametersInt)
                DisplayAdditionOfTwoValidParameters(parameterInt1, parameterInt2);
            else
                DisplayAdditionOfTwoValidParameters(parameter1, parameter2);
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
            return new DataAccessRepository(ConfigurationService.GetSettings());
        }
    }
}
