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
	/// Say what is the role of person in position value.
	/// It can be like commentator, judje, attcker, defender and etc.
	/// </summary>
	public class Person
	{
		public int PersonId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string PhotoPath { get; set; } 
		public Address Address { get; set; }
        public int? RoleId { get; set; }

		public virtual Role Role { get; set; }
		public virtual List<TeamPlayer> TeamPlayers { get; set; }
		public virtual List<FaceMatch> FacesMatches { get; set; }
		public virtual List<StatisticPlayerMatch> Statistics { get; set; }
        public virtual List<PlayerMatch> PlayerMatches { get; set; }

	}
}
