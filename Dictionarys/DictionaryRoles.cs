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
    static public class DictionaryRoles
    {
        /// <summary>
        /// Dictionary that key is the uniq id of elemnt and value is string name of element.
        /// </summary>
        static public readonly Dictionary<RoleType, string> Dic = new Dictionary<RoleType, string>
        {
            {RoleType.Player,"Игрок" },
            {RoleType.MainTrainer,"Главный тренер" },
            {RoleType.Commentator,"Комментатор" },
            {RoleType.MainJudje,"Главный судья" },
            {RoleType.HelperJudje,"Помощник судьи" },
            {RoleType.PairJudje,"Резервный судья" },
            {RoleType.Inspector,"Инспектор" },
            {RoleType.Delegat,"Делегат" }
        };

        /// <summary>
        /// Return uniq id of element type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        static public int GetId(RoleType type)
        {
            using (var db = new DbFnlContext())
            {
                if (!db.Roles.Where(t => t.RoleId == (uint)type).Any())
                {
                    db.Roles.Add(new Role() { RoleId = (int)type, Name = Dic[type] });
                    db.SaveChanges();
                }
            }

            return (int)type;
        }

    }
}
