using Abp.Authorization;
using UserTest.Authorization.Roles;
using UserTest.Authorization.Users;

namespace UserTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
