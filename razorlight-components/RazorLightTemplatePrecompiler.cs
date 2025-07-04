using System.Collections.Concurrent;
using Microsoft.Extensions.Hosting;
using RazorLight;

public class RazorLightTemplatePrecompiler : IHostedService
{
    private readonly IRazorLightEngine _engine;
    private readonly IEnumerable<string> _templateNames;

    public static ConcurrentDictionary<string, ITemplatePage> CompiledTemplates { get; } = new ConcurrentDictionary<string, ITemplatePage>();

    public RazorLightTemplatePrecompiler(IRazorLightEngine engine, IEnumerable<string> templateNames)
    {
        _engine = engine;
        _templateNames = templateNames;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var tasks = _templateNames.Select(async name =>
        {
            var template = await _engine.CompileTemplateAsync(name);
            CompiledTemplates[name] = template;
        });

        await Task.WhenAll(tasks);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
