using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.Character;
using Milkshake.Communication.Incoming.World.Auth;
using Milkshake.Communication.Outgoing.Auth;
using Milkshake.Communication.Outgoing.Char;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;
using Milkshake.Game.Constants.Login;
using Milkshake.Game.Handlers;
using Milkshake.Net;
using Milkshake.Tools;
using Milkshake.Tools.Cryptography;
using Milkshake.Tools.DBC;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Game.Managers
{
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
            session.sendPacket(new PSCharDelete(LoginErrorCode.CHAR_DELETE_SUCCESS));
        }

        private static void OnCharCreate(WorldSession session, PCCharCreate packet)
        {
            CharacterCreationInfo newCharacterInfo = DBCharacters.GetCreationInfo((RaceID)packet.Race, (ClassID)packet.Class);

            DBCharacters.CreateCharacter(session.Account, new Character()
            {
                Name = Helper.NormalizeText(packet.Name),
                Race = (RaceID)packet.Race,
                Class = (ClassID)packet.Class,
                Gender = (Gender)packet.Gender,
                Skin = packet.Skin,
                Face = packet.Face,
                HairStyle = packet.HairStyle,
                HairColor = packet.HairColor,
                Accessory = packet.Accessory,
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

            session.sendPacket(new PSCharCreate(LoginErrorCode.CHAR_CREATE_SUCCESS));
        }

        private static void OnCharEnum(WorldSession session, byte[] packet)
        {
            List<Character> characters = DBCharacters.GetCharacters(session.Account.Username);
            session.sendPacket(WorldOpcodes.SMSG_CHAR_ENUM, new PSCharEnum(characters).PacketData);
        }
    }
}
