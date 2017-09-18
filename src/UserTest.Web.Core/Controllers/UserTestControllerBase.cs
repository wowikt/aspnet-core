using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace UserTest.Controllers
{
    public abstract class UserTestControllerBase: AbpController
    {
        protected UserTestControllerBase()
        {
            LocalizationSourceName = UserTestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}