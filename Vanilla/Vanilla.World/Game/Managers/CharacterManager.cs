using System.Collections.Generic;
using Vanilla.World.Communication.Incoming.Character;
using Vanilla.World.Communication.Outgoing.Char;
using Vanilla.World.Game.Handlers;
using Vanilla.World.Tools.DBC;

namespace Vanilla.World.Game.Managers
{
    using Vanilla.Core;
    using Vanilla.Core.Constants;
    using Vanilla.Core.Constants.Character;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Network;

    public class CharacterManager
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler(WorldOpcodes.CMSG_CHAR_ENUM, OnCharEnum);
            WorldDataRouter.AddHandler<PCCharCreate>(WorldOpcodes.CMSG_CHAR_CREATE, OnCharCreate);
            WorldDataRouter.AddHandler<PCCharDelete>(WorldOpcodes.CMSG_CHAR_DELETE, OnCHarDelete);
        }

        private static void OnCHarDelete(WorldSession session, PCCharDelete packet)
        {
            DBCharacters.DeleteCharacter(packet.Character);
            session.SendPacket(new PSCharDelete(LoginErrorCode.CHAR_DELETE_SUCCESS));
        }

        private static void OnCharCreate(WorldSession session, PCCharCreate packet)
        {
            CharacterCreationInfo newCharacterInfo = DBCharacters.GetCreationInfo((RaceID)packet.Race, (ClassID)packet.Class);

            DBCharacters.CreateCharacter(session.Account, new Character()
            {
                Name = Utils.NormalizeText(packet.Name),
                Race = (RaceID)packet.Race,
                Class = (ClassID)packet.Class,
                Gender = (Gender)packet.Gender,
                Skin = packet.Skin,
                Face = packet.Face,
                HairStyle = packet.HairStyle,
                HairColor = packet.HairColor,
                Accessory = packet.Accessory,
                Money = 100000,
                Level = 1,
                Health = 1000,
                Mana = 1000,
                Rage = 1000,
                Energy = 1000,
                Happiness = 1000,
                Focus = 1000,
                Drunk = 100,
                Online = 0,
                MapID = newCharacterInfo.Map,
                Zone = newCharacterInfo.Zone,
                X = newCharacterInfo.X, //1235.54f, //- 2917.580078125f,
                Y = newCharacterInfo.Y, //1427.1f, //- 257.980010986328f,
                Z = newCharacterInfo.Z, //309.715f, //52.9967994689941f,
                Rotation = newCharacterInfo.R,
                Equipment = DBC.ChrStartingOutfit.GetCharStartingOutfitString(packet).ItemID
            });

            session.SendPacket(new PSCharCreate(LoginErrorCode.CHAR_CREATE_SUCCESS));
        }

        private static void OnCharEnum(WorldSession session, byte[] packet)
        {
            List<Character> characters = DBCharacters.GetCharacters(session.Account.Username);
            session.SendPacket(WorldOpcodes.SMSG_CHAR_ENUM, new PSCharEnum(characters).PacketData);
        }
    }
}
