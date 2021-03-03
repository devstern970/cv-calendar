// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace ImageMagick
{
    internal partial class PointInfoCollection : IDisposable
    {
        [SuppressUnmanagedCodeSecurity]
        private static class NativeMethods
        {
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            public static class X64
            {
                #if PLATFORM_AnyCPU
                static X64() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PointInfoCollection_Create(UIntPtr length);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PointInfoCollection_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double PointInfoCollection_GetX(IntPtr Instance, UIntPtr index);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double PointInfoCollection_GetY(IntPtr Instance, UIntPtr index);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PointInfoCollection_Set(IntPtr Instance, UIntPtr index, double x, double y);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                #if PLATFORM_AnyCPU
                static X86() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PointInfoCollection_Create(UIntPtr length);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PointInfoCollection_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double PointInfoCollection_GetX(IntPtr Instance, UIntPtr index);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double PointInfoCollection_GetY(IntPtr Instance, UIntPtr index);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PointInfoCollection_Set(IntPtr Instance, UIntPtr index, double x, double y);
            }
            #endif
        }
        private NativePointInfoCollection _nativeInstance;
        private sealed class NativePointInfoCollection : NativeInstance
        {
            static NativePointInfoCollection() { Environment.Initialize(); }
            protected override void Dispose(IntPtr instance)
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.PointInfoCollection_Dispose(instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.PointInfoCollection_Dispose(instance);
                #endif
            }
            public NativePointInfoCollection(int length)
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                Instance = NativeMethods.X64.PointInfoCollection_Create((UIntPtr)length);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                Instance = NativeMethods.X86.PointInfoCollection_Create((UIntPtr)length);
                #endif
                if (Instance == IntPtr.Zero)
                    throw new InvalidOperationException();
            }
            public NativePointInfoCollection(IntPtr instance)
            {
                Instance = instance;
            }
            protected override string TypeName
            {
                get
                {
                    return nameof(PointInfoCollection);
                }
            }
            public double GetX(int index)
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                return NativeMethods.X64.PointInfoCollection_GetX(Instance, (UIntPtr)index);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                return NativeMethods.X86.PointInfoCollection_GetX(Instance, (UIntPtr)index);
                #endif
            }
            public double GetY(int index)
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                return NativeMethods.X64.PointInfoCollection_GetY(Instance, (UIntPtr)index);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                return NativeMethods.X86.PointInfoCollection_GetY(Instance, (UIntPtr)index);
                #endif
            }
            public void Set(int index, double x, double y)
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.PointInfoCollection_Set(Instance, (UIntPtr)index, x, y);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.PointInfoCollection_Set(Instance, (UIntPtr)index, x, y);
                #endif
            }
        }
    }
}
