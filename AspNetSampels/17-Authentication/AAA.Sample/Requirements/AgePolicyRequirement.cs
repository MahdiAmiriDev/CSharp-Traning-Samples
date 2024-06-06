using Microsoft.AspNetCore.Authorization;

namespace AAA.Sample.Requirements
{
    public class AgePolicyRequirement:IAuthorizationRequirement
    {
        public int Age { get; set; }
        public AgePolicyRequirement(int age)
        {
            Age = age;
        }
    }

    //هندلر سرویس از ای اس پی است پس قابلیت تزریق وابستگی را دارد
    public class AgePolicyRequirementHandler : AuthorizationHandler<AgePolicyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgePolicyRequirement requirement)
        {
            var reandom = new Random();
            int userAge = reandom.Next(14, 25);
            if(userAge > requirement.Age)
            {
                context.Succeed(requirement);
                //context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
