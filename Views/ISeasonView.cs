/*  Файл View (паттерн Model View Presenter).
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface ISeasonView : ISeasonIds
    {
        string SeasonName { get; set; }
    }

    public class CSeasonView : ISeasonView
    {
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
    }
}
