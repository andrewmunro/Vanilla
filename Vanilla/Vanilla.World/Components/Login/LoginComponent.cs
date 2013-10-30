namespace Vanilla.World.Components.Login
{
    using System.Collections.Generic;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Network.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Communication.Outgoing.Auth;
    using Vanilla.World.Communication.Outgoing.World;
    using Vanilla.World.Components.Login.Packets.Incoming;
    using Vanilla.World.Components.Update.Packets.Outgoing;
    using Vanilla.World.Game.Entity.Character;
    using Vanilla.World.Game.Update;
    using Vanilla.World.Network;

    public class LoginComponent : WorldServerComponent
    {
        public LoginComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            this.Router.AddHandler<PCPlayerLogin>(WorldOpcodes.CMSG_PLAYER_LOGIN, this.OnPlayerLogin);
        }

        private void OnPlayerLogin(WorldSession session, PCPlayerLogin packet)
        {
            Log.Print("Trying to login");

            Character databaseCharacter = Core.CharacterDatabase.GetRepository<Character>().SingleOrDefault(c => c.GUID == packet.GUID);

            session.Character = new CharacterEntity(databaseCharacter);
            session.Character.Setup();

            session.SendPacket(new PSLoginVerifyWorld(1, 0, 0, 0, 0));
            session.SendPacket(new PSAccountDataTimes());
            session.SendPacket(new PSSetRestStart());
            session.SendPacket(new PSBindPointUpdate());

            session.SendHexPacket(WorldOpcodes.SMSG_TUTORIAL_FLAGS, "06 00 40 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ");

            session.SendHexPacket(WorldOpcodes.SMSG_LOGIN_SETTIMESPEED, "E6 A4 11 0D 8A 88 88 3C ");
            session.SendHexPacket(WorldOpcodes.SMSG_INIT_WORLD_STATES, "01 00 00 00 6C 00 AE 07 01 00 32 05 01 00 31 05 00 00 2E 05 00 00 F9 06 00 00 F3 06 00 00 F1 06 00 00 EE 06 00 00 ED 06 00 00 71 05 00 00 70 05 00 00 67 05 01 00 66 05 01 00 50 05 01 00 44 05 00 00 36 05 00 00 35 05 01 00 C6 03 00 00 C4 03 00 00 C2 03 00 00 A8 07 00 00 A3 07 0F 27 74 05 00 00 73 05 00 00 72 05 00 00 6F 05 00 00 6E 05 00 00 6D 05 00 00 6C 05 00 00 6B 05 00 00 6A 05 01 00 69 05 01 00 68 05 01 00 65 05 00 00 64 05 00 00 63 05 00 00 62 05 00 00 61 05 00 00 60 05 00 00 5F 05 00 00 5E 05 00 00 5D 05 00 00 5C 05 00 00 5B 05 00 00 5A 05 00 00 59 05 00 00 58 05 00 00 57 05 00 00 56 05 00 00 55 05 00 00 54 05 01 00 53 05 01 00 52 05 01 00 51 05 01 00 4F 05 00 00 4E 05 00 00 4D 05 01 00 4C 05 00 00 4B 05 00 00 45 05 00 00 43 05 01 00 42 05 00 00 40 05 00 00 3F 05 00 00 3E 05 00 00 3D 05 00 00 3C 05 00 00 3B 05 00 00 3A 05 01 00 39 05 00 00 38 05 00 00 37 05 00 00 34 05 00 00 33 05 00 00 30 05 00 00 2F 05 00 00 2D 05 01 00 16 05 01 00 15 05 00 00 B6 03 00 00 45 07 02 00 36 07 01 00 35 07 01 00 34 07 01 00 33 07 01 00 32 07 01 00 02 07 00 00 01 07 00 00 00 07 00 00 FE 06 00 00 FD 06 00 00 FC 06 00 00 FB 06 00 00 F8 06 00 00 F7 06 00 00 F6 06 00 00 F4 06 D0 07 F2 06 00 00 F0 06 00 00 EF 06 00 00 EC 06 00 00 EA 06 00 00 E9 06 00 00 E8 06 00 00 E7 06 00 00 18 05 00 00 17 05 00 00 03 07 00 00 ");

            
            //PSUpdateObject pow = new PSUpdateObject(new List<byte[]>() { (session.Character.PacketBuilder as CharacterPacketBuilder).BuildOwnCharacterPacket() });
            //byte[] data = pow.PacketData;
            //UpdateReader.ProccessLog(data);
            //session.SendPacket(pow);
            
            session.SendHexPacket(WorldOpcodes.SMSG_UPDATE_OBJECT, "01" + "00 00 00 00" + "03" + "01 01 04 71 00 00 00 00 AD 5E 00 00 7B 34 37 C5 E7 3B 85 C3 06 52 56 42 CA A9 49 3F 00 00 00 00 00 00 20 40 00 00 E0 40 00 00 90 40 71 1C 97 40 00 00 20 40 E0 0F 49 40 01 00 00 00 29 15 00 40 54 1D C0 00 00 00 00 00 80 20 00 00 C0 D9 04 C2 4F 38 19 00 00 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 E0 B6 6D DB B6 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 6C 80 00 00 00 00 00 00 80 00 40 00 00 80 3F 00 00 00 00 20 00 00 00 00 00 00 01 00 00 00 19 00 00 00 CD CC AC 3F 54 00 00 00 64 00 00 00 54 00 00 00 E8 03 00 00 64 00 00 00 01 00 00 00 06 00 00 00 06 01 00 01 08 00 00 00 99 09 00 00 09 00 00 00 01 00 00 00 D0 07 00 00 D0 07 00 00 D0 07 00 00 3B 00 00 00 3B 00 00 00 25 49 D2 40 25 49 F2 40 00 EE 11 00 00 00 80 3F 1C 00 00 00 0F 00 00 00 18 00 00 00 0F 00 00 00 16 00 00 00 1E 00 00 00 0A 00 00 00 14 00 00 00 00 28 00 00 27 00 00 00 06 00 00 00 DC B6 ED 3F 6E DB 36 40 07 00 07 01 02 00 00 01 90 01 00 00 1A 00 00 00 01 00 01 00 2C 00 00 00 01 00 05 00 36 00 00 00 01 00 05 00 5F 00 00 00 01 00 05 00 6D 00 00 00 2C 01 2C 01 73 00 00 00 2C 01 2C 01 A0 00 00 00 01 00 05 00 A2 00 00 00 01 00 05 00 9D 01 00 00 01 00 01 00 9E 01 00 00 01 00 01 00 9F 01 00 00 01 00 01 00 B1 01 00 00 01 00 01 00 02 00 00 00 48 E1 9A 40 3E 0A 17 3F 3E 0A 17 3F CD CC 0C 3F 00 00 04 00 29 00 00 00 0A 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 80 3F FF FF FF FF ");
        }
    }
}
