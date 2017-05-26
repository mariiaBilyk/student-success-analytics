using System.Collections;
using System.Collections.Generic;
using StudentSuccessAnalytics.Domain.Models.Grades;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalytics.Infrastructure.Names;

namespace StudentSuccessAnalytics.Infrastructure.Repositories {
    public interface ISubjectRepository: IGenericRepository<Subject>, ISubjectRepositoryNames {
        IEnumerable<Subject> GetSubjectsByTeacherId ( int teacherId );
    }
}