namespace FNL.Views
{
    public interface IPlayerView : IPlayerId, IPersonView
    {
        int Number { get; set; }
        string Amplua { get; set; }
    }
}