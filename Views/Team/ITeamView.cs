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
using System.Drawing;

namespace FNL.Views
{
	public interface ITeamView : ITeamIds
	{
		Color Color { get; set; }
        string NameFull { get; set; }
        string NameShort { get; set; }
        string PathLogo { get; set; }
	}

    /// <summary>
    /// Helper class to create object of interface.
    /// </summary>
    public class CTeamView : ITeamView
    {
        public int TeamId { get; set; }
        public Color Color { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public string PathLogo { get; set; }
    }
}
