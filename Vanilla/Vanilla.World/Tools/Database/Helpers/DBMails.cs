using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace Vanilla.World.Tools.Database.Helpers
{
    public class DBMails
    {
        public static TableQuery<CharacterMail> MailQuery
        {
            get { return DB.Character.Table<CharacterMail>(); }
        }

        public static List<CharacterMail> GetCharacterMails(Character Character)
        {
            return MailQuery.ToList().FindAll(s => s.Reciever == Character.GUID);
        }

        public static void AddMail(CharacterMail Mail)
        {
            DB.Character.Insert(Mail);
        }

        public static void AddMail()
        {
            AddMail(new CharacterMail() {  });
        }

        public static void RemoveMail(CharacterMail Mail)
        {
            DB.Character.Delete(Mail);
        }
    }
}
