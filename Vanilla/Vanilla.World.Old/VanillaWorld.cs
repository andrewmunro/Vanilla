namespace Vanilla.World
{
    using System.Linq;
    using System.Threading;

    using Database.Character.Models;
    using Vanilla.Core.Components;
    using Vanilla.Login.Database.Models;
    using Vanilla.World.Components;
    using Database.World.Models;
    using Vanilla.World.Game.Managers;
    using Vanilla.World.Network;
    using Vanilla.World.Tools.Chat;
    using Vanilla.World.Tools.DBC;

    public class VanillaWorld : VanillaComponentBasedCore<WorldServerComponent>
    {
        public VanillaWorld(int port, int maxConnection)
        {
            WorldDatabase = new WorldDatabase();
            CharacterDatabase = new CharacterDatabase();
            LoginDatabase = new LoginDatabase();

            // Entity framework hack to call meta data caching as soon as possible.
            new Thread(() => WorldDatabase.commands.ToList()).Start();

            DBC.Boot(); //Temporary

            Server = new WorldServer();

            Components.Add(new LogoutComponent(this));
            Components.Add(new ChatMessageComponent(this));
            Components.Add(new ChatChannelComponent(this));
            Components.Add(new PlayerMovementComponent(this));
            Components.Add(new MiscComponent(this)); // Refactor this <--- we don't want misc >:(
            Components.Add(new SpellComponent(this));
            Components.Add(new ChatCommandParser(this));
            Components.Add(new EntityManager(this));
            Components.Add(new WorldLoginHandler(this));
            Components.Add(new CharacterManager(this));
            Components.Add(new PlayerManager(this));
            Components.Add(new UnitManager(this));
            Components.Add(new MailManager(this));
            Components.Add(new GameObjectManager(this));
            Components.Add(new PlayerManager(this));
            Components.Add(new UnitComponent(this));
            Components.Add(new GameObjectComponent(this));
            Components.Add(new WorldManager(this));
            Components.Add(new ScriptManager(this));

            Server.Start(port, maxConnection);
        }

        public WorldServer Server { get; private set; }

        public WorldDatabase WorldDatabase { get; private set; }

        public static CharacterDatabase CharacterDatabase { get; private set; }

        public static LoginDatabase LoginDatabase { get; set; }
    }
}
