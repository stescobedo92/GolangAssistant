using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GolangAssistant.Tools;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace GolangAssistant.Commands
{
    [Command(Name = "console", Description = "Create a basic project from a name with a simple hello world.")]
    class ConsoleCmd : GoaCmdBase
    {
        [Option(CommandOptionType.SingleValue, ShortName = "n", LongName = "name", Description = "project output folder", ValueName = "project name", ShowInHelpText = true)]
        public string Name { get; set; }

        public ConsoleCmd(ILogger<ConsoleCmd> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }
        private GoaCmd Parent { get; set; }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            Console.WriteLine("ADLHJDHJASD:  " + Name);
            try
            {
                if (string.IsNullOrEmpty(Name))
                {
                    await FileManager.CreateDefaultProject();
                }
                else
                {
                    await FileManager.CreateBasicProject(Name);
                }               

                return 0;
            }
            catch (Exception ex)
            {
                OnException(ex);
                return 1;
            }
        }
    }
}
