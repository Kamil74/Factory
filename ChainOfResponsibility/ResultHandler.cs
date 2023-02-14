namespace ChainOfResponsibility;

public class resulHendler : BaseHandler
{
    public resulHendler(IHandler next) : base(next)
    {
    }

    public override void Handle(RequestContext requestContext)
    {
        requestContext.Response.IsSuccessful = true;
        requestContext.Response.Data = "some value";
    }
}