using System;
using System.Collections;
using System.Collections.Generic;
using StudentSuccessAnalytics.Domain.Models.Grades;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalytics.Infrastructure.Names;

namespace StudentSuccessAnalytics.Infrastructure.Repositories {
    public interface IGradeRepository : IRepository<Grade>, IGradeRepositoryNames {
        IEnumerable<GradeChartItem> GetInstituteGradeChart ( int subjectId, int teacherId, int departmentId,
                                                                    DateTime startDate, DateTime endDate,
                                                                    ISubjectRepositoryNames subjectRepository,
                                                                    ITeacherRepositoryNames teacherRepository );
    }
}