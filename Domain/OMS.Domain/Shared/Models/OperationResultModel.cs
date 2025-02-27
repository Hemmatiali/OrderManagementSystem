using System.Net;

namespace OMS.Domain.Shared.Models;

public sealed class OperationResultModel
{
    public bool WasSuccess { get; }
    public string ErrorMessage { get; private set; }
    public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.OK;
    private OperationResultModel(bool wasSuccess, string errorMessage = "")
    {
        WasSuccess = wasSuccess;
        ErrorMessage = errorMessage;
    }

    public static OperationResultModel Fail(string errorMessage) => new(wasSuccess: false, errorMessage: errorMessage);

    public static OperationResultModel Success() => new(wasSuccess: true);

    public OperationResultModel WithStatusCode(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        return this;
    }
}
