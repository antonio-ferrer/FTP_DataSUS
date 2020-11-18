using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace br.com.teczilla.datasus.services
{
    public static class UFs
    {
        public const string AC = "AC";
        public const string AL = "AL";
        public const string AP = "AP";
        public const string AM = "AM";
        public const string BA = "BA";
        public const string CE = "CE";
        public const string DF = "DF";
        public const string ES = "ES";
        public const string GO = "GO";
        public const string MA = "MA"
            ;
        public const string MT = "MT";
        public const string MS = "MS";
        public const string MG = "MG";
        public const string PA = "PA";
        public const string PB = "PB";
        public const string PR = "PR";
        public const string PE = "PE";
        public const string PI = "PI";
        public const string RJ = "RJ";
        public const string RN = "RN";
        public const string RS = "RS";
        
        public const string RO = "RO";
        public const string RR = "RR";
        public const string SC = "SC";
        public const string SP = "SP";
        public const string SE = "SE";
        public const string TO = "TO";

        public const string BRASIL = "BR";

        public const int UF_Count = 26;

        private static readonly Regex _rxUF;

        private static readonly string[] _UFs;

        static UFs()
        {
            _UFs = typeof(UFs).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
                .Select(x => (string)x.GetRawConstantValue())
                .ToArray();
            StringBuilder sb = new StringBuilder();
            sb.Append("(?<uf>(");
            foreach (string uf in _UFs)
                sb.Append(uf).Append("|");
            sb.Length--;
            sb.Append("))");
            _rxUF = new Regex(sb.ToString(), RegexOptions.IgnoreCase);
        }

        public static string[] GetUFs()
        {
            return _UFs.Where(uf=>uf != BRASIL).ToArray();
        }

        public static string GetUF(string text)
        {
            return _rxUF.Match(text)?.Groups["uf"]?.Value ?? "";
        }
    }
}
