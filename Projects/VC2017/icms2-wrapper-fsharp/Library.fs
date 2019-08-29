namespace icms2_wrapper

open System.Runtime.InteropServices
open System.IO
open System

#nowarn "9"
open Microsoft.FSharp.NativeInterop


type Icms(iccInProfile, inputFormat: Format, iccOutProfile, outputFormat: Format, intent: Indent, dwFlags) =
    let intPtrs = ResizeArray();

    let intPtrToVoidPtr intPtr =
        let typedPtr: nativeptr<int> = NativePtr.ofNativeInt intPtr
        NativePtr.toVoidPtr(typedPtr)

    let stringToPtr (text: string) =
        let intPtr = Marshal.StringToHGlobalAnsi(text)
        intPtrs.Add(intPtr)
        NativeInterop.NativePtr.ofNativeInt intPtr



    let createTransform(iccInProfile, inputFormat, iccOutProfile, outputFormat, intent, dwFlags) =
        let input = icms2_clr.CmsOpenProfileFromFile(iccInProfile, "r")
        let output = icms2_clr.CmsOpenProfileFromFile(iccOutProfile, "r")
        try 
            let transformPtr = icms2_clr.CmsCreateTransform(input, inputFormat, output, outputFormat, intent, dwFlags)
            transformPtr
        finally 
            icms2_clr.CmsCloseProfile(input) |> ignore
            icms2_clr.CmsCloseProfile(output) |> ignore


    let transform = createTransform (iccInProfile, uint32 inputFormat, iccOutProfile,uint32 outputFormat,uint32 intent, dwFlags)


    member x.DoTransfrom(inputBuffer: float32 []) =
        
        let inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(inputBuffer.[0]) * inputBuffer.Length);
        Marshal.Copy(inputBuffer, 0, inPtr, inputBuffer.Length)
        let outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(0.f) * 4)
        try
            let destination = Array.create 4 0.f
            icms2_clr.CmsDoTransform(transform, inPtr , outPtr , 1u)
            Marshal.Copy(outPtr, destination, 0, 4)
            destination
        finally
            Marshal.FreeHGlobal(inPtr)
            Marshal.FreeHGlobal(outPtr)

    interface IDisposable with 
        member x.Dispose() = 
            for intPtr in intPtrs do
                Marshal.FreeHGlobal(intPtr)
            icms2_clr.CmsDeleteTransform(transform)
