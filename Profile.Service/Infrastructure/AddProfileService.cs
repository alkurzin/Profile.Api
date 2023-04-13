using Profile.Infrastructure;
using Profile.Service.Commands.Profile;
using System.Threading;
using System.Threading.Tasks;

namespace Profile.Service.Infrastructure
{
    public interface IAddProfileService
    {
        public Task<Domain.Profile.Profile> AddProfile(AddProfileCommand command, CancellationToken cancellationToken);
    }

    public class AddProfileService : IAddProfileService
    {
        private readonly ProfileDbContext _dbContext;

        public AddProfileService(ProfileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Profile.Profile> AddProfile(AddProfileCommand command, CancellationToken cancellationToken)
        {
            var profile = new Domain.Profile.Profile(command.FullName,
                                                     command.ShortName,
                                                     command.Inn,
                                                   //  command.InnScan,
                                                     command.RegistrationDate,
                                                     command.Ogrn,
                                                  //   command.OgrnScan,
                                                  //   command.EgripScan,
                                                  //   command.ContractRentScan,
                                                     command.IsNoContract,
                                                     command.BankDetails);


            await _dbContext.AddAsync(profile, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return profile;
        }
    }
}
