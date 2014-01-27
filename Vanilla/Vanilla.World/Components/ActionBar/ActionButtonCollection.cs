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

        private readonly DatabaseUnitOfWork<CharacterDatabase> characterDatabase;
        private readonly DatabaseUnitOfWork<WorldDatabase> worldDatabase;

        public ActionButtonCollection(PlayerEntity playerEntity)
        {
            Owner = playerEntity;
            characterDatabase = Owner.Session.Core.CharacterDatabase;
            worldDatabase = Owner.Session.Core.WorldDatabase;

            var characterActions = characterDatabase.GetRepository<CharacterAction>().Where(cs => cs.GUID == Owner.Character.GUID).ToList();
            //Must be a new character, get initial spells
            if (characterActions.Count == 0) AddCharacterCreationActions();
        }

        public void AddActionButton(CharacterAction characterAction)
        {
            characterDatabase.GetRepository<CharacterAction>().Add(characterAction);
            characterDatabase.SaveChanges();
        }

        public void RemoveActionButton(byte button)
        {
            var characterAction = characterDatabase.GetRepository<CharacterAction>().SingleOrDefault(ca => ca.GUID == Owner.ObjectGUID.Low && ca.Button == button);
            RemoveActionButton(characterAction);
        }

        public void RemoveActionButton(CharacterAction characterAction)
        {
            characterDatabase.GetRepository<CharacterAction>().Delete(characterAction);
            characterDatabase.SaveChanges();
        }

        private void AddCharacterCreationActions()
        {
            var characterActions = characterDatabase.GetRepository<CharacterAction>();

            List<PlayerCreateInfoAction> newCreateInfoActions = worldDatabase.GetRepository<PlayerCreateInfoAction>().Where(s => s.Race == Owner.Character.Race && s.Class == Owner.Character.Class).ToList();
            newCreateInfoActions.ForEach(a => characterActions.Add(new CharacterAction() { GUID = this.Owner.ObjectGUID.Low, Action = a.Action, Button = (byte)a.Button, Type = (byte) a.Type }));

            characterDatabase.SaveChanges();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<CharacterAction> GetEnumerator()
        {
            return this.characterDatabase.GetRepository<CharacterAction>().Where(ca => ca.GUID == Owner.ObjectGUID.Low).GetEnumerator();
        }
    }
}
