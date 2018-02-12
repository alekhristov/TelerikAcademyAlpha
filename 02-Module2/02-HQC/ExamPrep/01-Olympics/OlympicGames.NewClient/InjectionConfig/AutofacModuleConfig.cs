using Autofac;
using OlympicGames.Core;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;
using OlympicGames.Decorators;
using System.Configuration;

namespace OlympicGames.NewClient.InjectionConfig
{
    public class AutofacModuleConfig : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>().SingleInstance();
            builder.RegisterType<OlympicCommittee>().As<IOlympicCommittee>().SingleInstance();
            builder.RegisterType<OlympicsFactory>().As<IOlympicsFactory>().SingleInstance();
            builder.RegisterType<IoWrapper>().As<IIoWrapper>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IConsoleReader>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IConsoleWriter>().SingleInstance();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();

            var isTest = bool.Parse(ConfigurationManager.AppSettings["IsTestEnv"]);

            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();
            builder.RegisterType<CreateBoxerCommand>().Named<ICommand>("createboxer").SingleInstance();
            builder.RegisterType<CreateOlympianCommand>().Named<ICommand>("createolympian").SingleInstance();
            builder.RegisterType<CreateSprinterCommand>().Named<ICommand>("createsprinter").SingleInstance();

            if (isTest)
            {
                builder.RegisterType<ListOlympiansCommand>().Named<ICommand>("listolympiansTestEnv").SingleInstance();

                //pi = parameterInfo, ctx = context
                builder.RegisterType<LoggerCommandDecorator>().Named<ICommand>("listolympians")
                    .WithParameter(
                    (pi, ctx) => pi.Name == "command",
                    (pi, ctx) => ctx.ResolveNamed<ICommand>("listolympiansTestEnv"));
            }
            else
            {
                builder.RegisterType<ListOlympiansCommand>().Named<ICommand>("listolympians").SingleInstance();
            }

            //builder.RegisterType<CreateBoxerCommand>().Named<ICommand>("createboxer");
        }
    }
}
