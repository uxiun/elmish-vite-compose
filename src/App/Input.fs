module Input

open Feliz
open Elmish
open Elmish.React

type State = string

type Msg = Types.Input

let update (msg: Msg) (state: State) : State =
    match msg with
    | Types.Input.SetInput s -> s

let render (state: State) (dispatch: Types.Msg -> unit) : ReactElement =
    Html.div
        [ Html.h1 "Calculator"
          Html.input
              [ prop.onChange (fun s ->
                    dispatch
                        { Types.MsgDefault with
                            Input = Some(Types.Input.SetInput s) })
                prop.valueOrDefault state ]
          Html.span $"current: {state}" ]
