namespace Vanilla.World.Components.Character
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core;
    using Vanilla.Core.Constants;
    using Vanilla.Core.DBC.Structs;
    using Vanilla.Core.IO;
    using Vanilla.Core.Network.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Components.Character.Packets.Incoming;
    using Vanilla.World.Components.Character.Packets.Outgoing;
    using Vanilla.World.Network;

    public class CharacterComponent : WorldServerComponent
    {
        protected IRepository<Character> Characters { get { return this.Core.CharacterDatabase.GetRepository<Character>(); } }

        public CharacterComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            Router.AddHandler(WorldOpcodes.CMSG_CHAR_ENUM, OnCharEnum);
            Router.AddHandler<PCCharDelete>(WorldOpcodes.CMSG_CHAR_DELETE, OnCharDelete);
            Router.AddHandler<PCCharCreate>(WorldOpcodes.CMSG_CHAR_CREATE, OnCharCreate);
        }

        private void OnCharEnum(WorldSession session, PacketReader reader)
        {
            session.SendPacket(new PSCharEnum(session, Characters.Where(c => c.Account == session.Account.ID).ToList()));
        }

        private void OnCharDelete(WorldSession session, PCCharDelete packet)
        {
            Characters.Delete(Characters.SingleOrDefault(chars => chars.GUID == packet.GUID));
            Core.CharacterDatabase.SaveChanges();
            session.SendPacket(new PSCharDelete(LoginErrorCode.CHAR_DELETE_SUCCESS));
        }

        private void OnCharCreate(WorldSession session, PCCharCreate packet)
        {
            byte[] playerBytes = { packet.Skin, packet.Face, packet.HairStyle, packet.HairColor };
            byte[] playerBytes2 = { packet.Accessory };

            Character character = new Character()
            {
                GUID = Characters.AsQueryable().Count() + 1,
                Account = session.Account.ID,
                Name = Utils.NormalizeText(packet.Name),
                Race = packet.Race,
                Class = packet.Class,
                Gender = packet.Gender,
                Level = 1,
                XP = 0,
                Money = 100000,
                PlayerBytes = BitConverter.ToInt32(playerBytes, 0),
                PlayerBytes2 = 0,
                PlayerFlags = 0,
                PositionX = -2917.580078125f,
                PositionY = -257.980010986328f,
                PositionZ = 52.9967994689941f,
                Map = 1,
                Orientation = 0,
                TaxiMask = "",
                Online = 0,
                Cinematic = 0,
                TotalTime = 0,
                LevelTime = 0,
                LogoutTime = 0,
                IsLogoutResting = 0,
                RestBonus = 0,
                ResetTalentsCost = 0,
                ResetTalentsTime = 0,
                TransX = 0,
                TransY = 0,
                TransZ = 0,
                TransO = 0,
                TransGUID = 0,                
                ExtraFlags = 0,
                AtLogin = 0,
                Zone = 0,
                DeathExpireTime = 0,
                TaxiPath = "",
                HonorHighestRank = 0,
                HonorStanding = 0,
                StoredHonorRating = 0,
                StoredDishonorableKills = 0,
                StoredHonorableKills = 0,
                WatchedFaction = 0,
                Drunk = 0,
                Health = 100,
                Power1 = 0,
                Power2 = 0,
                Power3 = 0,
                Power4 = 0,
                Power5 = 0,
                ExploredZones = "",
                EquipmentCache = GetStartingEquipment(packet.Race, packet.Class, packet.Gender),
                AmmoID = 0,
                ActionBars = 0,
                DeleteInfosAccount = session.Account.ID,
                DeleteInfosName = Utils.NormalizeText(packet.Name),
                DeleteDate = 0
            };

            Characters.Add(character);
            Core.CharacterDatabase.SaveChanges();

            session.SendPacket(new PSCharCreate(LoginErrorCode.CHAR_CREATE_SUCCESS));
        }

        private unsafe string GetStartingEquipment(byte Race, byte Class, byte Gender)
        {
            CharStartOutfit entry = Core.DBC.GetDBC<CharStartOutfit>().SingleOrDefault(item => (byte)item.Class == Class && (byte)item.Race == Race && (byte)item.Gender == Gender);
            var result = "";
            for (int i = 0; i < 12; i++)
            {
                result += entry.ItemId[i];
                if (i != 11) result += ",";
            }
            return result;
        }
    }
}
