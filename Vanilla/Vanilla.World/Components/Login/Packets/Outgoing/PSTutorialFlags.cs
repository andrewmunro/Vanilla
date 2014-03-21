using Vanilla.Character.Database;
using Vanilla.Login.Database;

namespace Vanilla.World.Components.Login.Packets.Outgoing
{
    using Vanilla.Core.IO;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal sealed class PSTutorialFlags : WorldPacket
    {
        public PSTutorialFlags(account account, IRepository<character_tutorial> characterTutorials)
            : base(WorldOpcodes.SMSG_TUTORIAL_FLAGS)
        {
            character_tutorial characterTutorial = characterTutorials.SingleOrDefault(ct => ct.account == account.id);

            if (characterTutorial == null)
            {
                characterTutorial = new character_tutorial()
                                        {
                                            account = account.id,
                                            tut0 = 0,
                                            tut1 = 0,
                                            tut2 = 0,
                                            tut3 = 0,
                                            tut4 = 0,
                                            tut5 = 0,
                                            tut6 = 0,
                                            tut7 = 0
                                        };
                characterTutorials.Add(characterTutorial);
            }

            this.Write((byte)characterTutorial.tut0);
            this.Write((byte)characterTutorial.tut1);
            this.Write((byte)characterTutorial.tut2);
            this.Write((byte)characterTutorial.tut3);
            this.Write((byte)characterTutorial.tut4);
            this.Write((byte)characterTutorial.tut5);
            this.Write((byte)characterTutorial.tut6);
            this.Write((byte)characterTutorial.tut7);
        }
    }
}
