using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Commands.Decorators;
using Academy.Commands.Listing;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Autofac;

namespace Academy.ConsoleApp
{
    public class AutofacConfigModule : Module
    {
         protected override void Load(ContainerBuilder builder)
        {
            // Registering engine
            builder.RegisterType<AcademyFactory>().As<IAcademyFactory>().SingleInstance();
            builder.RegisterType<CommandParser>().As<ICommandParser>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>().SingleInstance();
            builder.RegisterType<ConsoleWriter>().As<IWriter>().SingleInstance();
            builder.RegisterType<ConsoleReader>().As<IReader>().SingleInstance();
            builder.RegisterType<Database>().As<IDatabase>().SingleInstance();
            builder.RegisterType<Engine>().As<IEngine>().SingleInstance();
            builder.RegisterType<CommandFactory>().As<ICommandFactory>().SingleInstance();

            // Add commands
            builder.RegisterType<AddStudentToCourseCommand>().Named<ICommand>("addstudenttocourse").SingleInstance();
            builder.RegisterType<AddStudentToSeasonCommand>().Named<ICommand>("addstudenttoseason").SingleInstance();
            builder.RegisterType<AddTrainerToSeasonCommand>().Named<ICommand>("addtrainertoseason").SingleInstance();

            // Create commands using decorator
            builder.RegisterType<CreateCourseCommand>().Named<ICommand>("createcourseTestInv").SingleInstance();
            builder.RegisterType<CreateCourseResultCommand>().Named<ICommand>("createcourseresultTestInv").SingleInstance();
            builder.RegisterType<CreateLectureCommand>().Named<ICommand>("createlectureTestInv").SingleInstance();
            builder.RegisterType<CreateLectureResourceCommand>().Named<ICommand>("createlectureresourceTestInv").SingleInstance();
            builder.RegisterType<CreateSeasonCommand>().Named<ICommand>("createseasonTestInv").SingleInstance();
            builder.RegisterType<CreateStudentCommand>().Named<ICommand>("createstudentTestInv").SingleInstance();
            builder.RegisterType<CreateTrainerCommand>().Named<ICommand>("createtrainerTestInv").SingleInstance();

            builder.RegisterType<LoggingCommandDecorator>().Named<ICommand>("createcourse")
                .WithParameter(
                (pi, ctx) => pi.Name == "command",
                (pi, ctx) => ctx.ResolveNamed<ICommand>("createcourseTestInv"));

            builder.RegisterType<LoggingCommandDecorator>().Named<ICommand>("createcourseresult")
                .WithParameter(
                (pi, ctx) => pi.Name == "command",
                (pi, ctx) => ctx.ResolveNamed<ICommand>("createcourseresultTestInv"));

            builder.RegisterType<LoggingCommandDecorator>().Named<ICommand>("createlecture")
                .WithParameter(
                (pi, ctx) => pi.Name == "command",
                (pi, ctx) => ctx.ResolveNamed<ICommand>("createlectureTestInv"));

            builder.RegisterType<LoggingCommandDecorator>().Named<ICommand>("createlectureresource")
                .WithParameter(
                (pi, ctx) => pi.Name == "command",
                (pi, ctx) => ctx.ResolveNamed<ICommand>("createlectureresourceTestInv"));

            builder.RegisterType<LoggingCommandDecorator>().Named<ICommand>("createseason")
                .WithParameter(
                (pi, ctx) => pi.Name == "command",
                (pi, ctx) => ctx.ResolveNamed<ICommand>("createseasonTestInv"));

            builder.RegisterType<LoggingCommandDecorator>().Named<ICommand>("createstudent")
                .WithParameter(
                (pi, ctx) => pi.Name == "command",
                (pi, ctx) => ctx.ResolveNamed<ICommand>("createstudentTestInv"));

            builder.RegisterType<LoggingCommandDecorator>().Named<ICommand>("createtrainer")
                .WithParameter(
                (pi, ctx) => pi.Name == "command",
                (pi, ctx) => ctx.ResolveNamed<ICommand>("createtrainerTestInv"));

            // List commands
            builder.RegisterType<ListCoursesInSeasonCommand>().Named<ICommand>("listcoursesinseason").SingleInstance();
            builder.RegisterType<ListUsersCommand>().Named<ICommand>("listusers").SingleInstance();
            builder.RegisterType<ListUsersInSeasonCommand>().Named<ICommand>("listusersinseason").SingleInstance();
        }
    }
}
