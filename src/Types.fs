module Root

type Validated<'t> = { Raw: string; Parsed: Option<'t> }

module Validated =
    let empty () : Validated<_> = { Raw = ""; Parsed = None }

    let success r v = { Raw = r; Parsed = Some v }

    let failure r = { Raw = r; Parsed = None }

module Msg =

    type Counter =
        | Increment
        | Decrement

    type Input =
        | SetBuiltInNumberInput of Validated<int>
        | SetNumberInput of Validated<int>

module State =
    type Counter = int

    type Input =
        { BuiltInNumber: Validated<int>
          Int: Validated<int> }

type State =
    { Counter: State.Counter
      Input: State.Input }

let StateDefault: State =
    { Counter = 0
      Input =
        { BuiltInNumber = Validated.empty ()
          Int = Validated.empty () } }

type Msg =
    { Counter: Option<Msg.Counter>
      Input: Option<Msg.Input> }

let MsgDefault = { Counter = None; Input = None }
