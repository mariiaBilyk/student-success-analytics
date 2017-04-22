using StudentSuccessAnalytics.Domain.Models.Grades;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalytics.Infrastructure.Names;

namespace StudentSuccessAnalytics.Infrastructure.Repositories {
    public interface IGradeRepository : IRepository<Grade>, IGradeRepositoryNames {

    }
}