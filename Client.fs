﻿namespace tesztWebSharper3

open WebSharper
open WebSharper.UI
open WebSharper.UI.Notation
open WebSharper.UI.Templating

[<JavaScript>]
module Templates =   
    type MainTemplate = Templating.Template<"Main.html", ClientLoad.FromDocument, ServerLoad.PerRequest>

[<JavaScript>]
module Client =
    let DoSomething (input: string) =
        System.String(Array.rev(input.ToCharArray()))

    let Main () =
        let rvReversed = Var.Create ""
        Templates.MainTemplate.MainForm()
            .OnSend(fun e ->
                let res = DoSomething e.Vars.TextToReverse.Value
                rvReversed := res
            )
            .Reversed(rvReversed.View)
            .Doc()
