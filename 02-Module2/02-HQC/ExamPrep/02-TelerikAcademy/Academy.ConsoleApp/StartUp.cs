using Academy.Core.Contracts;
using Autofac;

namespace Academy.ConsoleApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacConfigModule>();

            var container = builder.Build();
            var engine = container.Resolve<IEngine>();

            engine.Start();
        }
    }
}
