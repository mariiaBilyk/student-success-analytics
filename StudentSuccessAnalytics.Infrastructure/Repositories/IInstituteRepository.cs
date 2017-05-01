using System.Collections;
using System.Collections.Generic;
using StudentSuccessAnalytics.Domain.Models.UniversityModules;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalytics.Infrastructure.Names;

namespace StudentSuccessAnalytics.Infrastructure.Repositories {
    public interface IInstituteRepository : IGenericRepository<Institute>, IInstituteRepositoryNames {
        IEnumerable<Institute> GetAll ();
    }
}