namespace Vanilla.World
{
    using System;

    using Vanilla.Character.Database.Models;
    using Vanilla.Core.Config;
    using Vanilla.Login.Database.Models;
    using Vanilla.World.Database.Models;
    using Vanilla.World.Game;
    using Vanilla.World.Game.Managers;
    using Vanilla.World.Network;
    using Vanilla.World.Tools.Chat;
    using Vanilla.World.Tools.DBC;

    public class VanillaWorld
    {
        static void Main(string[] args)
        {
            Config.Boot();

            WorldDatabase = new WorldDatabase();
            CharacterDatabase = new CharacterDatabase();
            LoginDatabase = new LoginDatabase();
            DBC.Boot();

            LogoutManager.Boot();
            ChatManager.Boot();
            ChatChannelManager.Boot();
            MovementManager.Boot();
            MiscManager.Boot();
            SpellManager.Boot();
            ChatCommandParser.Boot();
            EntityManager.Boot();
            WorldLoginHandler.Boot();
            CharacterManager.Boot();
            PlayerManager.Boot();
            UnitManager.Boot();
            MailManager.Boot();
            GameObjectManager.Boot();

            PlayerManager = new PlayerManager();
            UnitComponent = new UnitComponent();
            GameObjectComponent = new GameObjectComponent();
            new WorldManager();
            ScriptManager.Boot();

            WorldServer = new WorldServer();
            WorldServer.Start(Config.GetValue<int>(ConfigSections.WORLD, ConfigValues.PORT), Config.GetValue<int>(ConfigSections.WORLD, ConfigValues.MAX_CONNECTIONS));

            while (true)
            {
                Console.ReadLine();
            }
        }

        public static WorldServer WorldServer { get; set; }

        public static PlayerManager PlayerManager { get; set; }

        public static UnitComponent UnitComponent { get; private set; }

        public static GameObjectComponent GameObjectComponent { get; private set; }

        public static WorldDatabase WorldDatabase { get; private set; }

        public static CharacterDatabase CharacterDatabase { get; private set; }

        public static LoginDatabase LoginDatabase { get; set; }
    }
}
