using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTQT.Satellite.Entity.Entity
{
    public abstract class BaseEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
    }
}