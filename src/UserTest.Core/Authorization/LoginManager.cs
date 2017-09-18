using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Zero.Configuration;
using UserTest.Authorization.Roles;
using UserTest.Authorization.Users;
using UserTest.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;

namespace UserTest.Authorization
{
    public class LogInManager : AbpLogInManager<Tenant, Role, User>
    {
        private UserRegistrationManager _userRegistrationManager;
        public LogInManager(
            UserManager userManager, 
            IMultiTenancyConfig multiTenancyConfig,
            IRepository<Tenant> tenantRepository,
            IUnitOfWorkManager unitOfWorkManager,
            ISettingManager settingManager, 
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository, 
            IUserManagementConfig userManagementConfig,
            IIocResolver iocResolver,
            IPasswordHasher<User> passwordHasher, 
            RoleManager roleManager,
            UserRegistrationManager userRegistrationManager,
            UserClaimsPrincipalFactory claimsPrincipalFactory) 
            : base(
                  userManager, 
                  multiTenancyConfig,
                  tenantRepository, 
                  unitOfWorkManager, 
                  settingManager, 
                  userLoginAttemptRepository, 
                  userManagementConfig, 
                  iocResolver, 
                  passwordHasher, 
                  roleManager, 
                  claimsPrincipalFactory)
        {
            _userRegistrationManager = userRegistrationManager;
        }

        public override async Task<AbpLoginResult<Tenant, User>> LoginAsync(string userNameOrEmailAddress, string plainPassword, string tenancyName = null, bool shouldLockout = true)
        {
            var result = await base.LoginAsync(userNameOrEmailAddress, plainPassword, tenancyName, shouldLockout);
            if (result.Result ==  AbpLoginResultType.InvalidUserNameOrEmailAddress)
            {
                await _userRegistrationManager.RegisterAsync(userNameOrEmailAddress, userNameOrEmailAddress, 
                    $"{new Random().Next(10000)}@t.ru", userNameOrEmailAddress, plainPassword, true);
                result = await base.LoginAsync(userNameOrEmailAddress, plainPassword, tenancyName, shouldLockout);
            }

            return result;
        }
    }
}
