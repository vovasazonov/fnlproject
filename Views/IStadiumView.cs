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
    public interface IStadiumView : IStadiumIds
    {
        string StadiumName { get; set; }
        string CountryName { get; set; }
        string CityName { get; set; }
    }

    public class CStadiumView : IStadiumView
    {
        public string StadiumName { get; set; }
        public int StadiumId { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }

}
