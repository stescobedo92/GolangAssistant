using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace GolangAssistant.Commands
{
    [Command(Name = "mvc", Description = "Create a project (Model-View-Controller)")]
    class MvcCmd : GoaCmdBase
    {
        [Option(CommandOptionType.SingleValue, ShortName = "e", LongName = "empty", Description = "project empty", ShowInHelpText = true)]
        public string Empty { get; set; }

        [Option(CommandOptionType.SingleValue, ShortName = "s", LongName = "server", Description = "project with a basic server", ShowInHelpText = true)]
        public string Server { get; set; }

        [Option(CommandOptionType.SingleValue, ShortName = "g", LongName = "generate", Description = "generate controller", ShowInHelpText = true)]
        public string Generate { get; set; }

        public MvcCmd(ILogger<MvcCmd> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }

        protected override async Task<int> OnExecute(CommandLineApplication app)
        {
            try
            {
                if (string.IsNullOrEmpty(Empty))
                {
                    Console.WriteLine("no se puso ninguna opcion");
                }
                else
                {
                    Console.WriteLine("se puso opcion");
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
