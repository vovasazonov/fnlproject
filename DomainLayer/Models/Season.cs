/*  Файл описывает сущность базы данных в виде класса.
 *  Сазонов Владимир Сергеевич.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
    /// <summary>
    /// Entity.
    /// </summary>
	public class Season
	{
		public int SeasonId { get; set; }
        [Required]
		public string Name { get; set; }

		public virtual List<Match> Matches { get; set; }
	}
}
