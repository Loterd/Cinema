using System.Net;

namespace Cinema.Exceptions.Exceptions;

public abstract class ApiException : Exception
{
    protected ApiException(string message) : base(message)
    {
    }
    public abstract HttpStatusCode StatusCode { get; set; }
}

public class BadRequestApiException : ApiException
{
    public override HttpStatusCode StatusCode { get; set; }

    public BadRequestApiException(string message) : base(message)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }
}

public class NotFoundApiException : ApiException
{
    public override HttpStatusCode StatusCode { get; set; }

    public NotFoundApiException(string message) : base(message)
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}

