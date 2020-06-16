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
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public string LogotypePath { get; set; }
        public int Color { get; set; }

        public virtual List<TeamPlayer> TeamPlayers { get; set; }
        public virtual List<Match> Matches { get; set; }
        public virtual List<PlayerMatch> PlayersMatches {get;set;}
	}
}
