using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNL.Views
{
    public interface IStadiumView : IStadiumIds
    {
        string StadiumName { get; set; }
        string CountryName { get; set; }
        string CityName { get; set; }
    }

    public class CStadiumView : IStadiumView
    {
        public string StadiumName { get; set; }
        public int StadiumId { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }

}
