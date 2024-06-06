using Microsoft.AspNetCore.Authorization;

namespace FullToturialIdentity.Authorization
{
    public class HRManagerProbationRequirements:IAuthorizationRequirement
    {
        public HRManagerProbationRequirements(int probationMonth)
        {
            ProbationMonth = probationMonth;
        }

        public int ProbationMonth { get;}
    }
     
    public class HRManagerProbationRequirementsHandler : AuthorizationHandler<HRManagerProbationRequirements>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HRManagerProbationRequirements requirement)
        {
            if(!context.User.HasClaim(x => x.Type == "EmploymentData"))
                return Task.CompletedTask;

            var empData = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentData").Value);
             
            var period = DateTime.Now - empData;
            if(period.Days > 30 * requirement.ProbationMonth)
                context.Succeed(requirement);

           return Task.CompletedTask;
        }
    }
}
