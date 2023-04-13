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
            // путь к папке Files
            string path = Path.Combine(Directory.GetCurrentDirectory(), command.InnScan.FileName);
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await command.InnScan.CopyToAsync(fileStream, cancellationToken);
            }
            var innScan = new FileModel { Name = command.InnScan.FileName, Path = path };

            var profile = new Domain.Profile.Profile(command.FullName,
                                                     command.ShortName,
                                                     command.Inn,
                                                     innScan,
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
