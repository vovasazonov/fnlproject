/*  Файл описывает сущность базы данных в виде класса.
 *  Сазонов Владимир Сергеевич.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer.Models
{
    /// <summary>
    /// Entity.
    /// </summary>
	public class Match
	{
		public int MatchId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
		public DateTime Date { get; set; }
        public int? StadiumId { get; set; }
        public int? SeasonId { get; set; }
        [ForeignKey("TeamGuest")]
        public int? TeamGuestId { get; set; }
        [ForeignKey("TeamOwner")]
        public int? TeamOwnerId { get; set; }

		public virtual Stadium Stadium { get; set; }
		public virtual Season Season { get; set; }
		public virtual Team TeamOwner { get; set; }
		public virtual Team TeamGuest { get; set; }
		public virtual List<FaceMatch> FaceMatch { get; set; }
		public virtual List<StatisticPlayerMatch> Statistics { get; set; }
        public virtual List<PlayerMatch> PlayersMatch { get; set; }
	}
}
