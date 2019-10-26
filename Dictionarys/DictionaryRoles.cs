using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL
{
    static class DictionaryRoles
    {
        static public readonly Dictionary<Roles, string> RoleDic = new Dictionary<Roles, string>
        {
            {Roles.Player,"Игрок" },
            {Roles.MainTrainer,"Главный тренер" },
            {Roles.Commentator,"Комментатор" },
            {Roles.MainJudje,"Главный судья" },
            {Roles.HelperJudje,"Помощник судьи" },
            {Roles.PairJudje,"Резервный судья" },
            {Roles.Inspector,"Инспектор" },
            {Roles.Delegat,"Делегат" }
        };

        public enum Roles : uint
        {
            Player = 7765731,
            MainTrainer = 78768678,
            Commentator = 3454366,
            MainJudje = 47656567,
            HelperJudje= 2342453,
            PairJudje = 4354354,
            Inspector = 345435345,
            Delegat = 1233213
        }
    }
}
