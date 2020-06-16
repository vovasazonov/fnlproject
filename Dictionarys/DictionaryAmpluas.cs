/*  Файл описывает реализацию словаря значений:
 *  ключ - enum переменная, значение - строка, которая
 *  соответствует значению в базе данных.
 *  Сазонов Владимир Сергеевич.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */

using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// Dictionary that key is the uniq id of elemnt and value is string name of element.
        /// </summary>
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
