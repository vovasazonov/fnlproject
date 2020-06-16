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
    public interface IInsertMatchPlayersView
    {
        int PersonId { get; set; }
        bool IsPair { get; set; }
        int NumberTrainers { get; set; }
        int NumberPlayers { get; set; }
        int NumberPairsPlayers { get; set; }
    }
}
