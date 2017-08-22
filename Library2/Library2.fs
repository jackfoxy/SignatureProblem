namespace Library2

open Microsoft.WindowsAzure.Storage // Namespace for CloudStorageAccount
open Microsoft.WindowsAzure.Storage.Table

type Customer(firstName, lastName, email: string, phone: string) =
        inherit TableEntity(partitionKey=lastName, rowKey=firstName)
        new() = Customer(null, null, null, null)
        member val Email = email with get, set
        member val PhoneNumber = phone with get, set

module Library2 =
    let DoIt () =
        let storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true")

        // Create the table client.
        let tableClient = storageAccount.CreateCloudTableClient()

        // Retrieve a reference to the table.
        let table = tableClient.GetTableReference("people")

        // Create the table if it doesn't exist.
        table.CreateIfNotExists()

        let customer = 
            Customer("Walter", "jones22", "Walter@contoso.com", "425-555-0101")

        let insertOp = TableOperation.Insert(customer)
        let x = table.Execute(insertOp)

        printfn "status %i" x.HttpStatusCode
