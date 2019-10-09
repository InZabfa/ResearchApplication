using System.Collections.Generic;
using System.Linq;

namespace SharedObjects.DesignGame
{
    public class Difficulties
    {
        public Dictionary<int, string> Values { get; set; }
        public Difficulties(params KeyValuePair<int, string>[] difficulties) : this() => difficulties.ToList().ForEach(i => Values.Add(i.Key, i.Value));

        public Difficulties()
        {
            Values = new Dictionary<int, string>();
        }
    }
}
