using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Services.AddRazorLightEngine();
builder.Services.AddSingleton<RazorLightTemplatePrecompiler>();

var app = builder.Build();

await app.InitializeRazorLightTemplatePrecompiler(["dynamicXmlMap.cshtml"]);

app.Run();