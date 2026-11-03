// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;

string currentDirectory = Directory.GetCurrentDirectory();

string[] subDirectoriesNivel1 = Directory.GetDirectories(currentDirectory);

string header = ""+ "========================================================================\n" +
    "Utility for quickly deleting 'bin' and 'obj' folders for .NET projects\n\n" +
    "Deletes all 'bin' and 'obj' folders at any level starting from the current directory.\n" +
    "========================================================================\n";

const string orientationBaseConfirmCancel = "Please press Y to confirm, or N to cancel";
Console.WriteLine(header);
Console.WriteLine($"Current directory: {currentDirectory}");
Console.WriteLine(orientationBaseConfirmCancel);
char userInput;
do
{
    userInput = Console.ReadKey().KeyChar;
    userInput = char.ToUpper(userInput);
    if(userInput != 'Y' && userInput != 'N')
    {
        Console.WriteLine($"\nInvalid input. {orientationBaseConfirmCancel}");
    }
} while (userInput != 'Y' && userInput != 'N');

if (userInput == 'N')
{
    Console.WriteLine("\nOperation cancelled by the user.");
    return;
}

try
{
    DeleteBinAndObjFolders(currentDirectory);

    Console.WriteLine("\nOperation completed successfully.");
} catch (Exception ex) {
    Console.WriteLine($"\nAn error occurred: {ex.Message}");
}

static void DeleteBinAndObjFolders(string directoryPath)
{
    try
    {
        string[] subDirectories = Directory.GetDirectories(directoryPath);
        foreach (string subDirectory in subDirectories)
        {
            string folderName = Path.GetFileName(subDirectory);
            if (folderName == "bin" || folderName == "obj")
            {
                if (!Directory.GetFiles(directoryPath).Any(x => x.EndsWith(".csproj")))
                {
                    Console.WriteLine($"\nSkipping deletion of {subDirectory} because it contains a corresponding .csproj file.");
                    continue;
                }
                Directory.Delete(subDirectory, true);
                Console.WriteLine($"\nDeleted folder: {subDirectory}");
            }
            else
            {
                DeleteBinAndObjFolders(subDirectory); // Recursive call for nested directories
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nAn error occurred while deleting folders in {directoryPath}: {ex.Message}");
    }
    finally { 
        Console.WriteLine($"\nFinished processing directory: {directoryPath}");
        Console.WriteLine("Press ENTER to close");
        Console.ReadLine();
    }
}
