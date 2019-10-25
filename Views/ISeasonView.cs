using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface ISeasonView
    {
        int SeasonId { get; set; }
        string SeasonName { get; set; }
    }

    public class ClassSeasonView : ISeasonView
    {
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
    }
}
