using System.Globalization;
using CsvHelper;

namespace TrainingPlanner.FileImport;

public class CsvParser
{
    public IEnumerable<ExerciseModel> ParseAndSaveToDatabase(string csvFilePath)
    {
        using var reader = new StreamReader(csvFilePath);
        using var csv = new CsvReader(reader,CultureInfo.InvariantCulture);
        var records = csv.GetRecords<ExerciseModel>().ToList();
        
        return records;
    }
}
