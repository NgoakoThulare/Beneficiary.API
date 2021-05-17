using Beneficiary.DataAccess.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beneficiary.Core.Repository
{
    public interface IBeneficiaryRepository
    {
        Task<ICollection<BeneficiaryModel>> GetAll();
        Task<BeneficiaryModel> Get(int Id);
        Task<bool> Create(BeneficiaryModel beneficiary);
        Task<bool> Update(BeneficiaryModel beneficiary);
        Task<bool> Delete(BeneficiaryModel beneficiary);
        Task<bool> Exists(int id);
        Task<bool> Save();
    }
}
