module Counter

open Elmish
open Elmish.React
open Feliz

type State = int

type Msg = Root.Msg.Counter

let init () = 0

let update (msg: Msg) (state: State) : State =
    match msg with
    | Msg.Increment -> state + 1
    | Msg.Decrement -> state - 1

let private button (msg: Msg) (dispatch: Root.Msg -> unit) : ReactElement =
    let text =
        match msg with
        | Msg.Increment -> "+"
        | Msg.Decrement -> "-"
        + "1"

    Html.button
        [ prop.style
              [ style.backgroundColor "white"
                style.fontSize (length.em 3)
                style.width (length.em 2)
                style.height (length.em 2)
                style.borderRadius (length.percent 22) ]
          prop.text text
          prop.onClick (fun _ ->
              dispatch
                  { Root.MsgDefault with
                      Counter = Some msg }) ]


let render (state: State) (dispatch: Root.Msg -> unit) =
    Html.div
        [ prop.style
              [ style.backgroundColor "salmon"
                style.borderRadius 3
                style.padding (length.em 1) ]

          prop.children (
              Html.h1 $"Count: {state}"
              :: ([ Msg.Increment; Msg.Decrement ] |> List.map (fun msg -> button msg dispatch))
          )


          ]
