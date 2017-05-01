using System.Collections.Generic;
using Dapper;
using StudentSuccessAnalitycs.Infrastructure.Sql.Generic;
using StudentSuccessAnalytics.Domain.Models.Teachers;
using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Repositories {
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository {
        public override string TableName => TeacherTableName;
        public string Id => "[id]";
        public string FullName => "[fullName]";
        public string DepartmentId => "[departmentId]";

        public IEnumerable<Teacher> GetByDepartmentId ( int departmentId ) {
            using ( var connection = OpenConnection() ) {
                var sql = $@"SELECT * 
                             FROM {TableName}
                             WHERE {DepartmentId} = {departmentId}";

                var teachers = connection.Query<Teacher>( sql );
                return teachers;
            }
        }
    }
}