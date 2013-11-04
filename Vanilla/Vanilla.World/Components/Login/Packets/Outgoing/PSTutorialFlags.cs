namespace Vanilla.World.Components.Login.Packets.Outgoing
{
    using Vanilla.Core.IO;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.Character.Models;
    using Vanilla.Database.Login.Models;

    internal sealed class PSTutorialFlags : WorldPacket
    {
        public PSTutorialFlags(Account account, IRepository<CharacterTutorial> characterTutorials)
            : base(WorldOpcodes.SMSG_TUTORIAL_FLAGS)
        {
            CharacterTutorial characterTutorial = characterTutorials.SingleOrDefault(ct => ct.Account == account.ID);

            if (characterTutorial == null)
            {
                characterTutorial = new CharacterTutorial()
                                        {
                                            Account = account.ID,
                                            Tut0 = 0,
                                            Tut1 = 0,
                                            Tut2 = 0,
                                            Tut3 = 0,
                                            Tut4 = 0,
                                            Tut5 = 0,
                                            Tut6 = 0,
                                            Tut7 = 0
                                        };
                characterTutorials.Add(characterTutorial);
            }

            this.Write((byte)characterTutorial.Tut0);
            this.Write((byte)characterTutorial.Tut1);
            this.Write((byte)characterTutorial.Tut2);
            this.Write((byte)characterTutorial.Tut3);
            this.Write((byte)characterTutorial.Tut4);
            this.Write((byte)characterTutorial.Tut5);
            this.Write((byte)characterTutorial.Tut6);
            this.Write((byte)characterTutorial.Tut7);
        }
    }
}
