
using System;
using System.IO;
using System.Collections.Generic;
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


double CaluculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    foreach (var salesFile in salesFiles)
    {
        var salesJson = File.ReadAllText(salesFile);

        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        salesTotal = salesTotal + data?.Total ?? 0;

    }

    return salesTotal;
}

//var salesFiles = FindFiles("stores");
var currentDirectrory = Directory.GetCurrentDirectory();
var storesDirectroy = Path.Combine(currentDirectrory,"stores");

var salesFiles = FindFiles(storesDirectroy);


foreach (var file in salesFiles)
{
    Console.WriteLine(file);
}

var salesTotal = CaluculateSalesTotal(salesFiles);

var salesTotalDir = Path.Combine(currentDirectrory,"salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

File.AppendAllText(Path.Combine(salesTotalDir,"total.txt"),$"{salesTotal}{Environment.NewLine}");

record SalesData (double Total);