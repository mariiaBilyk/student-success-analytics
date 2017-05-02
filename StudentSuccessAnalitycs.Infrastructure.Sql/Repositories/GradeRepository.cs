using System;
using System.Collections.Generic;
using Dapper;
using StudentSuccessAnalitycs.Infrastructure.Sql.Generic;
using StudentSuccessAnalytics.Domain.Models.Grades;
using StudentSuccessAnalytics.Infrastructure.Names;
using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Repositories {
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository {
        public override string TableName => GradeViewName;

        public IEnumerable<GradeChartItem> GetInstituteGradeChart ( int subjectId, int teacherId, int departmentId, 
                                                                    DateTime startDate, DateTime endDate, 
                                                                    ISubjectRepositoryNames subjectRepository, 
                                                                    ITeacherRepositoryNames teacherRepository ) {
            var sql = $@"SELECT {TotalMark}, COUNT(*)
                        FROM {TableName} m";

            if ( subjectId > 0 ) {
                sql += $@"WHERE {SubjectId} = {subjectId}";
            } else {
                sql += $@"JOIN {SubjectTableName} s ON s.{subjectRepository.Id} = m.{SubjectId}";
                sql += teacherId > 0
                    ? $@"JOIN {TeacherTableName} t ON t.{teacherRepository.Id} = s.{subjectRepository.TeacherId}
                         WHERE t.{teacherRepository.DepartmentId} = {departmentId}"
                    : $@"WHERE s.{subjectRepository.TeacherId} = {teacherId}";
            }

            sql += $@"GROUP BY m.{TotalMark}";

            using ( var connection = OpenConnection() ) {
                var data = connection.Query<GradeChartItem>( sql );

                return data;
            }
        }

        public string SubjectId => "[subjectId]";
        public string Semester => "[semester]";
        public string TotalMark => "[totalMark]";
        public string K => "[K]";
        public string RepeatStuding => "[repeatStuding]";
        public string DepartmentId => "[departmentId]";
        public string StudentId => "[studentId]";
        public string Id => "[id]";
        public string AssessmentDate => "[assessmentDate]";
    }
}