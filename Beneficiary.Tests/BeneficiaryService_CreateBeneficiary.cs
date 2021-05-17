using Beneficiary.Core.Repository;
using Beneficiary.DataAccess.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beneficiary.Tests
{
    [TestClass]
    public class BeneficiaryService_CreateBeneficiary
    {
        IBeneficiaryRepository _beneficiaryRepo;
        public BeneficiaryService_CreateBeneficiary(IBeneficiaryRepository beneficiaryRepo) => this._beneficiaryRepo = beneficiaryRepo;

        [TestMethod]
        public async void CreateBeneficiary_BeneficiaryObjectIn_ReturnTrue()
        {
            var beneficiaryObj = new BeneficiaryModel
            {
                Id = 0,
                Name = "Unit Testing Beneficiary",
                AccountNumber = "1234567890",
                Reference = "Unit Testing Reference"
            };

            bool result = await this._beneficiaryRepo.Create(beneficiaryObj);

            Assert.IsTrue(result);
        }
    }
}
