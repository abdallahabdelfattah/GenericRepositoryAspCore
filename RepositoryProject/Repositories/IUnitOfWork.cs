using System.Threading.Tasks;

namespace RepositoryProject.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICutomerRepository Customers { get; }
        Task CompleteAsync();

    }
}
