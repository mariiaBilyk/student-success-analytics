using System.Collections.Generic;
using System.Linq;
using StudentSuccess.WebAPI.Models.UniversityModules;
using StudentSuccess.WebAPI.Services.Common;
using StudentSuccessAnalytics.Domain.Models.UniversityModules;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccess.WebAPI.Services {
    public class UniversityModulesService : ServiceBase {
        private IInstituteRepository InstituteRepository => UnitOfWork.InstituteRepository;
        private IDepartmentRepository DepartmentRepository => UnitOfWork.DepartmentRepository;
        private ITeacherRepository TeacherRepository => UnitOfWork.TeacherRepository;
        private ISubjectRepository SubjectRepository => UnitOfWork.SubjectRepository;

        public UniversityModulesService ( IUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        public IEnumerable<InstituteBindModel> GetInstitutes () {
            var institutesDb = InstituteRepository.GetAll();
            var institutes = institutesDb.Select( i => new InstituteBindModel {
                Id = i.Id,
                ShortName = i.ShortName
            } );

            return institutes;
        }

        public IEnumerable<DepartmentBindModel> GetInstituteDepartments ( int instituteId ) {
            var departmentsDb = DepartmentRepository.GetByInstituteId( instituteId );
            var departments = departmentsDb.Select( d => new DepartmentBindModel {
                Id = d.Id,
                Name = d.Name
            } );

            return departments;
        }

        public IEnumerable<DepartmentBindModel> GetDepartments () {
            var departmentsDb = DepartmentRepository.GetAll();
            var departments = departmentsDb.Select(d => new DepartmentBindModel {
                Id = d.Id,
                Name = d.Name
            });

            return departments;
        }

        public IEnumerable<TeacherInfoBindModel> GetDepartmentTeachers ( int departmentId ) {
            var teachersdb = TeacherRepository.GetByDepartmentId( departmentId );
            var teachers = teachersdb.Select( t => new TeacherInfoBindModel {
                Id = t.Id,
                FullName = t.FullName
            } );

            return teachers;
        }

        public IEnumerable<SubjectBindModel> GetTeacherSubjects ( int teacherId ) {
            var subjectsDb = SubjectRepository.GetSubjectsByTeacherId( teacherId );
            var subjects = subjectsDb.Select( s => new SubjectBindModel {
                Id = s.Id,
                Title = s.Name
            } );

            return subjects;
        }
    }
}