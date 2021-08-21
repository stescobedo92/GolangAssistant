using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace GolangAssistant.Commands
{
    [Command(Name = "goa", OptionsComparison = StringComparison.InvariantCultureIgnoreCase)]
    [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]
    [Subcommand(typeof(ConsoleCmd)), Subcommand(typeof(MvcCmd))]
    class GoaCmd : GoaCmdBase
    {
        private readonly ILogger<GoaCmd> _logger;
        private readonly IConsole _console;

        public GoaCmd(ILogger<GoaCmd> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }

        protected override Task<int> OnExecute(CommandLineApplication app)
        {
            string banner = @"
   ______           __                             ___                     _            __                    __ 
  / ____/  ____    / /  ____ _   ____    ____ _   /   |   _____   _____   (_)   _____  / /_  ____ _   ____   / /_
 / / __   / __ \  / /  / __ `/  / __ \  / __ `/  / /| |  / ___/  / ___/  / /   / ___/ / __/ / __ `/  / __ \ / __/
/ /_/ /  / /_/ / / /  / /_/ /  / / / / / /_/ /  / ___ | (__  )  (__  )  / /   (__  ) / /_  / /_/ /  / / / // /_  
\____/   \____/ /_/   \__,_/  /_/ /_/  \__, /  /_/  |_|/____/  /____/  /_/   /____/  \__/  \__,_/  /_/ /_/ \__/  
                                      /____/                                                                                                                             
";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(banner);
            Console.ResetColor();

            app.ShowHelp();
            return Task.FromResult(0);
        }

        private static string GetVersion() => typeof(GoaCmd).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
    }
}
