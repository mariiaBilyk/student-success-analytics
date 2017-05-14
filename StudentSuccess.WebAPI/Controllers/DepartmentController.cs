using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using StudentSuccess.WebAPI.Controllers.Common;
using StudentSuccess.WebAPI.Models.UniversityModules;
using StudentSuccess.WebAPI.Services;
using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccess.WebAPI.Controllers {
    [RoutePrefix ( "api/department" )]
    public class DepartmentController : BaseController {
        private readonly UniversityModulesService _universityModulesService;

        public DepartmentController ( IUnitOfWork unitOfWork ) {
            _universityModulesService = new UniversityModulesService( unitOfWork );
        }

        [HttpGet]
        [ResponseType ( typeof( IEnumerable<DepartmentBindModel> ) )]
        public IHttpActionResult GetDepartments () {
            var departments = _universityModulesService.GetDepartments();

            return departments != null ? ( IHttpActionResult ) Ok( departments ) : NotFound();
        }
    }
}