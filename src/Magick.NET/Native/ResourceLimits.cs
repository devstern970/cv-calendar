// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace ImageMagick
{
    public static partial class ResourceLimits
    {
        [SuppressUnmanagedCodeSecurity]
        private static unsafe class NativeMethods
        {
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            public static class X64
            {
                #if PLATFORM_AnyCPU
                static X64() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Area_Get();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Area_Set(ulong value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Disk_Get();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Disk_Set(ulong value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Height_Get();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Height_Set(ulong value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_ListLength_Get();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_ListLength_Set(ulong value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Memory_Get();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Memory_Set(ulong value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Thread_Get();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Thread_Set(ulong value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Throttle_Get();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Throttle_Set(ulong value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Width_Get();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Width_Set(ulong value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_LimitMemory(double percentage);
            }
            #endif
            #if PLATFORM_arm64 || PLATFORM_AnyCPU
            public static class ARM64
            {
                #if PLATFORM_AnyCPU
                static ARM64() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Area_Get();
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Area_Set(ulong value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Disk_Get();
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Disk_Set(ulong value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Height_Get();
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Height_Set(ulong value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_ListLength_Get();
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_ListLength_Set(ulong value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Memory_Get();
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Memory_Set(ulong value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Thread_Get();
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Thread_Set(ulong value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Throttle_Get();
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Throttle_Set(ulong value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Width_Get();
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Width_Set(ulong value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_LimitMemory(double percentage);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                #if PLATFORM_AnyCPU
                static X86() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Area_Get();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Area_Set(ulong value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Disk_Get();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Disk_Set(ulong value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Height_Get();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Height_Set(ulong value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_ListLength_Get();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_ListLength_Set(ulong value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Memory_Get();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Memory_Set(ulong value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Thread_Get();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Thread_Set(ulong value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Throttle_Get();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Throttle_Set(ulong value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong ResourceLimits_Width_Get();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_Width_Set(ulong value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void ResourceLimits_LimitMemory(double percentage);
            }
            #endif
        }
        private unsafe static class NativeResourceLimits
        {
            static NativeResourceLimits() { Environment.Initialize(); }
            public static ulong Area
            {
                get
                {
                    ulong result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.ResourceLimits_Area_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.ResourceLimits_Area_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.ResourceLimits_Area_Get();
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.ResourceLimits_Area_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.ResourceLimits_Area_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.ResourceLimits_Area_Set(value);
                    #endif
                }
            }
            public static ulong Disk
            {
                get
                {
                    ulong result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.ResourceLimits_Disk_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.ResourceLimits_Disk_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.ResourceLimits_Disk_Get();
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.ResourceLimits_Disk_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.ResourceLimits_Disk_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.ResourceLimits_Disk_Set(value);
                    #endif
                }
            }
            public static ulong Height
            {
                get
                {
                    ulong result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.ResourceLimits_Height_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.ResourceLimits_Height_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.ResourceLimits_Height_Get();
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.ResourceLimits_Height_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.ResourceLimits_Height_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.ResourceLimits_Height_Set(value);
                    #endif
                }
            }
            public static ulong ListLength
            {
                get
                {
                    ulong result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.ResourceLimits_ListLength_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.ResourceLimits_ListLength_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.ResourceLimits_ListLength_Get();
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.ResourceLimits_ListLength_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.ResourceLimits_ListLength_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.ResourceLimits_ListLength_Set(value);
                    #endif
                }
            }
            public static ulong Memory
            {
                get
                {
                    ulong result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.ResourceLimits_Memory_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.ResourceLimits_Memory_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.ResourceLimits_Memory_Get();
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.ResourceLimits_Memory_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.ResourceLimits_Memory_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.ResourceLimits_Memory_Set(value);
                    #endif
                }
            }
            public static ulong Thread
            {
                get
                {
                    ulong result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.ResourceLimits_Thread_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.ResourceLimits_Thread_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.ResourceLimits_Thread_Get();
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.ResourceLimits_Thread_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.ResourceLimits_Thread_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.ResourceLimits_Thread_Set(value);
                    #endif
                }
            }
            public static ulong Throttle
            {
                get
                {
                    ulong result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.ResourceLimits_Throttle_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.ResourceLimits_Throttle_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.ResourceLimits_Throttle_Get();
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.ResourceLimits_Throttle_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.ResourceLimits_Throttle_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.ResourceLimits_Throttle_Set(value);
                    #endif
                }
            }
            public static ulong Width
            {
                get
                {
                    ulong result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.ResourceLimits_Width_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.ResourceLimits_Width_Get();
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.ResourceLimits_Width_Get();
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.ResourceLimits_Width_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.ResourceLimits_Width_Set(value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.ResourceLimits_Width_Set(value);
                    #endif
                }
            }
            public static void LimitMemory(double percentage)
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.ResourceLimits_LimitMemory(percentage);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.ResourceLimits_LimitMemory(percentage);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.ResourceLimits_LimitMemory(percentage);
                #endif
            }
        }
    }
}
