namespace DAL.Interfaces
{
    public interface IDbContextFactory
    {
         IDbContext DbContext { get; }
    }
}
