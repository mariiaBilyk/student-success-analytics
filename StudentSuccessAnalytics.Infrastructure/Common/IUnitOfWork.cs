using System;
using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccessAnalytics.Infrastructure.Common {
    public interface IUnitOfWork : IDisposable {
        IGradeRepository GradeRepository { get; }
        IInstituteRepository InstituteRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        ITeacherRepository TeacherRepository { get; }
    }
}
