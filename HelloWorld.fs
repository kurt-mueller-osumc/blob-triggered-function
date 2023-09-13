namespace Comrit.Functions

open System.Net
open Microsoft.Azure.Functions.Worker
open Microsoft.Azure.Functions.Worker.Http
open Microsoft.Extensions.Logging

module HelloWorld =

    [<Function("HelloWorld")>]
    let run
        ([<HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)>] req: HttpRequestData)
        (context: FunctionContext)
        =
        let logger = context.GetLogger "HelloWorld"
        logger.LogInformation "F# HTTP trigger function processed a request"

        let response = req.CreateResponse(HttpStatusCode.OK)
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8")

        response.WriteString "Welcome to Azure Functions!"

        response
