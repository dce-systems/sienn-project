using System;

namespace SIENN.DbAccess.Abstractions
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        DateTimeOffset Created { get; set; }

        DateTimeOffset Updated { get; set; }
    }
}
