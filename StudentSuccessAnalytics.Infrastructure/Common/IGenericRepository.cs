using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using StudentSuccessAnalytics.Infrastructure.Names.Common;

namespace StudentSuccessAnalytics.Infrastructure.Common {
    public interface IGenericRepository<TEntity> : IRepositoryTableName where TEntity:class {
        TEntity GetById ( int id );
        IEnumerable<TEntity> GetAll ();
        IEnumerable<TEntity> Get ( Expression<Func<TEntity, bool>> predicate = null, List<string> includes = null );
    }
}