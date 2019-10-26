using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL
{
    static class DictionaryAmpluas
    {
        static public readonly Dictionary<Ampluas, string> AmpluaDic = new Dictionary<Ampluas, string>
        {
            {Ampluas.WithoutAmplua,"Без амплуа" },
            {Ampluas.Goalkeeper,"Вратарь" }
        };

        public enum Ampluas : uint
        {
            WithoutAmplua = 32432423,
            Goalkeeper = 24343243
        }
    }
}
