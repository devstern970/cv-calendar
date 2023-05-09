// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ImageMagick;

public partial class Quantum
{
    [SuppressUnmanagedCodeSecurity]
    private static unsafe class NativeMethods
    {
        #if PLATFORM_x64 || PLATFORM_AnyCPU
        public static class X64
        {
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern UIntPtr Quantum_Depth_Get();
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern QuantumType Quantum_Max_Get();
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern byte Quantum_ScaleToByte(QuantumType value);
        }
        #endif
        #if PLATFORM_arm64 || PLATFORM_AnyCPU
        public static class ARM64
        {
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern UIntPtr Quantum_Depth_Get();
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern QuantumType Quantum_Max_Get();
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern byte Quantum_ScaleToByte(QuantumType value);
        }
        #endif
        #if PLATFORM_x86 || PLATFORM_AnyCPU
        public static class X86
        {
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern UIntPtr Quantum_Depth_Get();
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern QuantumType Quantum_Max_Get();
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern byte Quantum_ScaleToByte(QuantumType value);
        }
        #endif
    }
    private unsafe static class NativeQuantum
    {
        static NativeQuantum() { Environment.Initialize(); }
        public static int Depth
        {
            get
            {
                UIntPtr result;
                #if PLATFORM_AnyCPU
                if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.Quantum_Depth_Get();
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.Quantum_Depth_Get();
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.Quantum_Depth_Get();
                #endif
                return (int)result;
            }
        }
        public static QuantumType Max
        {
            get
            {
                QuantumType result;
                #if PLATFORM_AnyCPU
                if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.Quantum_Max_Get();
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.Quantum_Max_Get();
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.Quantum_Max_Get();
                #endif
                return result;
            }
        }
        public static byte ScaleToByte(QuantumType value)
        {
            byte result;
            #if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
            #endif
            #if PLATFORM_arm64 || PLATFORM_AnyCPU
            result = NativeMethods.ARM64.Quantum_ScaleToByte(value);
            #endif
            #if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
            #endif
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            result = NativeMethods.X64.Quantum_ScaleToByte(value);
            #endif
            #if PLATFORM_AnyCPU
            else
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            result = NativeMethods.X86.Quantum_ScaleToByte(value);
            #endif
            return result;
        }
    }
}
