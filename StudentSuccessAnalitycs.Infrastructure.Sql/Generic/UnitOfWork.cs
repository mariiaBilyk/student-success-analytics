using System;
using StudentSuccessAnalitycs.Infrastructure.Sql.Repositories;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Generic {
    public class UnitOfWork : IUnitOfWork {
        private IGradeRepository _gradeRepository;

        public IGradeRepository GradeRepository
            => _gradeRepository ?? (_gradeRepository = new GradeRepository());

        public void Dispose () {
            GC.SuppressFinalize(this);
        }
    }
}