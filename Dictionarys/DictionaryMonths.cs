using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Dictionarys
{
    static public class DictionaryMonths
    {
        static private readonly Dictionary<int, string> Dic = new Dictionary<int, string>
        {
            {1,"Янаваря" },
            {2,"Февраля" },
            {3,"Марта" },
            {4,"Апреля" },
            {5,"Мая" },
            {6,"Июня" },
            {7,"Июля" },
            {8,"Августа"},
            {9,"Сентября" },
            {10,"Октября" },
            {11,"Ноября" },
            {12,"Декабря" }
        };

        static internal string GetNameMonth(int m)
        {
            string month = "";

            try
            {
                month = Dic[m];
            }
            catch (Exception)
            {
                month = "";
            }

            return month;
        }
    }
}
