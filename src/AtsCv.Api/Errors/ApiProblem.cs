using Microsoft.AspNetCore.Http;

namespace AtsCv.Api.Errors;

public static class ApiProblem
{
    public static IResult Create(
        HttpContext httpContext,
        int statusCode,
        string title,
        string detail,
        string errorCode,
        IReadOnlyList<string>? errors = null)
    {
        var extensions = new Dictionary<string, object?>
        {
            ["errorCode"] = errorCode
        };

        if (errors is { Count: > 0 })
            extensions["errors"] = errors;

        return Results.Problem(
            detail: detail,
            instance: httpContext.Request.Path.Value,
            statusCode: statusCode,
            title: title,
            extensions: extensions);
    }
}
