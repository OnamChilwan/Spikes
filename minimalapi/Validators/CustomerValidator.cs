using MinimalApi.Handlers;
using MinimalApi.Models;

namespace MinimalApi.Validators;

public static class CustomerValidator
{
    public static IReadOnlyList<ApiError> Validate(CustomerRequest request)
    {
        var errors = new List<ApiError>();

        if (request is null)
        {
            errors.Add(new ApiError { ErrorCode = "InvalidRequest", Message = "Request not provided." });
            return errors;
        }

        return errors;
    }
}