namespace Comrit.Functions

open System
open System.IO
open Microsoft.Azure.Functions.Worker
open Microsoft.Extensions.Logging

module ReadBlob =

    [<Function("ReadBlob")>]
    let run
        (
            [<BlobTrigger("samples-workitems/{name}", Connection = "")>] myBlob: Stream,
            name: string,
            context: FunctionContext
        ) =
        let logger
            = context.GetLogger "ReadBlob"

        use blobStreamReader
            = new StreamReader(myBlob)

        let blobContent
            = blobStreamReader.ReadToEndAsync()
            |> Async.AwaitTask
            |> Async.RunSynchronously

        let msg =
            sprintf "F# Blob trigger function Processed blob\nName: %s \n Data: %s" name blobContent

        logger.LogInformation msg
