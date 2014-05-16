using Vanilla.Character.Database;
using Vanilla.World.Database;

namespace Vanilla.World.Components.Character
{
    using System;
    using System.Linq;

    using Vanilla.Core;
    using Vanilla.Core.Constants;
    using Vanilla.Core.DBC.Structs;
    using Vanilla.Core.IO;
    using Vanilla.Core.Network.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Character.Packets.Incoming;
    using Vanilla.World.Components.Character.Packets.Outgoing;
    using Vanilla.World.Network;

    public class CharacterComponent : WorldServerComponent
    {
        private IRepository<character> Characters { get { return this.Core.CharacterDatabase.GetRepository<character>(); } }

        private IRepository<playercreateinfo> CreateInfo { get { return this.Core.WorldDatabase.GetRepository<playercreateinfo>(); } }

        public CharacterComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            Router.AddHandler(WorldOpcodes.CMSG_CHAR_ENUM, OnCharEnum);
            Router.AddHandler<PCCharDelete>(WorldOpcodes.CMSG_CHAR_DELETE, OnCharDelete);
            Router.AddHandler<PCCharCreate>(WorldOpcodes.CMSG_CHAR_CREATE, OnCharCreate);
        }

        private void OnCharEnum(WorldSession session, PacketReader reader)
        {
            session.SendPacket(new PSCharEnum(session, Characters.Where(c => c.account == session.Account.id).ToList()));
        }

        private void OnCharDelete(WorldSession session, PCCharDelete packet)
        {
            Characters.Delete(Characters.SingleOrDefault(chars => chars.guid == packet.GUID));
            Core.CharacterDatabase.SaveChanges();
            session.SendPacket(new PSCharDelete(LoginErrorCode.CHAR_DELETE_SUCCESS));
        }

        private void OnCharCreate(WorldSession session, PCCharCreate packet)
        {
            byte[] playerBytes = { packet.Skin, packet.Face, packet.HairStyle, packet.HairColor };
            byte[] playerBytes2 = { packet.Accessory };

            playercreateinfo info = CreateInfo.SingleOrDefault(ci => ci.race == packet.Race && ci.@class == packet.Class);

            var charGuid = Characters.AsQueryable().Any() ? Characters.AsQueryable().Max(c => c.guid) + 1 : 1;

            character character = new character()
            {
                guid = charGuid,
                account = session.Account.id,
                name = Utils.NormalizeText(packet.Name),
                race = packet.Race,
                @class = packet.Class,
                gender = packet.Gender,
                level = 1,
                xp = 0,
                money = 100000,
                playerBytes = BitConverter.ToInt32(playerBytes, 0),
                playerBytes2 = 0,
                playerFlags = 0,
                position_x = info.position_x,
                position_y = info.position_y,
                position_z = info.position_z,
                map = info.map,
                orientation = info.orientation,
                taximask = "",
                online = 0,
                cinematic = 0,
                totaltime = 0,
                leveltime = 0,
                logout_time = 0,
                is_logout_resting = 0,
                rest_bonus = 0,
                resettalents_cost = 0,
                resettalents_time = 0,
                trans_x = 0,
                trans_y = 0,
                trans_z = 0,
                trans_o = 0,
                transguid = 0,                
                extra_flags = 0,
                at_login = 0,
                zone = info.zone,
                death_expire_time = 0,
                taxi_path = "",
                honor_highest_rank = 0,
                honor_standing = 0,
                stored_honor_rating = 0,
                stored_dishonorable_kills = 0,
                stored_honorable_kills = 0,
                watchedFaction = 0,
                drunk = 0,
                health = 100,
                power1 = 0,
                power2 = 0,
                power3 = 0,
                power4 = 0,
                power5 = 0,
                exploredZones = "",
                equipmentCache = GetStartingEquipment(packet.Race, packet.Class, packet.Gender),
                ammoId = 0,
                actionBars = 0,
                deleteInfos_Account = session.Account.id,
                deleteInfos_Name = Utils.NormalizeText(packet.Name),
                deleteDate = 0
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
