using Adapters;
using Adapters.SecondOrmLibrary;
using Adapters.Interfaces;
using Adapters.Models;

namespace Adapters.HomeWork
{
    public class SecondOrmAdpter : SecondOrmClass, ICommonOrm<IDbEntity>
    {
        public void Create(IDbEntity entity)
        {
            this.Context.Users.Add(new DbUserEntity(){Id = entity.Id});
            this.Context.UserInfos.Add(new DbUserInfoEntity(){Id = entity.Id});
        }

        public IDbEntity Read(int id)
        {
            foreach (var item in this.Context.Users)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void Update(IDbEntity entity)
        {
            Remove(entity);
            Create(entity);
        }

        public void Remove(IDbEntity entity)
        {

            this.Context.Users.RemoveWhere(x => x.Id == entity.Id);
            this.Context.UserInfos.RemoveWhere(x => x.Id == entity.Id);
        }
    }
}