/*  Файл описывает сущность базы данных в виде класса.
 *  Сазонов Владимир Сергеевич.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */

namespace ModelLayer.Models
{
    /// <summary>
    /// Entity.
    /// </summary>
	public class PlayerMatch
	{
		public int PlayerMatchId { get; set; }
		public bool IsSpare { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PersonId { get; set; }

		public virtual Match Match { get; set; }
		public virtual Team Team { get; set; }
		public virtual Person Person { get; set; }
	}
}
