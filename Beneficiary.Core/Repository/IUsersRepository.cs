using Beneficiary.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneficiary.Core.Repository
{
    public interface IUsersRepository
    {
        User Authenticate(string username, string password);
    }
}
