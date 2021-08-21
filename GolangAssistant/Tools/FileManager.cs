using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GolangAssistant.StaticValues;

namespace GolangAssistant.Tools
{
    public class FileManager
    {
        public static async Task CreateDefaultProject()
        {
            string defaultPath = Directory.GetCurrentDirectory();
            string defaultDirectory = defaultPath.Substring(defaultPath.LastIndexOf("\\") + 1);

            if (!Directory.Exists(defaultDirectory))
            {
                Directory.CreateDirectory(defaultDirectory);

                string pathRoot = Directory.GetCurrentDirectory() + StaticOperatorSymbols.BackSlash + defaultDirectory;
                string path = pathRoot + StaticOperatorSymbols.BackSlash + StaticTextNames.Source;

                Directory.CreateDirectory(path);
                string fullPath = path + StaticOperatorSymbols.BackSlash + defaultDirectory + StaticTextNames.Extention;

                string basicTemplate = TemplateManager.CreateBasicTemplate(defaultDirectory).TrimStart();

                if (!File.Exists(fullPath))
                {
                    using FileStream fileStream = File.Open(fullPath, FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(fileStream))
                    {
                        sw.WriteLine(basicTemplate);
                    }
                }
            }
        }

        public static async Task CreateBasicProject(string fileName)
        {
            string globalPath = Directory.GetCurrentDirectory() + StaticOperatorSymbols.BackSlash + fileName;            
            if (!Directory.Exists(globalPath))
            {
                Directory.CreateDirectory(globalPath);

                string pathToSrc = globalPath + StaticOperatorSymbols.BackSlash + StaticTextNames.Source;
                Directory.CreateDirectory(pathToSrc);
                string fullPath = pathToSrc + StaticOperatorSymbols.BackSlash + fileName + StaticTextNames.Extention;

                string basicTemplate = TemplateManager.CreateBasicTemplate(fileName).TrimStart();

                if (!File.Exists(fullPath))
                {
                    using FileStream fileStream = File.Open(fullPath, FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(fileStream))
                    {
                        sw.WriteLine(basicTemplate);
                    }
                }
            }
        }        
    }
}
