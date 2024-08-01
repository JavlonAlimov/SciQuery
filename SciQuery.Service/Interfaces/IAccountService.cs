using SciQuery.Domain.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciQuery.Service.Interfaces;

public interface IAccountService
{
    Task<string> RegisterAsync(AddOrUpdateUserModel model);
    Task<string> LoginAsync(LoginViewModel model);
}
