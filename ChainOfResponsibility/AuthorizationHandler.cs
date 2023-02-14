namespace ChainOfResponsibility;

public class AuthorizationHendler : BaseHandler
{
    private Dictionary<int, int> entityOwners = new Dictionary<int, int>()
    {
        { 100, 13 },
        { 101, 14 },
    };
    
    public AuthorizationHandler(IHandler next) : base(next)
    {
    }

    public override void Handle(RequestContext requestContext)
    {
        if (requestContext.Request.UserRole == "Admin")
        {
            _next.Handle(requestContext);
        }

        if (entityOwners.TryGetValue(requestContext.Request.EntityId, out int ownerId))
        {
            if (ownerId == requestContext.Request.UserId)
            {
                _next.Handle(requestContext);
            }
        }

        requestContext.Response.IsSuccessful = false;
        requestContext.Response.Massage = "User is not authorized";
    }
}