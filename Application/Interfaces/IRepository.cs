using Domain.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : AggregateRoot
    {
        TEntity GetById(TKey id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
