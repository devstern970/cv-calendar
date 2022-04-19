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

namespace ImageMagick
{
    internal partial class PixelCollection : IDisposable
    {
        [SuppressUnmanagedCodeSecurity]
        private static unsafe class NativeMethods
        {
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            public static class X64
            {
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_Create(IntPtr image, out IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PixelCollection_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_GetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, out IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PixelCollection_SetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, QuantumType* values, UIntPtr length, out IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_ToByteArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_ToShortArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);
            }
            #endif
            #if PLATFORM_arm64 || PLATFORM_AnyCPU
            public static class ARM64
            {
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_Create(IntPtr image, out IntPtr exception);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PixelCollection_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_GetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, out IntPtr exception);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PixelCollection_SetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, QuantumType* values, UIntPtr length, out IntPtr exception);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_ToByteArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);
                [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_ToShortArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_Create(IntPtr image, out IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PixelCollection_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_GetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, out IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PixelCollection_SetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, QuantumType* values, UIntPtr length, out IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_ToByteArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_ToShortArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);
            }
            #endif
        }
        private NativePixelCollection _nativeInstance;
        private unsafe sealed partial class NativePixelCollection : NativeInstance
        {
            static NativePixelCollection() { Environment.Initialize(); }
            protected override void Dispose(IntPtr instance)
            {
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                NativeMethods.ARM64.PixelCollection_Dispose(instance);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.PixelCollection_Dispose(instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.PixelCollection_Dispose(instance);
                #endif
            }
            public NativePixelCollection(IMagickImage? image)
            {
                IntPtr exception = IntPtr.Zero;
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                Instance = NativeMethods.ARM64.PixelCollection_Create(MagickImage.GetInstance(image), out exception);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                Instance = NativeMethods.X64.PixelCollection_Create(MagickImage.GetInstance(image), out exception);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                Instance = NativeMethods.X86.PixelCollection_Create(MagickImage.GetInstance(image), out exception);
                #endif
                CheckException(exception, Instance);
                if (Instance == IntPtr.Zero)
                    throw new InvalidOperationException();
            }
            protected override string TypeName
            {
                get
                {
                    return nameof(PixelCollection);
                }
            }
            public IntPtr GetArea(int x, int y, int width, int height)
            {
                IntPtr exception = IntPtr.Zero;
                IntPtr result;
                #if PLATFORM_AnyCPU
                if (OperatingSystem.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.PixelCollection_GetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, out exception);
                #endif
                #if PLATFORM_AnyCPU
                else if (OperatingSystem.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.PixelCollection_GetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, out exception);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.PixelCollection_GetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, out exception);
                #endif
                CheckException(exception);
                return result;
            }
            public void SetArea(int x, int y, int width, int height, QuantumType[] values, int length)
            {
                fixed (QuantumType* valuesFixed = values)
                {
                    IntPtr exception = IntPtr.Zero;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.PixelCollection_SetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, valuesFixed, (UIntPtr)length, out exception);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.PixelCollection_SetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, valuesFixed, (UIntPtr)length, out exception);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.PixelCollection_SetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, valuesFixed, (UIntPtr)length, out exception);
                    #endif
                    CheckException(exception);
                }
            }
            #if NETSTANDARD2_1
            public void SetArea(int x, int y, int width, int height, ReadOnlySpan<QuantumType> values, int length)
            {
                fixed (QuantumType* valuesFixed = values)
                {
                    IntPtr exception = IntPtr.Zero;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    NativeMethods.ARM64.PixelCollection_SetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, valuesFixed, (UIntPtr)length, out exception);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.PixelCollection_SetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, valuesFixed, (UIntPtr)length, out exception);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.PixelCollection_SetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, valuesFixed, (UIntPtr)length, out exception);
                    #endif
                    CheckException(exception);
                }
            }
            #endif
            public IntPtr ToByteArray(int x, int y, int width, int height, string? mapping)
            {
                using (var mappingNative = UTF8Marshaler.CreateInstance(mapping))
                {
                    IntPtr exception = IntPtr.Zero;
                    IntPtr result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.PixelCollection_ToByteArray(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, mappingNative.Instance, out exception);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.PixelCollection_ToByteArray(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, mappingNative.Instance, out exception);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.PixelCollection_ToByteArray(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, mappingNative.Instance, out exception);
                    #endif
                    var magickException = MagickExceptionHelper.Create(exception);
                    if (magickException is null)
                        return result;
                    if (magickException is MagickErrorException)
                    {
                        if (result != IntPtr.Zero)
                            MagickMemory.Relinquish(result);
                        throw magickException;
                    }
                    RaiseWarning(magickException);
                    return result;
                }
            }
            public IntPtr ToShortArray(int x, int y, int width, int height, string? mapping)
            {
                using (var mappingNative = UTF8Marshaler.CreateInstance(mapping))
                {
                    IntPtr exception = IntPtr.Zero;
                    IntPtr result;
                    #if PLATFORM_AnyCPU
                    if (OperatingSystem.IsArm64)
                    #endif
                    #if PLATFORM_arm64 || PLATFORM_AnyCPU
                    result = NativeMethods.ARM64.PixelCollection_ToShortArray(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, mappingNative.Instance, out exception);
                    #endif
                    #if PLATFORM_AnyCPU
                    else if (OperatingSystem.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.PixelCollection_ToShortArray(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, mappingNative.Instance, out exception);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.PixelCollection_ToShortArray(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, mappingNative.Instance, out exception);
                    #endif
                    var magickException = MagickExceptionHelper.Create(exception);
                    if (magickException is null)
                        return result;
                    if (magickException is MagickErrorException)
                    {
                        if (result != IntPtr.Zero)
                            MagickMemory.Relinquish(result);
                        throw magickException;
                    }
                    RaiseWarning(magickException);
                    return result;
                }
            }
        }
    }
}
