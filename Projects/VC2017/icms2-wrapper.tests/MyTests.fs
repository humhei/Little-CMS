module ICCTests

open System.Runtime.InteropServices
open System.IO
open System
open icms2_wrapper

#nowarn "9"
open Expecto
open Microsoft.FSharp.NativeInterop




let iccTests =
  testList "icc tests" [
    testCase "convert rgb to cmyk" <| fun _ ->
        //let icms2Clr = new icms2ClrClass()
        use icms2 = new Icms(@"icc/sRGB Color Space Profile.ICM", Format.TYPE_RGB_FLT, @"icc/JapanColor2001Coated.ICC", Format.TYPE_CMYK_FLT, Indent.INTENT_PERCEPTUAL, 0u)
        let result = icms2.DoTransfrom([|0.f;0.f;1.f|])
        ()

    testCase "convert rgb to lab" <| fun _ ->
        //let icms2Clr = new icms2ClrClass()
        use icms2 = new Icms(@"icc/sRGB Color Space Profile.ICM", Format.TYPE_RGB_FLT, @"icc/CIE Lab.ICC", Format.TYPE_LabA_FLT, Indent.INTENT_PERCEPTUAL, 0u)
        let result = icms2.DoTransfrom([|0.f;0.f;1.f|])
        ()
  ]