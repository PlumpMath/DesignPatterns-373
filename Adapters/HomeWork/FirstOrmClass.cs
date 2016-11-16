using System;
using Adapters.FirstOrmLibrary;
using Adapters.Interfaces;

namespace Adapters.HomeWork
{
    public class FirstOrmClass : IFirstOrm<IDbEntity>
    {
        public void Create(IDbEntity entity)
        {
            throw new NotImplementedException();
        }

        public IDbEntity Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IDbEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IDbEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}