using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Network;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;
using Milkshake.Tools;
using Milkshake.Tools.DBC;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Tools.Database;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Communication.Outgoing.Auth
{
    public class PSCharEnum : PacketWriter
    {
        public PSCharEnum(List<Character> characters) : base(Game.Constants.PacketHeaderType.WorldSmsg)
        {
            Write((byte)characters.Count);

            foreach (Character character in characters)
	        {
                Write((ulong)character.GUID);
                WriteCString(character.Name);
                Write((byte)character.Race);
                Write((byte)character.Class);

                Write((byte)character.Gender);
                Write((byte)character.Skin);
                Write((byte)character.Face);
                Write((byte)character.HairStyle);
                Write((byte)character.HairColor);
                Write((byte)character.Accessory);
                Write((byte)character.Level);

                Write((int)0); // Zone ID
                Write(character.MapID);
                Write(character.X);
                Write(character.Y);
                Write(character.Z);

                Write((int)0); // Guild ID
			    Write((int)0); // Character Flags

                Write((byte)0); // // Login Flags?

                Write(0); // Pet DisplayID
			    Write(0); // Pet Level
			    Write(0); // Pet FamilyID

	            ChrStartingOutfitEntry Items = Helper.GetCharStartingOutfitString(character);
	            int[] DisplayIDs = Helper.CSVStringToIntArray(Items.ItemDisplayID);
                int[] ItemInventoryType = Helper.CSVStringToIntArray(Items.ItemInventoryType);

                for (int itemSlot = 0; itemSlot < 19; ++itemSlot)
                {
                    if (itemSlot < 11 && (int) DisplayIDs[itemSlot] != -1)
                    {
                        Write((int)DisplayIDs[itemSlot]); // Item DisplayID
                        Write((byte)ItemInventoryType[itemSlot]); // Item Inventory Type
                    }
                    else
                    {
                        Write((int)0);
                        Write((byte)0);
                    }
			    }

                Write((int)0); // first bag display id
				Write((byte) 0); // first bag inventory type
	        }
        }

        public byte[] Packet { get { return (BaseStream as MemoryStream).ToArray(); } }
    }

   
}
