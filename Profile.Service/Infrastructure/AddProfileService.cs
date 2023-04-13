using Profile.Domain.FileModels;
using Profile.Infrastructure;
using Profile.Service.Commands.Profile;
using System.IO;
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
            var innScan = await FormFileModel.Form(command.InnScan, cancellationToken);
            var ogrnScan = await FormFileModel.Form(command.OgrnScan, cancellationToken);
            var egripScan = await FormFileModel.Form(command.EgripScan, cancellationToken);
            var contractRentScan = await FormFileModel.Form(command.ContractRentScan, cancellationToken);

            var profile = new Domain.Profile.Profile(command.FullName,
                                                     command.ShortName,
                                                     command.Inn,
                                                     innScan,
                                                     command.RegistrationDate,
                                                     command.Ogrn,
                                                     ogrnScan,
                                                     egripScan,
                                                     contractRentScan,
                                                     command.IsNoContract,
                                                     command.BankDetails);


            await _dbContext.AddAsync(profile, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return profile;
        }
    }
}
