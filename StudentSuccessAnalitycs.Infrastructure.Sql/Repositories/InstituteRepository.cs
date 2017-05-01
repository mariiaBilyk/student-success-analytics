using System.Collections.Generic;
using StudentSuccessAnalitycs.Infrastructure.Sql.Generic;
using StudentSuccessAnalytics.Domain.Models.UniversityModules;
using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Repositories {
    public class InstituteRepository : GenericRepository<Institute>, IInstituteRepository {
        public override string TableName => InstituteTableName;

        public IEnumerable<Institute> GetAll ( ) {
            return base.GetAll( TableName );
        }

        public string Id => "[id]";
        public string Name => "[name]";
        public string ShortName => "[shortName]";
    }
}