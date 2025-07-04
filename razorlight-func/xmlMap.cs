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
    private IEnumerable<ITemplatePage> _compiledMaps;

    public xmlMap(ILogger<xmlMap> logger, IRazorLightEngine engine, IEnumerable<ITemplatePage> compiledTemplates)
    {
        _logger = logger;
        _engine = engine;
        _compiledMaps = compiledTemplates;
    }

    [Function("xmlMap")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        return new ContentResult
        {
            Content = await Engine.RunRazorLightXmlMapping(_engine, _compiledMaps.First()),
            ContentType = "application/xml",
            StatusCode = 200
        };
    }
}
