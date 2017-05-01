using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using StudentSuccessAnalytics.Infrastructure.Names.Common;

namespace StudentSuccessAnalytics.Infrastructure.Common {
    public interface IGenericRepository<TEntity> : IRepositoryTableName where TEntity:class {
        TEntity GetById ( string tableName, string idName, int id );
        IEnumerable<TEntity> GetAll ( string tableName );
    }
}