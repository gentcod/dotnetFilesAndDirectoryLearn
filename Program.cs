using System;
using System.IO;
using System.Collections.Generic;

string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

var sepChar = Path.DirectorySeparatorChar;
string path = $"stores{sepChar}201{sepChar}sales.json";

FileInfo info = new FileInfo(path);
// Console.WriteLine($"Full Name: {info.FullName} \nDirectory: {info.Directory} \nExtension: {info.Extension} \nCreate Date: {info.CreationTime}");

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        // if (extension == ".json") salesFiles.Add(file);

        // The file name will contain the full path, so only check the end of it
        if (file.EndsWith(".json")) salesFiles.Add(file);
       
    }

    return salesFiles;
}

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);

File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);

//Read file contents
string sales201Content = File.ReadAllText(path);
Console.WriteLine(sales201Content);







/////////////////////////////////////////////////
// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }

//Create new directory
Directory.CreateDirectory(Path.Combine(storesDirectory, "newDir"));
var newDirectory = Path.Combine(storesDirectory, "newDir");

//Check if directory exists
// bool doesDirectoryExist = Directory.Exists(newDirectory);

//Create new file
File.WriteAllText(Path.Combine(newDirectory, "newSales.json"), "New file created");