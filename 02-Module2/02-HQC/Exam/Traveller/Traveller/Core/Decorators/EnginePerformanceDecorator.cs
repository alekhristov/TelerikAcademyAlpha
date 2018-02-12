using Bytes2you.Validation;
using System.Diagnostics;
using Traveller.Core.Contracts;
using Traveller.Core.Providers.Contracts;

namespace Traveller.Core.Decorators
{
    public class EnginePerformanceDecorator : IEngine
    {
        private readonly IEngine engine;
        private readonly IWriter writer;

        public EnginePerformanceDecorator(IEngine engine, IWriter writer)
        {
            Guard.WhenArgument(engine, "Engine").IsNull().Throw();
            Guard.WhenArgument(writer, "Writer").IsNull().Throw();

            this.engine = engine;
            this.writer = writer;
        }

        public void Start()
        {
            var stopwatch = new Stopwatch();

            writer.WriteLine("The Engine is starting...");

            stopwatch.Start();
            this.engine.Start();
            stopwatch.Stop();

            writer.WriteLine($"The Engine worked for {stopwatch.ElapsedMilliseconds} milliseconds.");
        }
    }
}
