public class Program
{
    public static async Task Main(string[] args)
    {
        var engine = RazorLightEngineHelper.GetRazorLightEngine();
        var compiledXmlMap = await engine.CompileTemplateAsync("dynamicXmlMap.cshtml");
        var compiledJsonMap = await engine.CompileTemplateAsync("dynamicJsonMap.cshtml");

        Console.WriteLine("XML Sample 🎢:" + Environment.NewLine);
        Console.WriteLine(RazorLightEngineHelper.PrettyPrintXml(await RazorLightEngineHelper.RunRazorLightXmlMapping(engine, compiledXmlMap)));
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Json Sample 🎡:" + Environment.NewLine);
        Console.WriteLine(RazorLightEngineHelper.PrettyPrintXml(await RazorLightEngineHelper.RunRazorLightJsonMapping(engine, compiledJsonMap)));
    }
}