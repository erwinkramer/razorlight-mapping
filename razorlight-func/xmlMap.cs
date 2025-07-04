using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RazorLight;

namespace razorlight_func;

public class xmlMap
{
    private readonly ILogger<xmlMap> _logger;
    private IRazorLightEngine _engine;
    private readonly RazorLightTemplatePrecompiler _precompiler;

    public xmlMap(ILogger<xmlMap> logger, IRazorLightEngine engine, RazorLightTemplatePrecompiler precompiler)
    {
        _logger = logger;
        _engine = engine;
        _precompiler = precompiler;
    }

    [Function("xmlMap")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        return new ContentResult
        {
            Content = await RazorLightEngineHelper.RunRazorLightXmlMapping(_engine, _precompiler.CompiledTemplates.First().Value),
            ContentType = "application/xml",
            StatusCode = 200
        };
    }
}
