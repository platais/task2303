using System;
using System.Collections.Generic;
using System.Text.Json;

namespace homeWorkTill2303
{
    class Program
    {
        private static IDataRepo _dataRepo = DataAccessService.GetIDataRepo();

        static void Main()
        {
            Console.WriteLine("This console application will ask you to input two arguments." +
                "\nPlease input both as text or both as whole number (integer)" +
                "\nText will be added together, whole numbers will be counted together." +
                "\nFloats, decimals, etc will be handled as strings." +
                "\nYour input will be logged in db (in case of successfull connection)." +
                "\nPress any key on your keyboard to continue, " +
                "\n if you cant find ANY key, press Space bar on your keyboard.");
            Console.ReadKey();
            Console.WriteLine("Input first argument and press Enter:");
            var inputArgument1 = Console.ReadLine();
            Console.WriteLine("Input second argument and press Enter:");
            var inputArgument2 = Console.ReadLine();

            var isInputArgument1Int = int.TryParse(inputArgument1, out int inputInt1);
            var isInputArgument2Int = int.TryParse(inputArgument2, out int inputInt2);

            if (isInputArgument1Int && isInputArgument2Int)
                DisplayAdditionOfTwoValidParameters(inputInt1, inputInt2);
            else
                DisplayAdditionOfTwoValidParameters(inputArgument1, inputArgument2);

            var isSavedSuccessfully = _dataRepo.SaveParametersInDb(new List<AttributesModel>() {
                new AttributesModel(JsonSerializer.Serialize(inputArgument1), inputArgument1.GetType().ToString()),
                new AttributesModel(JsonSerializer.Serialize(inputArgument2), inputArgument2.GetType().ToString())
            });
            var savedOrNotString = isSavedSuccessfully ? "saved successfully" : "not saved";
            Console.WriteLine($"Values {savedOrNotString}");

            GetAndPrintSavedAttributes();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void DisplayAdditionOfTwoValidParameters<T, T1>(T param1, T1 param2)
        {
            Console.WriteLine("\nAddition result (or error message):");
            Console.WriteLine(param1.MyAddOneToAnotherAttribute(param2));
        }

        private static void GetAndPrintSavedAttributes()
        {
            var allAttributeModelsSavedInDb = _dataRepo.GetAllParameterObjects();
            Console.WriteLine("\nAttributes that have been saved in db and their types:");
            foreach (var model in allAttributeModelsSavedInDb)
            {
                Console.WriteLine($"attribute: \"{model.Attribute}\", its type: \"{model.Type}\"");
            }
        }
    }
}
