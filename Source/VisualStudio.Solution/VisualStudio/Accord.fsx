
#r "../packages/Accord.3.3.0/lib/net40/Accord.dll"
#r "../packages/FSharp.Data.2.3.2/lib/net40/FSharp.Data.dll"
#r "../packages/Accord.Math.3.3.0/lib/net40/Accord.Math.dll"
#r "../packages/Accord.Statistics.3.3.0/lib/net40/Accord.Statistics.dll"

open Accord
open Accord.Statistics.Models.Regression.Linear

open FSharp.Data

[<Literal>]
let path = @"C:\Git\Trinug.CodeCamp.Oct2016\Trinug.CodeCamp.Oct2016\Data\auto-mpg.csv"

type Context = CsvProvider<path>
let autos = Context.Load(path).Rows

let x = autos |> Seq.map(fun a -> float a.Weight) |> Seq.toArray 
let y = autos |> Seq.map(fun a -> float a.MPG ) |> Seq.toArray
let ols = new OrdinaryLeastSquares()
let regression = ols.Learn(x,y)
let intercept = regression.Intercept
let slope = regression.Slope
let r2 = regression.CoefficientOfDetermination(x,y)