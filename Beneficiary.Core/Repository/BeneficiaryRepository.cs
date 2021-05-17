using Beneficiary.DataAccess;
using Beneficiary.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beneficiary.Core.Repository
{
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly BeneficiaryDbContext _db;
        public BeneficiaryRepository(BeneficiaryDbContext db) => this._db = db;

        public async Task<bool> Exists(int id)
        {
            return this._db.Beneficiaries.Any(x => x.Id == id);
        }

        public async Task<bool> Create(BeneficiaryModel beneficiary)
        {
            this._db.Beneficiaries.Add(beneficiary);

            return await Save();
        }

        public async Task<bool> Delete(BeneficiaryModel beneficiary)
        {
            this._db.Beneficiaries.Remove(beneficiary);

            return await Save();
        }

        public async Task<BeneficiaryModel> Get(int Id)
        {
            return this._db.Beneficiaries.FirstOrDefault(id => id.Id == Id);
        }

        public async Task<ICollection<BeneficiaryModel>> GetAll()
        {
            return this._db.Beneficiaries.OrderBy(x => x.Name).ToList();
        }

        public async Task<bool> Save()
        {
            return this._db.SaveChanges() >= 0 ? true : false;
        }

        public Task<bool> Update(BeneficiaryModel beneficiary)
        {
            this._db.Beneficiaries.Update(beneficiary);
            return Save();
        }
    }
}
