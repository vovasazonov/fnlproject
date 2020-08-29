/*  Файл описывает реализацию словаря значений:
 *  ключ - enum переменная, значение - строка, которая
 *  соответствует значению в базе данных.
 *  Сазонов Владимир Сергеевич.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */

using System;
using System.Collections.Generic;

namespace FNL.Dictionarys
{
    /// <summary>
    /// Dictionary that key is the uniq number month of elemnt and value is string word russin of element.
    /// </summary>
    static public class DictionaryMonths
    {
        static private readonly Dictionary<int, string> Dic = new Dictionary<int, string>
        {
            {1,"Января" },
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

        /// <summary>
        /// Get month in word russian notation instead number month.
        /// </summary>
        /// <param name="m">Number month.</param>
        /// <returns>Value word month.</returns>
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
