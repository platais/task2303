using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

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

        public static bool FillSaveModelAndSaveInDb(string parameter1, string parameter2)
        {
            return _dataRepo.SaveParametersInDb(new List<AttributesModel>() {
                new AttributesModel(JsonSerializer.Serialize(parameter1), parameter1.GetType().ToString()),
                new AttributesModel(JsonSerializer.Serialize(parameter2), parameter2.GetType().ToString())
            });
        }

        public static void CheckInputShowAddition(string parameter1, string parameter2)
        {
            var isInputArgument1Int = int.TryParse(parameter1, out int inputInt1);
            var isInputArgument2Int = int.TryParse(parameter2, out int inputInt2);

            if (isInputArgument1Int && isInputArgument2Int)
                DisplayAdditionOfTwoValidParameters(inputInt1, inputInt2);
            else
                DisplayAdditionOfTwoValidParameters(parameter1, parameter2);
        }

        public static IDataRepo GetIDataRepo()
        {
            return new DataAccessRepository(ConfigurationService.GetSettings());
        }
    }
}
