namespace TestWebAPI.Services.Interfaces
{
    public interface IEntityDatabaseTransaction : IDisposable
    {
        void Commit();
        void RollBack();
    }
}
