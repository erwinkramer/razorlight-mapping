using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MappingEngine;
using RazorLight;

namespace razorlight_func;

public class xmlMap
{
    private readonly ILogger<xmlMap> _logger;
    private IRazorLightEngine _engine;
    private ITemplatePage _compiledXmlMap;

    public xmlMap(ILogger<xmlMap> logger, IRazorLightEngine engine)
    {
        _logger = logger;
        _engine = engine;
        _compiledXmlMap = _engine.CompileTemplateAsync("dynamicXmlMap.cshtml").GetAwaiter().GetResult();
    }

    [Function("xmlMap")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        return new ContentResult
        {
            Content = await Engine.RunRazorLightXmlMapping(_engine, _compiledXmlMap),
            ContentType = "application/xml",
            StatusCode = 200
        };
    }
}
