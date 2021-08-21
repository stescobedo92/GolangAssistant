using System;
using System.Collections.Generic;
using System.Text;

namespace GolangAssistant.StaticValues
{
    public class StaticTextNames
    {
        /// <summary>
        /// 
        /// </summary>
        public static string Package = "package";
        /// <summary>
        /// 
        /// </summary>
        public static string Source = "src";
        /// <summary>
        /// 
        /// </summary>
        public static string Extention = ".go";
        /// <summary>
        /// 
        /// </summary>
        public static string ImportFmt = $"import {StaticOperatorSymbols.Quote}fmt{StaticOperatorSymbols.Quote}";
        /// <summary>
        /// 
        /// </summary>
        public static string WelcomeMessage = $"{StaticOperatorSymbols.Quote}Hello from Golang!.{StaticOperatorSymbols.Quote}";
    }
}
