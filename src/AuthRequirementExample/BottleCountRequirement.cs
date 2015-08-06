using Microsoft.AspNet.Authorization;

namespace AuthRequirementExample
{
    public class BottleCountRequirement : AuthorizationHandler<BottleCountRequirement>, IAuthorizationRequirement
    {
        public override void Handle(AuthorizationContext context, BottleCountRequirement requirement)
        {
            // Doesn't compile - Bug?
            //var bottleCount = context.Resource.RouteData.Values["id"];

            dynamic resource = context.Resource;
            var bottleCount = resource.RouteData.Values["id"];

            if (bottleCount == "99")
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
