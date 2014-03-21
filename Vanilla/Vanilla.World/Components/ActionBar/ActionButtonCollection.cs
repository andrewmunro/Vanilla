using System.Collections.Generic;
using System.Linq;

using Vanilla.Character.Database;
using Vanilla.World.Database;

namespace Vanilla.World.Components.ActionBar
{
    using System.Collections;

    using Vanilla.Core.IO;
    using Vanilla.World.Game.Entity.Object.Player;

    public class ActionButtonCollection : IEnumerable<character_action>
    {
        public PlayerEntity Owner { get; private set; }

        private DatabaseUnitOfWork<CharacterDatabase> CharacterDatabase
        {
            get { return Owner.Session.Core.CharacterDatabase; }
        }

        private IRepository<character_action> CharacterActions
        {
            get { return CharacterDatabase.GetRepository<character_action>(); }
        }

        private IRepository<playercreateinfo_action> PlayerCreateActions
        {
            get { return Owner.Session.Core.WorldDatabase.GetRepository<playercreateinfo_action>(); }
        }

        public ActionButtonCollection(PlayerEntity playerEntity)
        {
            Owner = playerEntity;

            var characterActions = CharacterActions.Where(cs => cs.guid == Owner.Character.guid).ToList();
            //Must be a new character, get initial spells
            if (characterActions.Count == 0) AddCharacterCreationActions();
        }

        public void AddActionButton(character_action characterAction)
        {
            CharacterActions.Add(characterAction);
            CharacterDatabase.SaveChanges();
        }

        public void RemoveActionButton(byte button)
        {
            var characterAction = CharacterActions.SingleOrDefault(ca => ca.guid == Owner.ObjectGUID.Low && ca.button == button);
            RemoveActionButton(characterAction);
        }

        public void RemoveActionButton(character_action characterAction)
        {
            CharacterActions.Delete(characterAction);
            CharacterDatabase.SaveChanges();
        }

        private void AddCharacterCreationActions()
        {
            List<playercreateinfo_action> newCreateInfoActions = PlayerCreateActions.Where(s => s.race == Owner.Character.race && s.@class == Owner.Character.@class).ToList();
            newCreateInfoActions.ForEach(a => CharacterActions.Add(new character_action() { guid = this.Owner.ObjectGUID.Low, action = a.action, button = (byte)a.button, type = (byte) a.type }));

            CharacterDatabase.SaveChanges();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<character_action> GetEnumerator()
        {
            return CharacterActions.Where(ca => ca.guid == Owner.ObjectGUID.Low).GetEnumerator();
        }
    }
}
