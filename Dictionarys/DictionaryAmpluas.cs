using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL
{
    static class DictionaryAmpluas
    {
        static readonly Dictionary<Ampluas, string> Role = new Dictionary<Ampluas, string>
        {
            {Ampluas.Goalkeeper,"Вратарь" }
        };

        enum Ampluas
        {
            Goalkeeper
        }
    }
}
