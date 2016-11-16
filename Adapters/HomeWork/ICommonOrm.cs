using System.Collections.Generic;
using Adapters.Interfaces;

namespace Adapters.HomeWork
{
    public interface ICommonOrm<TDbEntity> where TDbEntity : IDbEntity
    {
        void Create(TDbEntity entity);
        TDbEntity Read(int id);
        void Update(TDbEntity entity);
        void Remove(TDbEntity entity);
    }
}