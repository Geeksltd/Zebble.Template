using System.IO;
using System.Threading.Tasks;
using Domain.Models;
using Newtonsoft.Json;
using Olive;
using Zebble.Device;
using Zebble;
using System;

namespace Domain
{
    public static class Current
    {
        public readonly static AsyncEvent LoggedOut = new();
        internal static FileInfo UserFile => IO.File("ApplicationUser.json");
        internal static FileInfo SessionFile => IO.File("SessionToken.txt");

        public static User User { get; private set; }
        static Current()
        {
            try
            {
                if (UserFile.Exists() && SessionFile.Exists())
                {
                    User = JsonConvert.DeserializeObject<User>(UserFile.ReadAllText());
                }
            }
            catch
            {
                // No logging needed
            }
        }

        public static void Set(User user)
        {
            User = user;
            if (user is null) UserFile.Delete(harshly: true);
            else UserFile.WriteAllText(JsonConvert.SerializeObject(user));
        }

        internal static async Task ReloadUser()
        {
            var user = await Api.Authentication.GetCurrentUser();
            Set(user);
        }

        public static async Task Delete()
        {

            User = null;
            UserFile.Delete(harshly: true);
            SessionFile.Delete(harshly: true);
            await LoggedOut.Raise();
        }

        public static string GetCurrentSessionToken()
        {
            if (!SessionFile.Exists()) return null;
            return SessionFile.ReadAllText();
        }
    }
}
