using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using StudentSuccess.WebAPI.Models.UniversityModules;
using StudentSuccess.WebAPI.Services;
using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccess.WebAPI.Controllers {
    [RoutePrefix ( "api/teacher" )]
    public class TeacherController : ApiController {
        private readonly UniversityModulesService _universityModulesService;

        public TeacherController ( IUnitOfWork unitOfWork ) {
            _universityModulesService = new UniversityModulesService( unitOfWork );
        }

        [HttpGet]
        [ResponseType ( typeof( IEnumerable<TeacherInfoBindModel> ) )]
        public IHttpActionResult GetTeachers ( int departmentId ) {
            if ( departmentId <= 0 ) return BadRequest( "The department is is not in the valid format!" );

            var teachers = _universityModulesService.GetDepartmentTeachers( departmentId );

            return teachers != null ? ( IHttpActionResult ) Ok( teachers ) : NotFound();
        }
    }
}