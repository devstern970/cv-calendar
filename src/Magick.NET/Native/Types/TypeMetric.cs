// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.
// <auto-generated/>
#nullable enable

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace ImageMagick;

public partial class TypeMetric
{
    [SuppressUnmanagedCodeSecurity]
    private static unsafe class NativeMethods
    {
        #if PLATFORM_x64 || PLATFORM_AnyCPU
        public static class X64
        {
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void TypeMetric_Dispose(IntPtr instance);
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_Ascent_Get(IntPtr instance);
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_Descent_Get(IntPtr instance);
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_MaxHorizontalAdvance_Get(IntPtr instance);
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_TextHeight_Get(IntPtr instance);
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_TextWidth_Get(IntPtr instance);
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_UnderlinePosition_Get(IntPtr instance);
            [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_UnderlineThickness_Get(IntPtr instance);
        }
        #endif
        #if PLATFORM_arm64 || PLATFORM_AnyCPU
        public static class ARM64
        {
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void TypeMetric_Dispose(IntPtr instance);
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_Ascent_Get(IntPtr instance);
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_Descent_Get(IntPtr instance);
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_MaxHorizontalAdvance_Get(IntPtr instance);
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_TextHeight_Get(IntPtr instance);
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_TextWidth_Get(IntPtr instance);
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_UnderlinePosition_Get(IntPtr instance);
            [DllImport(NativeLibrary.ARM64Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_UnderlineThickness_Get(IntPtr instance);
        }
        #endif
        #if PLATFORM_x86 || PLATFORM_AnyCPU
        public static class X86
        {
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern void TypeMetric_Dispose(IntPtr instance);
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_Ascent_Get(IntPtr instance);
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_Descent_Get(IntPtr instance);
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_MaxHorizontalAdvance_Get(IntPtr instance);
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_TextHeight_Get(IntPtr instance);
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_TextWidth_Get(IntPtr instance);
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_UnderlinePosition_Get(IntPtr instance);
            [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern double TypeMetric_UnderlineThickness_Get(IntPtr instance);
        }
        #endif
    }
    private unsafe sealed partial class NativeTypeMetric : NativeInstance
    {
        static NativeTypeMetric() { Environment.Initialize(); }
        protected override void Dispose(IntPtr instance)
        {
            DisposeInstance(instance);
        }
        public static void DisposeInstance(IntPtr instance)
        {
            #if PLATFORM_AnyCPU
            if (Runtime.Is64Bit)
            #endif
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            NativeMethods.X64.TypeMetric_Dispose(instance);
            #endif
            #if PLATFORM_AnyCPU
            else if (Runtime.IsArm64)
            #endif
            #if PLATFORM_arm64 || PLATFORM_AnyCPU
            NativeMethods.ARM64.TypeMetric_Dispose(instance);
            #endif
            #if PLATFORM_AnyCPU
            else
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            NativeMethods.X86.TypeMetric_Dispose(instance);
            #endif
        }
        public NativeTypeMetric(IntPtr instance)
        {
            Instance = instance;
        }
        protected override string TypeName
        {
            get
            {
                return nameof(TypeMetric);
            }
        }
        public double Ascent
        {
            get
            {
                double result;
                #if PLATFORM_AnyCPU
                if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.TypeMetric_Ascent_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.TypeMetric_Ascent_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.TypeMetric_Ascent_Get(Instance);
                #endif
                return result;
            }
        }
        public double Descent
        {
            get
            {
                double result;
                #if PLATFORM_AnyCPU
                if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.TypeMetric_Descent_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.TypeMetric_Descent_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.TypeMetric_Descent_Get(Instance);
                #endif
                return result;
            }
        }
        public double MaxHorizontalAdvance
        {
            get
            {
                double result;
                #if PLATFORM_AnyCPU
                if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.TypeMetric_MaxHorizontalAdvance_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.TypeMetric_MaxHorizontalAdvance_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.TypeMetric_MaxHorizontalAdvance_Get(Instance);
                #endif
                return result;
            }
        }
        public double TextHeight
        {
            get
            {
                double result;
                #if PLATFORM_AnyCPU
                if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.TypeMetric_TextHeight_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.TypeMetric_TextHeight_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.TypeMetric_TextHeight_Get(Instance);
                #endif
                return result;
            }
        }
        public double TextWidth
        {
            get
            {
                double result;
                #if PLATFORM_AnyCPU
                if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.TypeMetric_TextWidth_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.TypeMetric_TextWidth_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.TypeMetric_TextWidth_Get(Instance);
                #endif
                return result;
            }
        }
        public double UnderlinePosition
        {
            get
            {
                double result;
                #if PLATFORM_AnyCPU
                if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.TypeMetric_UnderlinePosition_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.TypeMetric_UnderlinePosition_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.TypeMetric_UnderlinePosition_Get(Instance);
                #endif
                return result;
            }
        }
        public double UnderlineThickness
        {
            get
            {
                double result;
                #if PLATFORM_AnyCPU
                if (Runtime.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.TypeMetric_UnderlineThickness_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else if (Runtime.IsArm64)
                #endif
                #if PLATFORM_arm64 || PLATFORM_AnyCPU
                result = NativeMethods.ARM64.TypeMetric_UnderlineThickness_Get(Instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.TypeMetric_UnderlineThickness_Get(Instance);
                #endif
                return result;
            }
        }
    }
    internal static ITypeMetric? CreateInstance(IntPtr instance)
    {
        if (instance == IntPtr.Zero)
            return null;
        using NativeTypeMetric nativeInstance = new NativeTypeMetric(instance);
        return new TypeMetric(nativeInstance);
    }
}
