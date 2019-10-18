using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface ITablePlayersMainView
    {
        int PersonId { get; set; }
        int N { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string R { get; set; }
        Color K { get; set; }
        string A { get; set; }
    }

    public class ClassTablePlayersMainView : ITablePlayersMainView
    {
        int ITablePlayersMainView.PersonId { get; set; }
        int ITablePlayersMainView.N { get; set; }
        string ITablePlayersMainView.LastName { get; set; }
        string ITablePlayersMainView.FirstName { get; set; }
        string ITablePlayersMainView.R { get; set; }
        Color ITablePlayersMainView.K { get; set; }
        string ITablePlayersMainView.A { get; set; }
    }
}
