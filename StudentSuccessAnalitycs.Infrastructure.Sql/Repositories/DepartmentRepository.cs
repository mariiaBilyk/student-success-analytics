using System.Collections.Generic;
using Dapper;
using StudentSuccessAnalitycs.Infrastructure.Sql.Generic;
using StudentSuccessAnalytics.Domain.Models.UniversityModules;
using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Repositories {
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository {
        public override string TableName => DepartmentTableName;
        public string Id => "[id]";
        public string Name => "[name]";
        public string InstituteId => "[instituteId]";

        public IEnumerable<Department> GetByInstituteId ( int instituteId ) {
            using ( var connection = OpenConnection() ) {
                var sql = $@"SELECT * 
                             FROM {TableName} 
                             WHERE {InstituteId} = {instituteId}";
                var departments = connection.Query<Department>( sql );
                return departments;
            }
        }
    }
}