using System;
using Adapters.Interfaces;
using Adapters.SecondOrmLibrary;

namespace Adapters.HomeWork
{
    public class SecondOrmClass : ISecondOrm
    {
        public ISecondOrmContext Context {

            get 
            {
                throw new NotImplementedException();
            }
        }
    }
}