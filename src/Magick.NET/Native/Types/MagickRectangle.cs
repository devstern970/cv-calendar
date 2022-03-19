// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace ImageMagick
{
    internal partial class MagickRectangle
    {
        [SuppressUnmanagedCodeSecurity]
        private static unsafe class NativeMethods
        {
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            public static class X64
            {
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_Create();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_X_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_X_Set(IntPtr instance, IntPtr value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_Y_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Y_Set(IntPtr instance, IntPtr value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickRectangle_Width_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Width_Set(IntPtr instance, UIntPtr value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickRectangle_Height_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Height_Set(IntPtr instance, UIntPtr value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_FromPageSize(IntPtr value);
            }
            #endif
            #if PLATFORM_arm64 || PLATFORM_AnyCPU
            public static class ARM64
            {
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_Create();
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_X_Get(IntPtr instance);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_X_Set(IntPtr instance, IntPtr value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_Y_Get(IntPtr instance);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Y_Set(IntPtr instance, IntPtr value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickRectangle_Width_Get(IntPtr instance);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Width_Set(IntPtr instance, UIntPtr value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickRectangle_Height_Get(IntPtr instance);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Height_Set(IntPtr instance, UIntPtr value);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_FromPageSize(IntPtr value);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_Create();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_X_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_X_Set(IntPtr instance, IntPtr value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_Y_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Y_Set(IntPtr instance, IntPtr value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickRectangle_Width_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Width_Set(IntPtr instance, UIntPtr value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickRectangle_Height_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickRectangle_Height_Set(IntPtr instance, UIntPtr value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickRectangle_FromPageSize(IntPtr value);
            }
            #endif
        }
        private unsafe sealed partial class NativeMagickRectangle : NativeInstance
        {
            static NativeMagickRectangle() { Environment.Initialize(); }
            protected override void Dispose(IntPtr instance)
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.MagickRectangle_Dispose(instance);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.MagickRectangle_Dispose(instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.MagickRectangle_Dispose(instance);
                #endif
            }
            public NativeMagickRectangle()
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                Instance = NativeMethods.ARM64.MagickRectangle_Create();
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                Instance = NativeMethods.X64.MagickRectangle_Create();
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                Instance = NativeMethods.X86.MagickRectangle_Create();
                #endif
                if (Instance == IntPtr.Zero)
                    throw new InvalidOperationException();
            }
            public NativeMagickRectangle(IntPtr instance)
            {
                Instance = instance;
            }
            protected override string TypeName
            {
                get
                {
                    return nameof(MagickRectangle);
                }
            }
            public int X
            {
                get
                {
                    IntPtr result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.MagickRectangle_X_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickRectangle_X_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickRectangle_X_Get(Instance);
                    #endif
                    return (int)result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.MagickRectangle_X_Set(Instance, (IntPtr)value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.MagickRectangle_X_Set(Instance, (IntPtr)value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.MagickRectangle_X_Set(Instance, (IntPtr)value);
                    #endif
                }
            }
            public int Y
            {
                get
                {
                    IntPtr result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.MagickRectangle_Y_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickRectangle_Y_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickRectangle_Y_Get(Instance);
                    #endif
                    return (int)result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.MagickRectangle_Y_Set(Instance, (IntPtr)value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.MagickRectangle_Y_Set(Instance, (IntPtr)value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.MagickRectangle_Y_Set(Instance, (IntPtr)value);
                    #endif
                }
            }
            public int Width
            {
                get
                {
                    UIntPtr result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.MagickRectangle_Width_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickRectangle_Width_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickRectangle_Width_Get(Instance);
                    #endif
                    return (int)result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.MagickRectangle_Width_Set(Instance, (UIntPtr)value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.MagickRectangle_Width_Set(Instance, (UIntPtr)value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.MagickRectangle_Width_Set(Instance, (UIntPtr)value);
                    #endif
                }
            }
            public int Height
            {
                get
                {
                    UIntPtr result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.MagickRectangle_Height_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickRectangle_Height_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickRectangle_Height_Get(Instance);
                    #endif
                    return (int)result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.MagickRectangle_Height_Set(Instance, (UIntPtr)value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.MagickRectangle_Height_Set(Instance, (UIntPtr)value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.MagickRectangle_Height_Set(Instance, (UIntPtr)value);
                    #endif
                }
            }
            public static MagickRectangle? FromPageSize(string? value)
            {
                using (var valueNative = UTF8Marshaler.CreateInstance(value))
                {
                    IntPtr result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.MagickRectangle_FromPageSize(valueNative.Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickRectangle_FromPageSize(valueNative.Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickRectangle_FromPageSize(valueNative.Instance);
                    #endif
                    return MagickRectangle.CreateInstance(result);
                }
            }
        }
        internal static INativeInstance CreateInstance(MagickRectangle? instance)
        {
            if (instance == null)
                return NativeInstance.Zero;
            return instance.CreateNativeInstance();
        }
        internal static MagickRectangle? CreateInstance(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return null;
            using (NativeMagickRectangle nativeInstance = new NativeMagickRectangle(instance))
            {
                return new MagickRectangle(nativeInstance);
            }
        }
    }
}
