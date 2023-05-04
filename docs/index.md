# .Net ASP Core 

This app contains source code for a .Net ASP Core v7 application that can be built and deployed automatically by the Tanzu Application Platform. The app includes a web page created using ([Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-7.0&tabs=visual-studio)) and a basic REST API. This application was initially created using an Accelerator for .Net applications.

Features at a glance:

* A .Net written in C#
* Razor Pages to provide web page templating and a landing page for the site
* A REST API that allows you to GET `/api/messages` (returns a JSON string built in `MessagesService.cs`)
* Backstage TechDocs using Markdown (see `mkdocs.yml` and `docs/index.md`)

Navigating your broswer to **http(s)://&lt;your.hosting.url&gt;:&lt;port&gt;** should show the following screen:

![supply chain diagram](https://github.com/benwilcock/dotnet-aspcore/raw/main/WebAppDemoCode/wwwroot/tap-into-prod.png "Composable and Modular - TAP Supply Chains")

## Running on the VMware Tanzu Application Platform

[Watch it deploy on Tanzu Application Platform.](https://via.vmw.com/tap-dotnet-sc)

The application can be deployed via the `tanzu` cli using a command line similar to this one:

```powershell
tanzu apps workload create dotnet-aspcore `
  --git-repo https://github.com/benwilcock/dotnet-aspcore `
  --git-branch main `
  --type web `
  --build-env BP_DOTNET_PROJECT_PATH=./WebAppDemoCode `
  --label apps.tanzu.vmware.com/has-tests=true `
  --label app.kubernetes.io/part-of=dotnet-aspcore `
  --param-yaml testing_pipeline_matching_labels="{'apps.tanzu.vmware.com/pipeline':'test', 'apps.tanzu.vmware.com/language':'dotnet'}" `
  --annotation autoscaling.knative.dev/minScale=1 `
  --tail --yes
```

You may need to modify this command depending needs of the supply chain you're using.

## Customisations

For a simple customisation, in the application code (in the `appsettings.json` file) change the name of the `DemoClient` property from "VMware" to something else and then commit/redeploy/restart.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "DemoClient": "VMware"
}
```

