namespace InVivo.Infrastructure.Transactions
{
    public interface IUow
    {
        void Commit();
        void Rollback();
    }
}
