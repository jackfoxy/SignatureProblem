# Demonstration of problem:

.NET 4.6.1

FSharp.Core (4.2.3)

WindowsAzure.Storage (8.3)

Given the demo code to insert into an Azure Storage Table https://docs.microsoft.com/en-us/dotnet/fsharp/using-fsharp-on-azure/table-storage

Using local development storage "UseDevelopmentStorage=true".

Run from VS 2017 debugger.

The same code will work if there is no FSI file over the library function, but with an FSI file, only the partition and row keys are inserted into the table, not the rest of the data columns.

# Analysis of problem:

Note in the compiled assemblies of the two libraries, the library with the signature file (Librayr 2) has the non-key field properties marked "internal". The Azure problem is possibly doing some sort of reflection that is not picking this up.