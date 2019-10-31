namespace FNL.Views
{
    public interface IMatchIds
    {
        int MatchId { get; set; }
        int StadiumId { get; set; }
        int GuestTeamId { get; set; }
        int OwnerTeamId { get; set; }
        int SeasonId { get; set; }
        int Commentator1Id { get; set; }
        int Commentator2Id { get; set; }
        int MainJudjeId { get; set; }
        int HelperJudje1Id { get; set; }
        int HelperJudje2Id { get; set; }
        int PairJudjeId { get; set; }
        int InspectorId { get; set; }
        int DelegatId { get; set; }
    }
}