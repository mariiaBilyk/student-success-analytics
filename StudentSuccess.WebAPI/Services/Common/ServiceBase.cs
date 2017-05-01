using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccess.WebAPI.Services.Common {
    public class ServiceBase {
        protected IUnitOfWork UnitOfWork;

        public ServiceBase ( IUnitOfWork unitOfWork ) {
            UnitOfWork = unitOfWork;
        }
    }
}