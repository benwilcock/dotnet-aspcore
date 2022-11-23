# ASP .Net Core (Razor Pages) sample app (with tests)

Designed to illustrate how buildpacks and supply chains work to build and deploy an application on Kubernetes. Should work just fine with VMware Tanzu Application Platform and VMware Tanzu Application Service.

## Running Locally

`dotnet run --project WebAppDemoCode`

## Running Tests

`dotnet test`

## Viewing The Homepage

Point your browser to`http://localhost:5001`

## Viewing The Messages REST Endpoint

Point your browser to`http://localhost:5001/api/messages` or follow the link on the homepage.

## Running on VMware Tanzu Application Platform

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

## Application Endpoints

1. `/`  HTML home page (shows a single page app containing a static image and some text). Contains a link to the source code.
1. `/api/messages` REST Json [GET] (shows a single hardcoded message as part of a list of messages).

## Customisations

For a simple customisation, in the application code (in the `appsettings.json` file) change the name of the `client` property from "VMware" to something else and then commit/redeploy/restart.

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

The homepage will then use the new name of the client in the text at the bottom of the page.

## TODO: Vulnerability Scanning

### Adding a known CVE:

Details here

### Removing the CVE:

Details here
