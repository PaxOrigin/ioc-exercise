namespace CSVConverter;

public interface ICsvConverter
{
    public string ConvertToCsv(IConvertibleToCsv objectToConver);
}
