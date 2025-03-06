using Newtonsoft.Json;

namespace RHiDv2_E2E_Tests
{
    public static class Utils
    {
        private static string path = $"{Directory.GetCurrentDirectory()}\\.env";
        public static string TestUrl
        {
            get
            {
                if (!File.Exists(path)) throw new InvalidOperationException(".env does not exist");
                string json = String.Empty;
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream))
                    json = reader.ReadToEnd();

                var credentials = JsonConvert.DeserializeObject<Credentials>(json);
                if (credentials == null) throw new InvalidOperationException("Failed to deserialize credentials");
                return credentials.Url;
            }
        }

        public static string Login
        {
            get
            {
                if (!File.Exists(path)) throw new InvalidOperationException(".env does not exist");
                string json = String.Empty;
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream))
                    json = reader.ReadToEnd();

                var credentials = JsonConvert.DeserializeObject<Credentials>(json);
                if (credentials == null) throw new InvalidOperationException("Failed to deserialize credentials");
                return credentials.Login;
            }
        }

        public static string Password
        {
            get
            {
                if (!File.Exists(path)) throw new InvalidOperationException(".env does not exist");
                string json = String.Empty;
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (var reader = new StreamReader(stream))
                    json = reader.ReadToEnd();

                var credentials = JsonConvert.DeserializeObject<Credentials>(json);
                if (credentials == null) throw new InvalidOperationException("Failed to deserialize credentials");
                return credentials.Password;
            }
        }
    }

    public class Credentials
    {
        public required string Login { get; set; }
        public required string Password { get; set; }
        public required string Url { get; set; }
    }
}
