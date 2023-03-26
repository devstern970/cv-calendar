// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace ImageMagick
{
    public partial class ChannelPerceptualHash
    {
        [SuppressUnmanagedCodeSecurity]
        private static unsafe class NativeMethods
        {
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            public static class X64
            {
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double ChannelPerceptualHash_GetSrgbHuPhash(IntPtr Instance, UIntPtr index);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double ChannelPerceptualHash_GetHclpHuPhash(IntPtr Instance, UIntPtr index);
            }
            #endif
            #if PLATFORM_arm64 || PLATFORM_AnyCPU
            public static class ARM64
            {
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double ChannelPerceptualHash_GetSrgbHuPhash(IntPtr Instance, UIntPtr index);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double ChannelPerceptualHash_GetHclpHuPhash(IntPtr Instance, UIntPtr index);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double ChannelPerceptualHash_GetSrgbHuPhash(IntPtr Instance, UIntPtr index);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double ChannelPerceptualHash_GetHclpHuPhash(IntPtr Instance, UIntPtr index);
            }
            #endif
        }
        private unsafe sealed partial class NativeChannelPerceptualHash : ConstNativeInstance
        {
            static NativeChannelPerceptualHash() { Environment.Initialize(); }
            public NativeChannelPerceptualHash(IntPtr instance)
            {
                Instance = instance;
            }
            protected override string TypeName
            {
                get
                {
                    return nameof(ChannelPerceptualHash);
                }
            }
            public double GetSrgbHuPhash(int index)
            {
                double result;
                #if PLATFORM_AnyCPU
                if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.ChannelPerceptualHash_GetSrgbHuPhash(Instance, (UIntPtr)index);
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.ChannelPerceptualHash_GetSrgbHuPhash(Instance, (UIntPtr)index);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.ChannelPerceptualHash_GetSrgbHuPhash(Instance, (UIntPtr)index);
                #endif
                return result;
            }
            public double GetHclpHuPhash(int index)
            {
                double result;
                #if PLATFORM_AnyCPU
                if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.ChannelPerceptualHash_GetHclpHuPhash(Instance, (UIntPtr)index);
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.ChannelPerceptualHash_GetHclpHuPhash(Instance, (UIntPtr)index);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.ChannelPerceptualHash_GetHclpHuPhash(Instance, (UIntPtr)index);
                #endif
                return result;
            }
        }
    }
}
