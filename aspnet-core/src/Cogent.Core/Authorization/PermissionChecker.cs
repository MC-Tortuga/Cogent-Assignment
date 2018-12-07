using Abp.Authorization;
using Cogent.Authorization.Roles;
using Cogent.Authorization.Users;

namespace Cogent.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
