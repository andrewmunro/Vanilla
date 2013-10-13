using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    #region

    using System.Linq;

    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.Login.Database.Models;

    #endregion

    internal sealed class PSTutorialFlags : WorldPacket
    {
        // TODO Write the uint ids of 8 tutorial values
        #region Constructors and Destructors

        public PSTutorialFlags(Account account)
            : base(WorldOpcodes.SMSG_TUTORIAL_FLAGS)
        {
            var tutorialData = VanillaWorld.CharacterDatabase.CharacterTutorial.Single(cts => cts.Account == account.ID);

            this.Write(tutorialData.Tut0);
            this.Write(tutorialData.Tut1);
            this.Write(tutorialData.Tut2);
            this.Write(tutorialData.Tut3);
            this.Write(tutorialData.Tut4);
            this.Write(tutorialData.Tut5);
            this.Write(tutorialData.Tut6);
            this.Write(tutorialData.Tut7);
        }

        #endregion
    }
}