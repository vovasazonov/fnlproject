using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface ISeasonView : ISeasonIds
    {
        string SeasonName { get; set; }
    }

    public class CSeasonView : ISeasonView
    {
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
    }
}
