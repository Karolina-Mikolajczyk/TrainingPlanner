using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace TrainingPlanner.FileImport;

public class CsvParser
{
    public static IEnumerable<ExerciseModel> ParseFile(string csvFilePath)
    {
        using var reader = new StreamReader(csvFilePath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) {Delimiter = ";"});
        var records = csv.GetRecords<ExerciseModel>().ToList();
        
        return records;
    }
}
