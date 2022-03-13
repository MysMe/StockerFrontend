﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StockerFrontend.Natives
{
    public class OutstandingTranslation
    {
        public uint UnifiedIndex = 0;
        public uint CountIndex = 0;
    }

    public class UnifiedEntry
    {

        public enum status
        {
            normal,
            confirmed,
            recount,
            critical
        }

        public string Name = "";
        public string Size = "";
        private float Count = 0;
        private float Variance = 0;
        public bool isHidden = false;
        public status Status = status.normal;
        public string notes = "";

        public float Transferred = 0;
        public float Delivered = 0;

        public float GetCount()
        {
            return Count;
        }

        public float GetExpected()
        {
            return Count - Variance + Delivered - Transferred;
        }

        public float GetVariance()
        {
            return GetCount() - GetExpected();
        }

        public UnifiedEntry(UnifiedTable table, uint index)
        {
            Name = table.GetName(index);
            Size = table.GetSize(index);
            Count = table.GetCount(index);
            Variance = table.GetVariance(index);
        }
    }

    public class UnifiedTable
    {

        [DllImport("Stocker.dll")]
        private static extern IntPtr unifiedTable_new();

        [DllImport("Stocker.dll")]
        private static extern void unifiedTable_delete(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern int unifiedTable_load(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string XLS, IntPtr count);



        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_loadTranslations(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string file);

        [DllImport("Stocker.dll")]
        private static extern void unifiedTable_saveTranslations(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string file);



        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_ready(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern uint unifiedTable_getOutstandingCount(IntPtr table);

        [DllImport("Stocker.dll")]
        private static extern uint unifiedTable_getTranslationUnifiedIndex(IntPtr table, uint index);
        [DllImport("Stocker.dll")]
        private static extern uint unifiedTable_getTranslationUnmatchedIndex(IntPtr table, uint index);

        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_provideTranslation(IntPtr table, uint index, float ratio, IntPtr stockTable);

        [DllImport("Stocker.dll")]
        private static extern void unifiedTable_applyTranslations(IntPtr table, IntPtr stockTable);



        [DllImport("Stocker.dll")]
        private static extern uint unifiedTable_entryCount(IntPtr table);

        [DllImport("Stocker.dll", CharSet = CharSet.Ansi)] //Returns a char*
        private static extern IntPtr unifiedTable_getName(IntPtr table, uint index);

        [DllImport("Stocker.dll", CharSet = CharSet.Ansi)] //Returns a char*
        private static extern IntPtr unifiedTable_getSize(IntPtr table, uint index);

        [DllImport("Stocker.dll")]
        private static extern float unifiedTable_getVariance(IntPtr table, uint index);


        [DllImport("Stocker.dll")]
        private static extern float unifiedTable_getUnifiedCount(IntPtr table, uint index);



        [DllImport("Stocker.dll")]
        private static extern bool unifiedTable_hasTranslation(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string product);


        [DllImport("Stocker.dll")]
        private static extern float unifiedTable_getTranslationFromName(IntPtr table, [MarshalAs(UnmanagedType.LPStr)] string product);

        private IntPtr table = IntPtr.Zero;

        public UnifiedTable()
        {
            table = unifiedTable_new();
        }

        public int load(string XLSSource, StockCountTable count)
        {
            return unifiedTable_load(table, XLSSource, count.Ptr());
        }

        public string GetNameSize(uint index)
        {
            return Marshal.PtrToStringAnsi(unifiedTable_getName(table, index)) +
                Marshal.PtrToStringAnsi(unifiedTable_getSize(table, index));
        }

        public bool HasTranslation(string product)
        {
            return unifiedTable_hasTranslation(table, product);
        }

        public float GetTranslation(string product)
        {
            return unifiedTable_getTranslationFromName(table, product);
        }

        public uint GetTranslationCount()
        {
            return unifiedTable_getOutstandingCount(table);
        }

        public void ApplyTranslations(IntPtr count)
        {
            unifiedTable_applyTranslations(table, count);
        }

        public bool ProvideTranslation(uint index, float ratio, IntPtr stockTable)
        {
            return unifiedTable_provideTranslation(table, index, ratio, stockTable);
        }

        public bool Ready()
        {
            return unifiedTable_ready(table);
        }

        public OutstandingTranslation GetTranslation(uint index)
        {
            OutstandingTranslation ret = new OutstandingTranslation();
            ret.UnifiedIndex = unifiedTable_getTranslationUnifiedIndex(table, index);
            ret.CountIndex = unifiedTable_getTranslationUnmatchedIndex(table, index);
            return ret;
        }

        public bool LoadTranslations(string file)
        {
            return unifiedTable_loadTranslations(table, file);
        }

        public void SaveTranslations(string file)
        {
            unifiedTable_saveTranslations(table, file);
        }

        public uint Count()
        {
            return unifiedTable_entryCount(table);
        }

        public string GetName(uint index)
        {
            string? ret = Marshal.PtrToStringAnsi(unifiedTable_getName(table, index));
            if (ret == null)
                return "";
            return ret;
        }
        public string GetSize(uint index)
        {
            string? ret = Marshal.PtrToStringAnsi(unifiedTable_getSize(table, index));
            if (ret == null)
                return "";
            return ret;
        }
        public float GetCount(uint index)
        {
            return unifiedTable_getUnifiedCount(table, index);
        }

        public float GetVariance(uint index)
        {
            return unifiedTable_getVariance(table, index);
        }

        public UnifiedEntry Get(uint index)
        {
            return new UnifiedEntry(this, index);
        }

        ~UnifiedTable()
        {
            unifiedTable_delete(table);
        }

        public IntPtr Ptr()
        {
            return table;
        }

    }
}