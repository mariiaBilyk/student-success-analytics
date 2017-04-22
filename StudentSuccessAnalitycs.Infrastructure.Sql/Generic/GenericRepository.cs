using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Generic {
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class {
        protected virtual string ConnectionString => string.Empty;

        public virtual string TableName => string.Empty;

        public TEntity GetById ( int id ) {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll () {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get ( Expression<Func<TEntity, bool>> predicate = null, List<string> includes = null ) {
            throw new NotImplementedException();
        }

        public string GradeViewName => string.Empty;
        public string StudentsViewName => string.Empty;
    }
}