# task2303
happyAttributes

## Usage

Simple console application that will ask you to input two arguments, 
depending on argument type it will try to add them or will give you an error.
- String type argements will be added together like text, int arguments will be summed. 
- Float-like (float, decimal, etc) arguments are not supported so they will be added together like strings.
- Mixed will be counted as string.
Result will be shown on the screen.
You should connect it to your database and make a table there, just replace connection string with yours in appsettings.json file
Query to make this table:

>CREATE TABLE [dbo].[taskAttributes](
> [id] [int] IDENTITY(1,1) NOT NULL,
> [attribute] [nvarchar](max) NOT NULL,
> [type] [varchar](100) NULL)

Attributes will be saved to database as strings. 
All attributes that has been inputted will be printed to screen.

## Known issues

As at the begining I wasnt sure about input attribute types so I started to overdone this task by designing functions that 
may take different type of attributes, etc, like there was a chance to load them from json, etc :)
- float like numbers are not supported as numbers and added like strings
- by design it suppose to save also types, but currently its saving all as string as currently function receive parameters as string.
- ?

## Design

- Main funcion mostly holds UI and some main function calls
- All "business logic" is inside UtilityService.
- Core db functions that has been used is inside DataAccessRepository.
- As we are using db connection, Ive added an option to save connection string in appsettings.json file
 as it was a very bad practice to leave it in code.
- For reading and writing from db Dapper was used as its not only fast but supports different useful features.
- Db is safe against injection because these values when given as dictionary (dictionary key-value) or from model -  
dapper firstly defines them as variables, so you may insert even the db queries as strings without any fear.
- There is one extension function - AddOneToAnother that may receive two objects, this function is checking the types 
and is able to sum ints and add strings along it may give error if types dont match or not supported at all, 
of course we dont use the fully it in the current implimentation. 
- There is another project with several xUnit Tests to check if this function works as expected.
- Tried to organize everything as seperated as I could so that its easier to update / extend this application 

## Screenshot

![Screenshot 2022-03-22 at 00 16 48](https://user-images.githubusercontent.com/7956231/159386784-54066aa8-a812-43c2-ad72-8b19d34a60bd.png)



