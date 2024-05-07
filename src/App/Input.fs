module Input

open Feliz
open Elmish
open Elmish.React

let tryParseInt (s: string) : Root.Validated<int> =
  try
    Root.Validated.success s (int s)
  with _ ->
    Root.Validated.failure s

let validatedTextColor (validated: Root.Validated<_>) =
  match validated.Parsed with
  | Some _ -> color.green
  | _ -> color.crimson

type State = Root.State.Input

type Msg = Root.Msg.Input

let update (msg: Msg) (state: State) : State =
  match msg with
  | Msg.SetBuiltInNumberInput s -> { state with BuiltInNumber = s }
  | Msg.SetNumberInput i -> { state with Int = i }
  | Msg.SetStr s -> { state with Str = s }
  | Msg.SetCapitalized k -> { state with Capitalized = k }

let render (state: State) (dispatch: Root.Msg -> unit) : ReactElement =
  Html.div [
    Html.h1 "Calculator"
    Html.div [
      Html.label [
        Html.span "built-in Number Validation"

        Html.input [
          prop.type'.number
          prop.onChange (fun s ->
            dispatch {
              Root.MsgDefault with
                  Input = tryParseInt s |> Msg.SetBuiltInNumberInput |> Some
            }
          )
          prop.valueOrDefault state.BuiltInNumber.Raw
        ]
      ]

      Html.span state.BuiltInNumber.Raw
    ]

    Html.div [
      Html.label [
        Html.span "Number Validation"

        Html.input [
          prop.onChange (fun s ->
            dispatch {
              Root.MsgDefault with
                  Input = tryParseInt s |> Msg.SetNumberInput |> Some
            }
          )
          prop.valueOrDefault state.Int.Raw
        ]
      ]

      Html.h2 [
        prop.style [ style.color (validatedTextColor state.Int) ]
        prop.text state.Int.Raw
      ]

    ]

    Html.div [
      Html.label [
        Html.span "Str"
        Html.input [
          prop.onChange (fun s ->
            dispatch {
              Root.MsgDefault with
                  Input = s |> Msg.SetStr |> Some
            }
          )

          prop.valueOrDefault state.Str
        ]
      ]

      Html.label [
        Html.span "Capitalize"
        Html.input [
          prop.onChange (fun k ->
            dispatch {
              Root.MsgDefault with
                  Input = Some(Msg.SetCapitalized k)
            }
          )
          prop.type'.checkbox
          prop.isChecked state.Capitalized
        ]
      ]

      Html.div [
        Html.span (if state.Capitalized then state.Str.ToUpper() else state.Str)

      ]
    ]
  ]
