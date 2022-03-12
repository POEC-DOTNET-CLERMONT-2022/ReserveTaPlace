using Microsoft.AspNetCore.Authorization;

namespace ReserveTaPlace.API.Authorizations
{
    // TODO Secutrity Policy by class or lambda
    public class ReadWriteRequirement : IAuthorizationRequirement
    {
    }
    public class ReadWriteRequirementAuthorizationHandler : AuthorizationHandler<ReadWriteRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ReadWriteRequirement requirement)
        {
            if (context.User.HasClaim("permissions","controlerName:Read"))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail(new AuthorizationFailureReason(this, "Sac de noeuds !!"));
            }
            return Task.CompletedTask;
        }
    }
}
