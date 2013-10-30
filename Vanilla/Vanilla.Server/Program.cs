namespace Vanilla.Server
{
    using System;
    using System.Threading;
    using Vanilla.Core.Config;
    using Vanilla.Core.DBC;
    using Vanilla.Core.DBC.Structs;
    using Vanilla.Login;
    using Vanilla.World;
    using Vanilla.World.Game.Update;

    public class Program
    {
        public static int LoginPort { get { return Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.PORT); } }

        public static int LoginMaxConnection { get { return Config.GetValue<int>(ConfigSections.LOGIN, ConfigValues.MAX_CONNECTIONS); } }

        public static int WorldPort { get { return Config.GetValue<int>(ConfigSections.WORLD, ConfigValues.PORT); } }

        public static int WorldMaxConnection { get { return Config.GetValue<int>(ConfigSections.WORLD, ConfigValues.MAX_CONNECTIONS); } }
        
        static void Main(string[] args)
        {
            UpdateReader.Boot();

            DBCStore<ChrRaces> reader = new DBCStore<ChrRaces>();


            //reader.Records.ForEach(record => Console.WriteLine(record.Race + " - " + record.Class + " - " + record.Gender));
            Config.Boot();

            VanillaLogin vanillaLogin = new VanillaLogin(LoginPort, LoginMaxConnection);
            VanillaWorld vanillaWorld = new VanillaWorld(WorldPort, WorldMaxConnection);

            //new BotClient(LoginPort).ConnectToServer();

            while (true) Thread.Sleep(1000);
        }
    }
}
