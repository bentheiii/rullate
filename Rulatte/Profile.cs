using System.Collections.Generic;
using System.IO;
using System.Text;
using CipherStone;
using Newtonsoft.Json;

namespace Rulatte
{
    public class Profile
    {
        public static readonly IFormatter<Profile> Formatter = new JsonFormatter<Profile>(Encoding.UTF8, Formatting.Indented);
        public Profile(string name, string sourcePath)
        {
            this.name = name;
            this.sourcePath = sourcePath;
        }
        public IList<Labor> labors { get; } = new List<Labor>();

        public string name { get; set; }
        [JsonIgnore]
        public string sourcePath { get; set; }

        public void save()
        {
            using (var write = new FileStream(sourcePath,FileMode.Create, FileAccess.Write))
            {
                Formatter.Serialize(this, write);
            }
        }
    }
}
