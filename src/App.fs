// For more information see https://aka.ms/fsharp-console-apps

open Feliz
open Elmish
open Elmish.React

let init () = Types.StateDefault

let rec update (msg: Types.Msg) (state: Types.State) : Types.State =
    // [
    //     (msg.Counter, fun (o: Types.Msg) -> { state with Count = Counter.upd o state.Count } )
    //     (msg.Input, fun o -> { state with Input = Input.update o state.Input })
    // ]
    //    |> List.map (fun o ->
    //         match o with
    //         | Some m ->
    //     )

    match msg.Counter with
    | Some counter ->
        update
            { msg with Counter = None }
            { state with
                Counter = Counter.upd counter state.Counter }
    | None ->
        match msg.Input with
        | Some m ->
            update
                { msg with Input = None }
                { state with
                    Input = Input.update m state.Input }
        | None -> state

let render (state: Types.State) (dispatch: Types.Msg -> unit) : ReactElement =
    Html.div
        [ Html.h1 "Elmish Vite Template"
          Counter.render state.Counter dispatch
          Input.render state.Input dispatch ]


Program.mkSimple init update render
|> Program.withReactSynchronous "elmish"
|> Program.run
