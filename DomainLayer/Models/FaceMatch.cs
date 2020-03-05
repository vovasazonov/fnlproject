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
    /// </summary>
	public class FaceMatch
	{
		public int FaceMatchId { get; set; }
        public int PersonId { get; set; }
        public int MatchId { get; set; }

		public virtual Person Person { get; set; }
		public virtual List<Match> Matches { get; set; }
	}
}
