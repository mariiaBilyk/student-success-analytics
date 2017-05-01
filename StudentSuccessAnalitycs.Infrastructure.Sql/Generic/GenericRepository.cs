using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Generic {
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: class {
        protected virtual string ConnectionString => string.Empty;

        public virtual string TableName => string.Empty;

        public TEntity GetById ( string tableName, string idName, int id ) {
            using ( var connection = OpenConnection() ) {
                var sql = $@"SELECT * 
                             FROM {tableName} 
                             WHERE {idName} = {id}";

                var entry = connection.Query<TEntity>(sql);
                return entry.FirstOrDefault();
            }
        }

        public virtual IEnumerable<TEntity> GetAll ( string tableName ) {
            using ( var connection = OpenConnection() ) {
                var sql = $@"SELECT * FROM {tableName}";
                var entries = connection.Query<TEntity>(sql);
                return entries;
            }
        }

        public string GradeViewName => string.Empty;
        public string StudentsViewName => string.Empty;
        public string InstituteTableName => "[dbo].[Institute]";
        public string DepartmentTableName => "[dbo].[Department]";
        public string TeacherTableName => "[dbo].[Teacher]";

        protected SqlConnection OpenConnection () {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}