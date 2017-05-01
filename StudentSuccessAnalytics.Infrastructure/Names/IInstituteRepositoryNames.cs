using System.Security.Cryptography.X509Certificates;

namespace StudentSuccessAnalytics.Infrastructure.Names {
    public interface IInstituteRepositoryNames {
        string Id { get; }
        string Name { get; }
        string ShortName { get; }
    }
}