using Newtonsoft.Json;

namespace Rulatte
{
    public class Labor
    {
        public Labor(string name)
        {
            this.name = name;
        }
        public string name { get; set; }
        public double weight { get; set; } = 1;
        public bool enabled { get; set; } = true;
        public string link { get; set; } = null;

        [JsonIgnore]
        public double effectiveWeight
        {
            get
            {
                return enabled ? weight : 0;
            }
        }
    }
}
