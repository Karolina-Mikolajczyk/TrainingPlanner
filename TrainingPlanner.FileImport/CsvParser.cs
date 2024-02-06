using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace TrainingPlanner.FileImport;

public class CsvParser : IDisposable
{
    private TextReader _streamReader;

    public CsvParser(TextReader streamReader)
    {
        _streamReader = streamReader;
    }

    public static IEnumerable<ExerciseModel> ParseFile(string csvFilePath)
    {
        using var reader = new StreamReader(csvFilePath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) {Delimiter = ";"});
        var records = csv.GetRecords<ExerciseModel>().ToList();
        
        return records;
    }

    public IEnumerable<ExerciseModel> ParseFile()
    {
        var csvReader = new CsvReader(_streamReader, new CsvConfiguration(CultureInfo.InvariantCulture) {Delimiter = ";"});
        var records = csvReader.GetRecords<ExerciseModel>().ToList();

        return records;
    }

    public void Dispose()
    {
        _streamReader.Dispose();
    }
}
