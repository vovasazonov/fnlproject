using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL
{
    static class DictionaryRoles
    {
        static public readonly Dictionary<Roles, string> Role = new Dictionary<Roles, string>
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

        public enum Roles
        {
            Player,
            MainTrainer,
            Commentator,
            MainJudje,
            HelperJudje,
            PairJudje,
            Inspector,
            Delegat
        }
    }
}
