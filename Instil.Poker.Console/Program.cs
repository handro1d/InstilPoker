using Instil.Poker.Core;
using Instil.Poker.Core.Interfaces;
using Instil.Poker.Core.Text;
using Instil.Poker.Core.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Instil.Poker.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Setup container with dependencies
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAppHost, AppHost>()
                .AddScoped<IFileParser, TextFileParser>()
                .AddScoped<IFileValidator, WindowsFileValidator>()
                .AddScoped<IHandValidator, DefaultPokerHandValidator>()
                .AddScoped<IPokerHandDetermination, PokerFace>()
                .BuildServiceProvider();

            // Run host
            serviceProvider.GetService<IAppHost>().Run(args);
        }
    }
}
