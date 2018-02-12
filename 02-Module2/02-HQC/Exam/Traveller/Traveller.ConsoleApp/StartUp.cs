using Autofac;
using Traveller.ConsoleApp.Modules;
using Traveller.Core.Contracts;

namespace Traveller.ConsoleApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutoConfigModule>();

            var container = builder.Build();
            var engine = container.Resolve<IEngine>();

            engine.Start();
        }
    }
}
