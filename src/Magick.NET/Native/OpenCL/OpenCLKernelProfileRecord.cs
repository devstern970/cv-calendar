// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace ImageMagick
{
    public partial class OpenCLKernelProfileRecord
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
                public static extern long OpenCLKernelProfileRecord_Count_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern long OpenCLKernelProfileRecord_MaximumDuration_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern long OpenCLKernelProfileRecord_MinimumDuration_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr OpenCLKernelProfileRecord_Name_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern long OpenCLKernelProfileRecord_TotalDuration_Get(IntPtr instance);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                #if PLATFORM_AnyCPU
                static X86() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern long OpenCLKernelProfileRecord_Count_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern long OpenCLKernelProfileRecord_MaximumDuration_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern long OpenCLKernelProfileRecord_MinimumDuration_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr OpenCLKernelProfileRecord_Name_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern long OpenCLKernelProfileRecord_TotalDuration_Get(IntPtr instance);
            }
            #endif
        }
        private sealed class NativeOpenCLKernelProfileRecord : ConstNativeInstance
        {
            static NativeOpenCLKernelProfileRecord() { Environment.Initialize(); }
            protected override string TypeName
            {
                get
                {
                    return nameof(OpenCLKernelProfileRecord);
                }
            }
            public long Count
            {
                get
                {
                    long result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.OpenCLKernelProfileRecord_Count_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.OpenCLKernelProfileRecord_Count_Get(Instance);
                    #endif
                    return result;
                }
            }
            public long MaximumDuration
            {
                get
                {
                    long result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.OpenCLKernelProfileRecord_MaximumDuration_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.OpenCLKernelProfileRecord_MaximumDuration_Get(Instance);
                    #endif
                    return result;
                }
            }
            public long MinimumDuration
            {
                get
                {
                    long result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.OpenCLKernelProfileRecord_MinimumDuration_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.OpenCLKernelProfileRecord_MinimumDuration_Get(Instance);
                    #endif
                    return result;
                }
            }
            public string? Name
            {
                get
                {
                    IntPtr result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.OpenCLKernelProfileRecord_Name_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.OpenCLKernelProfileRecord_Name_Get(Instance);
                    #endif
                    return UTF8Marshaler.NativeToManaged(result);
                }
            }
            public long TotalDuration
            {
                get
                {
                    long result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.OpenCLKernelProfileRecord_TotalDuration_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.OpenCLKernelProfileRecord_TotalDuration_Get(Instance);
                    #endif
                    return result;
                }
            }
        }
    }
}
