using System.Collections.Generic;
using StudentSuccessAnalytics.Domain.Models.UniversityModules;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalytics.Infrastructure.Names;

namespace StudentSuccessAnalytics.Infrastructure.Repositories {
    public interface IDepartmentRepository : IGenericRepository<Department>, IDepartmentRepositoryName {
        IEnumerable<Department> GetByInstituteId ( int instituteId );
    }
}