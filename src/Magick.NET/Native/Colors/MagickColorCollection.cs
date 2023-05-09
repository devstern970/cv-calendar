// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal static partial class MagickColorCollection
{
    [SuppressUnmanagedCodeSecurity]
    private static unsafe class NativeMethods
    {
        #if PLATFORM_x64 || PLATFORM_AnyCPU
        public static class X64
        {
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void MagickColorCollection_DisposeList(IntPtr list);
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr MagickColorCollection_GetInstance(IntPtr list, UIntPtr index);
        }
        #endif
        #if PLATFORM_arm64 || PLATFORM_AnyCPU
        public static class ARM64
        {
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void MagickColorCollection_DisposeList(IntPtr list);
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr MagickColorCollection_GetInstance(IntPtr list, UIntPtr index);
        }
        #endif
        #if PLATFORM_x86 || PLATFORM_AnyCPU
        public static class X86
        {
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void MagickColorCollection_DisposeList(IntPtr list);
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr MagickColorCollection_GetInstance(IntPtr list, UIntPtr index);
        }
        #endif
    }
    private unsafe static class NativeMagickColorCollection
    {
        static NativeMagickColorCollection() { Environment.Initialize(); }
        public static void DisposeList(IntPtr list)
        {
            #if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
            #endif
            #if PLATFORM_arm64 || PLATFORM_AnyCPU
            NativeMethods.ARM64.MagickColorCollection_DisposeList(list);
            #endif
            #if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
            #endif
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            NativeMethods.X64.MagickColorCollection_DisposeList(list);
            #endif
            #if PLATFORM_AnyCPU
            else
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            NativeMethods.X86.MagickColorCollection_DisposeList(list);
            #endif
        }
        public static IntPtr GetInstance(IntPtr list, int index)
        {
            IntPtr result;
            #if PLATFORM_AnyCPU
            if (Runtime.IsArm64)
            #endif
            #if PLATFORM_arm64 || PLATFORM_AnyCPU
            result = NativeMethods.ARM64.MagickColorCollection_GetInstance(list, (UIntPtr)index);
            #endif
            #if PLATFORM_AnyCPU
            else if (Runtime.Is64Bit)
            #endif
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            result = NativeMethods.X64.MagickColorCollection_GetInstance(list, (UIntPtr)index);
            #endif
            #if PLATFORM_AnyCPU
            else
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            result = NativeMethods.X86.MagickColorCollection_GetInstance(list, (UIntPtr)index);
            #endif
            return result;
        }
    }
}
