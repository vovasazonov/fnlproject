using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNL.Enums;
using ModelLayer;
using ModelLayer.Models;

namespace FNL.Dictionarys
{
    /// <summary>
    /// Dictionary that key is the uniq id of elemnt and value is string name of element.
    /// </summary>
    static public class DictionaryAmpluas
    {
        static internal readonly Dictionary<AmpluaType, string> Dic = new Dictionary<AmpluaType, string>
        {
            {AmpluaType.WithoutAmplua,"Без амплуа" },
            {AmpluaType.Goalkeeper,"Вратарь" }
        };

        /// <summary>
        /// Return uniq id of element type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static public int GetId(AmpluaType type)
        {
            using (var db = new DbFnlContext())
            {
                if (!db.Ampluas.Where(t => t.AmpluaId == (uint)type).Any())
                {
                    db.Ampluas.Add(new Amplua() { AmpluaId = (int)type, Name = Dic[type] });
                    db.SaveChanges();
                }
            }

            return (int)type;
        }

    }
}
