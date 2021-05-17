using AutoMapper;
using Beneficiary.Contracts.DTOs;
using Beneficiary.DataAccess.Model;

namespace Beneficiary.Core
{
    public class BeneficiaryMappings : Profile
    {
        public BeneficiaryMappings()
        {
            CreateMap<BeneficiaryModel, BeneficiaryDto>().ReverseMap();
        }
    }
}
