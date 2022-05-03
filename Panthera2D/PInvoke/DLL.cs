using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Panthera2D.Native
{
    public static class DLL
    {
        #region DllImport
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string filename);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procname);

        [DllImport("kernel32.dll")]
        private static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        [DllImport("libdl.so")]
        private static extern IntPtr dlopen(string filename, int flags);

        [DllImport("libdl.so")]
        private static extern IntPtr dlsym(IntPtr handle, string symbol);

        [DllImport("libc.so.6")]
        private static extern void memcpy(IntPtr dest, IntPtr src, uint n);

        const int RTLD_NOW = 2;
        #endregion

        #region Abstracted
        private static bool _linuxset = false;
        private static bool _linux = false;

        public static bool __linux__
        {
            get
            {
                if (!_linuxset)
                {
                    int p = (int)Environment.OSVersion.Platform;
                    _linux = (p == 4) || (p == 6) || (p == 128);
                    _linuxset = true;
                }

                return _linux;
            }
        }
        #endregion

        #region Fields
        private static Type _delegateType = typeof(MulticastDelegate);
        #endregion

        #region Methods
        public static IntPtr Load(string filename)
        {
            IntPtr mHnd;

            if (__linux__)
                mHnd = dlopen(filename, RTLD_NOW);
            else
                mHnd = LoadLibrary(filename);

            if (mHnd != IntPtr.Zero)
                Console.WriteLine("Linked '{0}' -> '0x{1}'", filename, mHnd.ToString("X"));
            else
                Console.WriteLine("Failed to link '{0}'", filename);

            return mHnd;
        }

        public static IntPtr csglDllSymbol(IntPtr mHnd, string symbol)
        {
            IntPtr symPtr;

            if (__linux__)
                symPtr = dlsym(mHnd, symbol);
            else
                symPtr = GetProcAddress(mHnd, symbol);

            return symPtr;
        }

        public static Delegate csglDllDelegate(Type delegateType, IntPtr mHnd, string symbol)
        {
            IntPtr ptrSym = csglDllSymbol(mHnd, symbol);
            return Marshal.GetDelegateForFunctionPointer(ptrSym, delegateType);
        }

        public static void LinkAllDelegates(Type ofType, IntPtr mHnd)
        {
            FieldInfo[] fields = ofType.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo fi in fields)
            {
                if (fi.FieldType.BaseType == _delegateType)
                {
                    IntPtr ptr = csglDllSymbol(mHnd, fi.Name);

                    if (ptr != IntPtr.Zero)
                        fi.SetValue(null, Marshal.GetDelegateForFunctionPointer(ptr, fi.FieldType));
                    else
                        Console.WriteLine("Could not resolve '{0}' in loaded assembly '0x{1}'.", fi.Name, mHnd.ToString("X"));
                }
            }
        }

        public static void csglMemcpy(IntPtr dest, IntPtr source, uint count)
        {
            if (__linux__)
                memcpy(dest, source, count);
            else
                CopyMemory(dest, source, count);
        }
        #endregion
    }
}