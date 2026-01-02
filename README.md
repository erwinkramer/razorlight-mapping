# Mapping messages with RazorLight 🛝

[![CC BY-NC-SA 4.0][cc-by-nc-sa-shield]][cc-by-nc-sa]
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/erwinkramer/razorlight-mapping)

This repo contains a reference implementation to map data with [jcamp.RazorLight](https://github.com/jcamp-code/RazorLight).

Following paragraphs are a breakdown of the projects in this repo.

## [razorlight-components](/razorlight-components/) project

Core class-library that contains:

- [Templates](/razorlight-components/Templates/) for the templates in [Razor format](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/razor?view=aspnetcore-10.0).
- [TemplateHelper](/razorlight-components/TemplateHelper/) for .NET helpers to streamline mappings.
- [ViewModel](/razorlight-components/ViewModel/) for the [Razor ViewModels](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/overview?view=aspnetcore-10.0#pass-data-to-views). Each `template` uses one `ViewModel`.
- [DataSamples](/razorlight-components/DataSamples/) as demo inputs for the provided templates.

## [razorlight-console](/razorlight-console/) project

Implements [razorlight-components](/razorlight-components/) and outputs mappings to the console.

## [razorlight-func](/razorlight-func/) project

Implements [razorlight-components](/razorlight-components/) and is deployable to an Azure Function App. The function `xmlMap` returns the `xml`-map output via RazorLight.

Precompiles the maps asynchronously, before the function app even runs, via the [RazorLightTemplatePrecompiler](/razorlight-components/RazorLightTemplatePrecompiler.cs).

## License

This work is licensed under a
[Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License][cc-by-nc-sa].

[![CC BY-NC-SA 4.0][cc-by-nc-sa-image]][cc-by-nc-sa]

[cc-by-nc-sa]: http://creativecommons.org/licenses/by-nc-sa/4.0/
[cc-by-nc-sa-image]: https://licensebuttons.net/l/by-nc-sa/4.0/88x31.png
[cc-by-nc-sa-shield]: https://img.shields.io/badge/License-CC%20BY--NC--SA%204.0-lightgrey.svg
