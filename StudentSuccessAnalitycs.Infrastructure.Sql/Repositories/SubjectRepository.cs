using System.Collections.Generic;
using Dapper;
using StudentSuccessAnalitycs.Infrastructure.Sql.Generic;
using StudentSuccessAnalytics.Domain.Models.Grades;
using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Repositories {
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository {
        public override string TableName => "[dbo].[Subject]";
        public string Id => "[id]";
        public string Name => "[name]";
        public string TeacherId => "[teacherId]";
        public string TypeControl => "[typeControl]";
        public string EctsCredits => "[ectsCredits]";

        public IEnumerable<Subject> GetSubjectsByTeacherId ( int teacherId ) {
            using ( var connection = OpenConnection() ) {
                var sql = $@"SELECT * 
                             FROM {TableName} 
                             WHERE {TeacherId} = {teacherId}";
                var subjects = connection.Query<Subject>(sql);
                return subjects;
            }
        }
    }
}