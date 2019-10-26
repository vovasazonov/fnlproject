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
