using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.Database.Helpers
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

        public static void RemoveMail(CharacterMail Mail)
        {
            DB.Character.Delete(Mail);
        }
    }
}
