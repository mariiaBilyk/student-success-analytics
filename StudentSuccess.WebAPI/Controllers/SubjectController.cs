using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using StudentSuccess.WebAPI.Models.UniversityModules;
using StudentSuccess.WebAPI.Services;
using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccess.WebAPI.Controllers {
    [RoutePrefix ( "subject" )]
    public class SubjectController : ApiController {
        private readonly UniversityModulesService _universityModulesService;

        public SubjectController ( IUnitOfWork unitOfWork ) {
            _universityModulesService = new UniversityModulesService( unitOfWork );
        }

        [HttpGet]
        [ResponseType ( typeof( IEnumerable<SubjectBindModel> ) )]
        public IHttpActionResult GetSubjectsByTeacherId ( int teacherId ) {
            if ( teacherId <= 0 ) return BadRequest( "The techer is is not in the valid format!" );

            var subjects = _universityModulesService.GetTeacherSubjects( teacherId );

            return subjects != null ? ( IHttpActionResult ) Ok( subjects ) : NotFound();
        }
    }
}