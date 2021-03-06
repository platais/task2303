using System;
using System.Linq;

namespace homeWorkTill2303
{
    class Program
    {
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
            var inputArgument1 = "";
            var inputArgument2 = "";
            do
            {
                Console.WriteLine("Input first argument (can't be empty) and press Enter:");
                inputArgument1 = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(inputArgument1));

            do
            {
                Console.WriteLine("Input second argument (can't be empty) and press Enter:");
                inputArgument2 = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(inputArgument2));

            Console.WriteLine("\nAddition result (or error message):");
            Console.WriteLine(UtilityService.CheckInputShowAddition(inputArgument1, inputArgument2));

            var isSavedSuccessfully = UtilityService.FillSaveModelAndSaveInDb(inputArgument1, inputArgument2);
            var savedOrNotString = isSavedSuccessfully ? "saved successfully" : "not saved";
            Console.WriteLine($"Values {savedOrNotString}");



            var attributesModel = UtilityService.GetSavedAttributes();
            if (attributesModel.Any())
            {
                Console.WriteLine("\nAttributes that have been saved in db and their types:");
                foreach (var model in attributesModel)
                {
                    Console.WriteLine($"attribute: \"{model.Attribute}\", its type: \"{model.Type}\"");
                }
            }
            else
                Console.WriteLine("\nNo attributes to show, probably you dont have any saved.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
