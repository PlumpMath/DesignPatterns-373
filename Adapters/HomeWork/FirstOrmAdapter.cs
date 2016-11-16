using Adapters;
using Adapters.FirstOrmLibrary;
using Adapters.Interfaces;

namespace Adapters.HomeWork
{
    public class FirstOrmAdapter : FirstOrmClass, ICommonOrm<IDbEntity>
    {
        public void Remove(IDbEntity entity)
        {
            this.Delete(entity);
        }
    }
}