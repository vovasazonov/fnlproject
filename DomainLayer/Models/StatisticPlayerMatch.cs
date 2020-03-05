/*  Файл описывает сущность базы данных в виде класса.
 *  Сазонов Владимир Сергеевич.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */

using System.Collections.Generic;

namespace ModelLayer.Models
{
	/// <summary>
    /// Entity.
	/// Statistic of player in current match.
	/// </summary>
	public class StatisticPlayerMatch
	{
		public int StatisticPlayerMatchId { get; set; }
		public int MatchId { get; set; }
		public int PersonId { get; set; }

		public virtual Match Match { get; set; }
		public virtual Person Person { get; set; }
		public virtual List<EventStatistic> EventStatistics { get; set; }
	}
}
