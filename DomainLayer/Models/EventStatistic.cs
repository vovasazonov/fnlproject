/*  Файл описывает сущность базы данных в виде класса.
 *  Сазонов Владимир Сергеевич.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */

using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer.Models
{
	/// <summary>
    /// Entity.
	/// Concret event that appear in concret time.
	/// </summary>
	public class EventStatistic
	{
		public int EventStatisticId { get; set; }
		[Required]
		public DateTime Time { get; set; }
		[Required]
		public int HalfMatch { get; set; }
        public int StatisticPlayerMatchId { get; set; }
        public int EventId { get; set; }

        public virtual StatisticPlayerMatch StatisticPlayerMatch { get; set; }
		public virtual Event Event { get; set; }
	}
}
