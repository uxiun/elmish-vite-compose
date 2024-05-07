// For more information see https://aka.ms/fsharp-console-apps

open Feliz
open Elmish
open Elmish.React
open Root

let init () = StateDefault

// let rec update (msg: Msg) (state: State) : State =
//     // [
//     //     (msg.Counter, fun (o: Types.Msg) -> { state with Count = Counter.upd o state.Count } )
//     //     (msg.Input, fun o -> { state with Input = Input.update o state.Input })
//     // ]
//     //    |> List.map (fun o ->
//     //         match o with
//     //         | Some m ->
//     //     )

//     match msg.Counter with
//     | Some counter ->
//         update
//             { msg with Counter = None }
//             { state with
//                 Counter = Counter.update counter state.Counter }
//     | None ->
//         match msg.Input with
//         | Some m ->
//             update
//                 { msg with Input = None }
//                 { state with
//                     Input = Input.update m state.Input }
//         | None -> state

// let updaters = {
//     Counter = (Counter.update)
// }

let update (msg: Msg) (state: State) : State =
    match msg.Counter, msg.Input with
    | Some c, Some i ->
        { state with
            Counter = Counter.update c state.Counter
            Input = Input.update i state.Input }
    | Some c, None ->
        { state with
            Counter = Counter.update c state.Counter }
    | None, Some i ->
        { state with
            Input = Input.update i state.Input }
    | _ -> state


let render (state: State) (dispatch: Msg -> unit) : ReactElement =
    Html.div
        [ Html.h1 "Elmish Vite Template"
          Counter.render state.Counter dispatch
          Input.render state.Input dispatch ]


Program.mkSimple init update render
|> Program.withReactSynchronous "elmish"
|> Program.run
