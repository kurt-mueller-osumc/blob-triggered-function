open Microsoft.Extensions.Hosting
open Microsoft.Azure.Functions.Worker

[<EntryPoint>]
let main args =
    let hostBuilder = new HostBuilder()

    hostBuilder.ConfigureFunctionsWorkerDefaults(fun (context: HostBuilderContext) (appBuilder: IFunctionsWorkerApplicationBuilder) ->
        appBuilder.ConfigureBlobStorageExtension() |> ignore
    ) |> ignore

    let host = hostBuilder.Build()

    host.Run()

    0