using System;
using StudentSuccessAnalitycs.Infrastructure.Sql.Repositories;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Generic {
    public class UnitOfWork : IUnitOfWork {
        private IGradeRepository _gradeRepository;
        private IInstituteRepository _instituteRepository;
        private IDepartmentRepository _departmentRepository;
        private ITeacherRepository _teacherRepository;

        public IGradeRepository GradeRepository
            => _gradeRepository ?? (_gradeRepository = new GradeRepository());

        public IInstituteRepository InstituteRepository
            => _instituteRepository ?? (_instituteRepository = new InstituteRepository());

        public IDepartmentRepository DepartmentRepository
            => _departmentRepository ?? (_departmentRepository = new DepartmentRepository());

        public ITeacherRepository TeacherRepository
            => _teacherRepository ?? (_teacherRepository = new TeacherRepository());

        public void Dispose () {
            GC.SuppressFinalize(this);
        }

    }
}