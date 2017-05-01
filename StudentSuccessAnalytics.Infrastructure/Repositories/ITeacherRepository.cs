using System.Collections;
using System.Collections.Generic;
using StudentSuccessAnalytics.Domain.Models.Teachers;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalytics.Infrastructure.Names;

namespace StudentSuccessAnalytics.Infrastructure.Repositories {
    public interface ITeacherRepository : IGenericRepository<Teacher>, ITeacherRepositoryNames {
        IEnumerable<Teacher> GetByDepartmentId ( int departmentId );
    }
}