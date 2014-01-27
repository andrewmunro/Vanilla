using System.Collections.Generic;
using System.Linq;

namespace Vanilla.World.Components.ActionBar
{
    using System.Collections;

    using Vanilla.Core.IO;
    using Vanilla.Database.Character.Models;
    using Vanilla.Database.World.Models;
    using Vanilla.World.Game.Entity.Object.Player;

    public class ActionButtonCollection : IEnumerable<CharacterAction>
    {
        public PlayerEntity Owner { get; private set; }

        private DatabaseUnitOfWork<CharacterDatabase> CharacterDatabase
        {
            get { return Owner.Session.Core.CharacterDatabase; }
        }

        private IRepository<CharacterAction> CharacterActions
        {
            get { return CharacterDatabase.GetRepository<CharacterAction>(); }
        }

        private IRepository<PlayerCreateInfoAction> PlayerCreateActions
        {
            get { return Owner.Session.Core.WorldDatabase.GetRepository<PlayerCreateInfoAction>(); }
        }

        public ActionButtonCollection(PlayerEntity playerEntity)
        {
            Owner = playerEntity;

            var characterActions = CharacterActions.Where(cs => cs.GUID == Owner.Character.GUID).ToList();
            //Must be a new character, get initial spells
            if (characterActions.Count == 0) AddCharacterCreationActions();
        }

        public void AddActionButton(CharacterAction characterAction)
        {
            CharacterActions.Add(characterAction);
            CharacterDatabase.SaveChanges();
        }

        public void RemoveActionButton(byte button)
        {
            var characterAction = CharacterActions.SingleOrDefault(ca => ca.GUID == Owner.ObjectGUID.Low && ca.Button == button);
            RemoveActionButton(characterAction);
        }

        public void RemoveActionButton(CharacterAction characterAction)
        {
            CharacterActions.Delete(characterAction);
            CharacterDatabase.SaveChanges();
        }

        private void AddCharacterCreationActions()
        {
            List<PlayerCreateInfoAction> newCreateInfoActions = PlayerCreateActions.Where(s => s.Race == Owner.Character.Race && s.Class == Owner.Character.Class).ToList();
            newCreateInfoActions.ForEach(a => CharacterActions.Add(new CharacterAction() { GUID = this.Owner.ObjectGUID.Low, Action = a.Action, Button = (byte)a.Button, Type = (byte) a.Type }));

            CharacterDatabase.SaveChanges();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<CharacterAction> GetEnumerator()
        {
            return CharacterActions.Where(ca => ca.GUID == Owner.ObjectGUID.Low).GetEnumerator();
        }
    }
}
