namespace CSVConverter;

public class CsvConverter : ICsvConverter
{
    public string ConvertToCsv(IConvertibleToCsv objectToConver)
    {
        List<string>? fieldsList = objectToConver.ConvertFieldsToStringList();
        return String.Join(',', fieldsList);
    }
}
