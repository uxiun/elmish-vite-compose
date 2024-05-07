module Types

type Counter =
    | Increment
    | Decrement

type Input = SetInput of string

type State = { Counter: int; Input: string }

let StateDefault: State = { Counter = 0; Input = "" }

type Msg =
    { Counter: Option<Counter>
      Input: Option<Input> }

let MsgDefault = { Counter = None; Input = None }
