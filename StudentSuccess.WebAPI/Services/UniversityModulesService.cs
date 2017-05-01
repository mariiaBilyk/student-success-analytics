using System.Collections.Generic;
using System.Linq;
using StudentSuccess.WebAPI.Models.UniversityModules;
using StudentSuccess.WebAPI.Services.Common;
using StudentSuccessAnalytics.Domain.Models.UniversityModules;
using StudentSuccessAnalytics.Infrastructure.Common;
using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccess.WebAPI.Services {
    public class UniversityModulesService : ServiceBase {
        private IInstituteRepository InstituteRepository => UnitOfWork.InstituteRepository;

        public UniversityModulesService ( IUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        public IEnumerable<InstituteBindModel> GetInstitutes () {
            var institutesDb = InstituteRepository.GetAll();
            var institutes = institutesDb.Select( i => new InstituteBindModel {
                Id = i.Id,
                ShortName = i.ShortTitle
            } );

            return institutes;
        }
    }
}