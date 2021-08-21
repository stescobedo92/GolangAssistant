using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using Microsoft.SharePoint.Client.UserProfiles;
using Newtonsoft.Json;

namespace GolangAssistant.Commands
{
    [HelpOption("--help")]
    abstract class GoaCmdBase
    {
        private UserProfile _userProfile;

        protected ILogger _logger;
        protected IHttpClientFactory _httpClientFactory;
        protected IConsole _console;

        [Option(CommandOptionType.SingleValue, ShortName = "i", LongName = "info", Description = "information about project", ShowInHelpText = true)]
        public string Information { get; set; }

        protected string FileNameSuffix { get; set; }

        protected virtual Task<int> OnExecute(CommandLineApplication app)
        {
            return Task.FromResult(0);
        }

        protected void OnException(Exception ex)
        {
            OutputError(ex.Message);
            _logger.LogError(ex.Message);
            _logger.LogDebug(ex, ex.Message);
        }

        protected void Output(string data)
        {
            OutputToConsole(data);
        }

        protected void OutputToConsole(string data)
        {
            _console.BackgroundColor = ConsoleColor.Black;
            _console.ForegroundColor = ConsoleColor.White;
            _console.Out.Write(data);
            _console.ResetColor();
        }

        protected void OutputError(string message)
        {
            _console.BackgroundColor = ConsoleColor.Red;
            _console.ForegroundColor = ConsoleColor.White;
            _console.Error.WriteLine(message);
            _console.ResetColor();
        }

    }
}
