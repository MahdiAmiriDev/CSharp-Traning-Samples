using Microsoft.AspNetCore.Identity;

namespace AAA.Sample.Infra
{
    public class UserNameInPasswordValidator : IPasswordValidator<IdentityUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<IdentityUser> manager, IdentityUser user, string password)
        {
            if (password.Contains(user.UserName, StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "userNameInPassord",
                    Description = "you can not user your userName in Password"
                }));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
  