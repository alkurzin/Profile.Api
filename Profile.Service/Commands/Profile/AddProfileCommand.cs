using MediatR;
using Microsoft.AspNetCore.Http;
using Profile.Domain.Profile;
using Profile.Service.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Profile.Service.Commands.Profile
{
    public class AddProfileCommand : IRequest<Domain.Profile.Profile>
    {
        public string? FullName { get; set; }
        public string? ShortName { get; set; }
        public string Inn { get; set; }
        public IFormFile InnScan { get; set; }
        public string RegistrationDate { get; set; }
        public string Ogrn { get; set; }
        public IFormFile OgrnScan { get; set; }
        public IFormFile EgripScan { get; set; }
        public IFormFile? ContractRentScan { get; set; }
        public bool IsNoContract { get; set; }
        public List<BankDetail> BankDetails { get; set; }
    }

    public class AddProfileCommandHandler : IRequestHandler<AddProfileCommand, Domain.Profile.Profile>
    {
        private readonly IAddProfileService _addProfileService;

        public AddProfileCommandHandler(IAddProfileService addProfileService)
        {
            _addProfileService = addProfileService;
        }
        public Task<Domain.Profile.Profile> Handle(AddProfileCommand command, CancellationToken cancellationToken)
        {
            return _addProfileService.AddProfile(command, cancellationToken);
        }
    }
}
