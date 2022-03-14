using System.IO;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName,"",SearchOption.AllDirectories);

   /*  foreach(var fileName in foundFiles) {
        if(fileName.EndsWith("sales.json")){
            salesFiles.Add(fileName);
        }
    } */

    foreach (var fileName in foundFiles)
    {
        var extension = Path.GetExtension(fileName);
        if(extension == ".json") {
            salesFiles.Add(fileName);
        }
    }

    return salesFiles;
}

//var salesFiles = FindFiles("stores");
var currentDirectrory = Directory.GetCurrentDirectory();
var storesDirectroy = Path.Combine(currentDirectrory,"stores");

var salesFiles = FindFiles(storesDirectroy);


foreach (var file in salesFiles)
{
    Console.WriteLine(file);
}

var salesTotalDir = Path.Combine(currentDirectrory,"salesTotalDir");

Directory.CreateDirectory(salesTotalDir);

File.WriteAllText(Path.Combine(salesTotalDir,"total.txt"),String.Empty);