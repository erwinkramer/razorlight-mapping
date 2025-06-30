using MappingEngine;

public class Program
{
    public static async Task Main(string[] args)
    {
        var engine = Engine.GetEngine();
        var compiledXmlMap = await engine.CompileTemplateAsync("dynamicXmlMap.cshtml");
        var compiledJsonMap = await engine.CompileTemplateAsync("dynamicJsonMap.cshtml");

        Console.WriteLine("XML Sample 🎢:" + Environment.NewLine);
        Console.WriteLine(Engine.PrettyPrintXml(await Engine.RunRazorLightXmlMapping(engine, compiledXmlMap)));
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Json Sample 🎡:" + Environment.NewLine);
        Console.WriteLine(Engine.PrettyPrintXml(await Engine.RunRazorLightJsonMapping(engine, compiledJsonMap)));
    }
}