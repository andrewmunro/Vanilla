using System.Collections.Generic;
using System.IO;
using Vanilla.World.Network;
using Vanilla.World.Tools;
using Vanilla.World.Tools.DBC;
using Vanilla.World.Tools.DBC.Tables;

namespace Vanilla.World.Communication.Outgoing.Char
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

				ItemTemplateEntry[] Equipment = DBC.ItemTemplates.GenerateInventoryByIDs(Helper.CSVStringToIntArray(character.Equipment));

				for(int itemSlot = 0; itemSlot < 19; itemSlot++)
				{
					if(Equipment[itemSlot] != null)
					{
						Write((int)Equipment[itemSlot].displayid); // Item DisplayID
						Write((byte)Equipment[itemSlot].InventoryType); // Item Inventory Type
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
