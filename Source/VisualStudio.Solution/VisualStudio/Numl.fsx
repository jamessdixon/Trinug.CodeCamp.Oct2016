
#r "../packages/numl.0.8.26.0/lib/net40/numl.dll"

open numl
open System
open numl.Model
open numl.Supervised.DecisionTree

type Outlook =
| Sunny = 0
| Overcast = 1
| Rainy = 2

type Temperature =
| Low = 0
| High = 1

type Tennis = { [<Label>] Play : bool ;
    [<Feature>] Outlook : Outlook ; 
    [<Feature>] Temperature : Temperature ;
    [<Feature>] Windy : bool}
with
    static member Create(play, outlook, temp, windy) =
        { Play = play ; Outlook=outlook; Temperature = temp ; Windy = windy }
    static member GetData() =
        [ Tennis.Create(true, Outlook.Sunny, Temperature.Low, true) ;
          Tennis.Create(false, Outlook.Sunny, Temperature.High, true);
          Tennis.Create(false, Outlook.Sunny, Temperature.High, false);
          Tennis.Create(true, Outlook.Overcast, Temperature.Low, true);
          Tennis.Create(true, Outlook.Overcast, Temperature.High, false);
          Tennis.Create(true, Outlook.Overcast, Temperature.Low, false);
          Tennis.Create(false, Outlook.Rainy, Temperature.Low, true);
          Tennis.Create(true, Outlook.Rainy, Temperature.Low, false) ]

let data = Tennis.GetData()
let data' = data |> Seq.map (fun t -> t :> obj)
let d = Descriptor.Create<Tennis>()
let g = new DecisionTreeGenerator(d)
g.SetHint(false)
let model = Learner.Learn(data', 0.80, 1000, g)
model.ToString()
