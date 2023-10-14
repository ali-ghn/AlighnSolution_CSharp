using System.Net;

namespace AlighnSolution.Shared;

public static class CustomHttpStatusCode
{
    public static int ToInt(this HttpStatusCode statusCode)
    {
         return Convert.ToInt32(statusCode.ToString());
    }
}