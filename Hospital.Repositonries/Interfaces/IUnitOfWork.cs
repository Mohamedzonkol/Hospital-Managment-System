namespace Hospital.Repositonries.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepositonries<T> genericRepositonries<T>() where T : class;
        void Save();
    }
}