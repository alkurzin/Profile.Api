using Profile.Domain.FileModels;
using System.Collections.Generic;

namespace Profile.Domain.Profile
{
    public class Profile
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public string? ShortName { get; set; }
        public string Inn { get; set; }
        public FileModel InnScan { get; set; }
        public string RegistrationDate { get; set; }
        public string Ogrn { get; set; }
        public FileModel OgrnScan { get; set; }
        public FileModel EgripScan { get; set; }
        public FileModel? ContractRentScan { get; set; }
        public bool IsNoContract { get; set; }
        public List<BankDetail> BankDetails { get; set; }
        
        public Profile()
        {
        }

        public Profile(string fullName,
               string shortName,
               string inn,
               FileModel innScan,
               string registrationDate,
               string ogrn,
               FileModel ogrnScan,
               FileModel egripScan,
               FileModel contractRentScan,
               bool isNoContract,
               List<BankDetail> bankDetails)
        {
            FullName = fullName;
            ShortName = shortName;
            Inn = inn;
            InnScan = innScan;
            RegistrationDate = registrationDate;
            Ogrn = ogrn;
            OgrnScan = ogrnScan;
            EgripScan = egripScan;
            ContractRentScan = contractRentScan;
            IsNoContract = isNoContract;
            BankDetails = bankDetails;
        }
    }
}