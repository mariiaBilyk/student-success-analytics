using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using StudentSuccess.WebAPI.Controllers.Common;
using StudentSuccess.WebAPI.Models.UniversityModules;
using StudentSuccess.WebAPI.Services;
using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccess.WebAPI.Controllers {
    [RoutePrefix ( "api/institute" )]
    public class InstitutesController : BaseController {
        private readonly UniversityModulesService _universityModulesService;

        public InstitutesController ( IUnitOfWork unitOfWork ) {
            _universityModulesService = new UniversityModulesService( unitOfWork );
        }

        [HttpGet]
        [ResponseType ( typeof( IEnumerable<InstituteBindModel> ) )]
        public IHttpActionResult Get () {
            var institutes = _universityModulesService.GetInstitutes();

            return institutes != null ? ( IHttpActionResult ) Ok( institutes ) : NotFound();
        }
    }
}