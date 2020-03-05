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

    public interface IMatchView : IMatchIds
    {
        string NameMatch { get; set; }
        DateTime Date { get; set; }
        String NameStadium { get; set; }
        String NameSeason { get; set; }
        String NameTeamGuest { get; set; }
        int GoalsGuest { get; set; }
        String NameTeamHome { get; set; }
        int GoalsOwner { get; set; }
        string Commentators1 { get; set; }
        string Commentators2 { get; set; }
        string MainJudje { get; set; }
        string HelperJudje1 { get; set; }
        string HelperJudje2 { get; set; }
        string PairJudje { get; set; }
        string Inspector { get; set; }
        string Delegat { get; set; }
    }

    /// <summary>
    /// Helper class for to create exemplar of interface via class.
    /// </summary>
    public class CMatchTableView : IMatchView
    {
        public string NameMatch { get; set; }
        public DateTime Date { get; set; }
        public string NameStadium { get; set; }
        public string NameSeason { get; set; }
        public string NameTeamGuest { get; set; }
        public int GoalsGuest { get; set; }
        public string NameTeamHome { get; set; }
        public int GoalsOwner { get; set; }
        public string Commentators1 { get; set; }
        public string Commentators2 { get; set; }
        public string MainJudje { get; set; }
        public string HelperJudje1 { get; set; }
        public string HelperJudje2 { get; set; }
        public string PairJudje { get; set; }
        public string Inspector { get; set; }
        public string Delegat { get; set; }
        public int MatchId { get; set; }
        public int StadiumId { get; set; }
        public int GuestTeamId { get; set; }
        public int OwnerTeamId { get; set; }
        public int SeasonId { get; set; }
        public int Commentator1Id { get; set; }
        public int Commentator2Id { get; set; }
        public int MainJudjeId { get; set; }
        public int HelperJudje1Id { get; set; }
        public int HelperJudje2Id { get; set; }
        public int PairJudjeId { get; set; }
        public int InspectorId { get; set; }
        public int DelegatId { get; set; }
    }

}
