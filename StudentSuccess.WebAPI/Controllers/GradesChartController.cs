using System.Web.Http;
using System.Web.Http.Description;
using StudentSuccess.WebAPI.Controllers.Common;
using StudentSuccess.WebAPI.Models.GradesChart;
using StudentSuccess.WebAPI.Services;
using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccess.WebAPI.Controllers {
    [RoutePrefix("api/gradesChart")]
    public class GradesChartController : BaseController {
        private readonly GradesAnalyticsService _gradesAnalyticsService;

        public GradesChartController (IUnitOfWork unitOfWork) {
            _gradesAnalyticsService = new GradesAnalyticsService( unitOfWork );
        }

        [HttpGet]
        [Route("teachers")]
        [ResponseType ( typeof( GradesChartBindingModel ) )]
        public IHttpActionResult GetTeacherGradesChart ( TeacherGradesFiltersBindingModel filters ) {
            if ( !ModelState.IsValid ) return BadRequest(ModelState);

            var chartData = _gradesAnalyticsService.GetGradesChart( filters );

            return chartData?.ChartItems == null ? ( IHttpActionResult ) BadRequest() : Ok( chartData );
        }
    }
}