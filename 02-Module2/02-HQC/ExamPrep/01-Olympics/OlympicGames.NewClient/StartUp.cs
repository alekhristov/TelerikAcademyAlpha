using Autofac;
using OlympicGames.Core.Contracts;
using OlympicGames.NewClient.InjectionConfig;

namespace OlympicGames.NewClient
{
    public class StartUp
    {
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacModuleConfig>();

            var container = builder.Build();
            var engine = container.Resolve<IEngine>();
            engine.Run();
        }
    }
}
