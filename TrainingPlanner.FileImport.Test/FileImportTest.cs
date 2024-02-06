using Xunit;

namespace TrainingPlanner.FileImport.Test;

public class FileImportTest
{
    [Fact]
    public async Task Test()
    {
        var andSaveToDatabase = CsvParser.ParseFile(@"C:\Users\karol\Desktop\treningbiegacza\exercises1.csv");

        Assert.True(andSaveToDatabase.Any());
    }
}