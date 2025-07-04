using System.Collections.Concurrent;
using RazorLight;

public class RazorLightTemplatePrecompiler
{
    private readonly IRazorLightEngine _engine;
    public ConcurrentDictionary<string, ITemplatePage> CompiledTemplates { get; } = new();

    public RazorLightTemplatePrecompiler(IRazorLightEngine engine)
    {
        _engine = engine;
    }

    public async Task InitializeAsync(IEnumerable<string> templateNames)
    {
        var tasks = templateNames.Select(async name =>
        {
            var template = await _engine.CompileTemplateAsync(name);
            CompiledTemplates[name] = template;
        });

        await Task.WhenAll(tasks);
    }
}
