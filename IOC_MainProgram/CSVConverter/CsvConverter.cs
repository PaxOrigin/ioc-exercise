using System.Text;

namespace CSVConverter;

public class CsvConverter : ICsvConverter
{
    public string ConvertToCsv(IConvertibleToCsv objectToConver)
    {
        List<string>? fieldsList = objectToConver.ConvertFieldsToStringList();
        var csvString = new StringBuilder();
        csvString.AppendLine("Matricola,Username,Password,Data");
        csvString.AppendLine(String.Join(',', fieldsList));
        return csvString.ToString();
    }
}
