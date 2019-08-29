// Learn more about F# at http://fsharp.org
open Expecto
open Expecto.Logging

open System
let testConfig =  
    { Expecto.Tests.defaultConfig with 
         verbosity = LogLevel.Debug
         parallelWorkers = 1 }

let allTests =
    testList "All Tests"
        [
           ICCTests.iccTests
        ]
[<EntryPoint>]
let main argv =
    runTests testConfig allTests
