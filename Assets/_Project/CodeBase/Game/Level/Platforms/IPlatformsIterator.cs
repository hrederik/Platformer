namespace CodeBase.Game.Level.Platforms
{
    public interface IPlatformsIterator
    {
        bool HasNextPlatform { get; }
        bool HasPreviousPlatform { get; }
        Platform GetNextPlatform();
        Platform GetCurrentPlatform();
        Platform GetPreviousPlatform();
    }
}