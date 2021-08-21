using System;
using System.Collections.Generic;
using System.Text;
using GolangAssistant.StaticValues;

namespace GolangAssistant.Tools
{
    public class TemplateManager
    {
        /// <summary>
        /// 
        /// </summary>
        public static string CreateBasicTemplate(string headerPackageName)
        {
            string basicTemplate = $@"
{StaticTextNames.Package} {headerPackageName}

{StaticTextNames.ImportFmt}

func main() {StaticOperatorSymbols.OpenBracket}
{StaticOperatorSymbols.OneTab}fmt.Println({StaticTextNames.WelcomeMessage})
{StaticOperatorSymbols.CloseBracket}
            ";

            return basicTemplate;
        }
    }
}
