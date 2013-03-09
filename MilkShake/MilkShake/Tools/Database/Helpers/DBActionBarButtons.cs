using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.Database.Helpers
{
    class DBActionBarButtons
    {
        public static TableQuery<CharacterActionBarButton> CharacterActionBarButtonQuery
        {
            get { return DB.SQLite.Table<CharacterActionBarButton>(); }
        }

        public static TableQuery<CharacterCreationActionBarButton> CharacterCreationActionBarButtonQuery
        {
            get { return DB.SQLite.Table<CharacterCreationActionBarButton>(); }
        }

        public static List<CharacterActionBarButton> GetActionBarButtons(Character character)
        {

            List<CharacterActionBarButton> result = CharacterActionBarButtonQuery.Where(cabb => cabb.GUID == character.GUID).ToList();
            if (result.Count == 0)
            {
                List<CharacterCreationActionBarButton> newCharacterActionBarButtons = CharacterCreationActionBarButtonQuery.Where(ccabb => ccabb.Race == character.Race && ccabb.Class == character.Class).ToList();
                newCharacterActionBarButtons.ForEach(ncabb =>
                {
                    CharacterActionBarButton actionBarButton = new CharacterActionBarButton() { GUID = character.GUID, Action = ncabb.Action, Button = ncabb.Button, Type = ncabb.Type};
                    DB.SQLite.Insert(actionBarButton);
                    result.Add(actionBarButton);
                });
            }
            return result;
        }

        public static CharacterActionBarButton GetActionBarButton(Character character, int action, int button, int type)
        {
            return CharacterActionBarButtonQuery.First(cabb => cabb.GUID == character.GUID && cabb.Action == action && cabb.Button == button && cabb.Type == type);
        }

        public static void AddActionBarButton(Character character, int action, int button, int type)
        {
            if (GetActionBarButton(character, action, button, type) == null)
                DB.SQLite.Insert(new CharacterActionBarButton() { GUID = character.GUID, Action = action, Button = button, Type = type });
        }

        public static void RemoveActionBarButton(Character character, int action, int button, int type)
        {
            DB.SQLite.Delete(GetActionBarButton(character, action, button, type));
        }
    }
}
