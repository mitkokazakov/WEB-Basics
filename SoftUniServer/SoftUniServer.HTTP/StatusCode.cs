namespace SoftUniServer.HTTP
{
    public enum StatusCode
    {
        OK = 200,
        MovedPermanently = 301,
        Found = 302,
        TemporaryRedirect = 307,
        BadRequest = 400,
        Forbidden = 403,
        NotFound = 404
    }
}