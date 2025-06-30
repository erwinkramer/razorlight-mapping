public partial class TemplateHelper
{
    public static string GetIBAN(string? input)
    {
        if (input is "John Doe")
        {
            return "DE89370400440532013000";
        }
        return "UNKNOWN_IBAN";
    }
}