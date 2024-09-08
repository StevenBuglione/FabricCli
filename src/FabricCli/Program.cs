using FabricCli.Factory;

namespace FabricCli
{
    public class Program
    {
        static int Main(string[] args)
        {
            var app = CommandAppFactory.Create();
            return app.Run(args);
        }
    }
}
