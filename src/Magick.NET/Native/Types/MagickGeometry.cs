// Copyright 2013-2019 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.
// <auto-generated/>

using System;
using System.Security;
using System.Diagnostics.CodeAnalysis;
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
    public partial class MagickGeometry
    {
        #if !NETSTANDARD1_3
        [SuppressUnmanagedCodeSecurity]
        #endif
        private static class NativeMethods
        {
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            public static class X64
            {
                #if PLATFORM_AnyCPU
                static X64() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickGeometry_Create();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickGeometry_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double MagickGeometry_X_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double MagickGeometry_Y_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double MagickGeometry_Width_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double MagickGeometry_Height_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickGeometry_Initialize(IntPtr Instance, IntPtr value);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                #if PLATFORM_AnyCPU
                static X86() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickGeometry_Create();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickGeometry_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double MagickGeometry_X_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double MagickGeometry_Y_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double MagickGeometry_Width_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern double MagickGeometry_Height_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern UIntPtr MagickGeometry_Initialize(IntPtr Instance, IntPtr value);
            }
            #endif
        }
        private sealed class NativeMagickGeometry : NativeInstance
        {
            static NativeMagickGeometry() { Environment.Initialize(); }
            protected override void Dispose(IntPtr instance)
            {
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.MagickGeometry_Dispose(instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.MagickGeometry_Dispose(instance);
                #endif
            }
            public NativeMagickGeometry()
            {
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                Instance = NativeMethods.X64.MagickGeometry_Create();
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                Instance = NativeMethods.X86.MagickGeometry_Create();
                #endif
                if (Instance == IntPtr.Zero)
                    throw new InvalidOperationException();
            }
            public NativeMagickGeometry(IntPtr instance)
            {
                Instance = instance;
            }
            protected override string TypeName
            {
                get
                {
                    return nameof(MagickGeometry);
                }
            }
            public double X
            {
                get
                {
                    double result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickGeometry_X_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickGeometry_X_Get(Instance);
                    #endif
                    return result;
                }
            }
            public double Y
            {
                get
                {
                    double result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickGeometry_Y_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickGeometry_Y_Get(Instance);
                    #endif
                    return result;
                }
            }
            public double Width
            {
                get
                {
                    double result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickGeometry_Width_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickGeometry_Width_Get(Instance);
                    #endif
                    return result;
                }
            }
            public double Height
            {
                get
                {
                    double result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickGeometry_Height_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickGeometry_Height_Get(Instance);
                    #endif
                    return result;
                }
            }
            public GeometryFlags Initialize(string value)
            {
                using (INativeInstance valueNative = UTF8Marshaler.CreateInstance(value))
                {
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    return (GeometryFlags)NativeMethods.X64.MagickGeometry_Initialize(Instance, valueNative.Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    return (GeometryFlags)NativeMethods.X86.MagickGeometry_Initialize(Instance, valueNative.Instance);
                    #endif
                }
            }
        }
        internal static MagickGeometry CreateInstance(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return null;
            using (NativeMagickGeometry nativeInstance = new NativeMagickGeometry(instance))
            {
                return new MagickGeometry(nativeInstance);
            }
        }
    }
}
