using Autofac;
using System.Configuration;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Decorators;
using Traveller.Core.Factories;
using Traveller.Core.Factories.Contracts;
using Traveller.Core.Providers;
using Traveller.Core.Providers.Contracts;

namespace Traveller.ConsoleApp.Modules
{
    public class AutoConfigModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Registering engine and its compounds 
            builder.RegisterType<Reader>().As<IReader>().SingleInstance();
            builder.RegisterType<Writer>().As<IWriter>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>().SingleInstance();
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();

            // Checking if we are in Test Environment
            var isTestEnv = bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"]);

            // If we are in Test Environment, we are going to check Engine's performance through Decorator design pattern
            if (isTestEnv)
            {
                builder.RegisterType<Engine>().Named<IEngine>("engineTestEnv").SingleInstance();

                builder.RegisterType<EnginePerformanceDecorator>().As<IEngine>()
                    .WithParameter(
                    (pi, ctx) => pi.Name == "engine",
                    (pi, ctx) => ctx.ResolveNamed<IEngine>("engineTestEnv"))
                    .SingleInstance();
            }
            // If we are not in Test Environment, we are just going to register the Engine
            else
            {
                builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            }

            // Registering factories
            builder.RegisterType<TravellerFactory>().As<ITravellerFactory>().SingleInstance();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();

            // Registering database
            builder.RegisterType<Database>().As<IDatabase>().SingleInstance();

            // Registering create commands
            builder.RegisterType<CreateAirplaneCommand>().Named<ICommand>("createairplane");
            builder.RegisterType<CreateBusCommand>().Named<ICommand>("createbus");
            builder.RegisterType<CreateTrainCommand>().Named<ICommand>("createtrain");
            builder.RegisterType<CreateJourneyCommand>().Named<ICommand>("createjourney");
            builder.RegisterType<CreateTicketCommand>().Named<ICommand>("createticket");

            // Registering list commands
            builder.RegisterType<ListJourneysCommand>().Named<ICommand>("listjourneys");
            builder.RegisterType<ListTicketsCommand>().Named<ICommand>("listtickets");
            builder.RegisterType<ListVehiclesCommand>().Named<ICommand>("listvehicles");
        }
    }
}
