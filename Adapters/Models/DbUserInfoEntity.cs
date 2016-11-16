using System;
using Adapters;
using Adapters.Interfaces;

namespace Adapters.Models
{
    public class DbUserInfoEntity : IDbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
    }
}
