using Microsoft.AspNetCore.Mvc;

namespace WebApi.ExceptionHandling;

public class CustomProblemDetails:ProblemDetails
{
    public string? RequestId { get; set; }
    public string? CorrelationId { get; set; }
    public DateTime TimeStamp { get;  } = DateTime.UtcNow;
    public CustomProblemDetails(string? requestId, string? correlationId)
    {
        RequestId = requestId;
        CorrelationId = correlationId;
    }

    public CustomProblemDetails()
    {
        
    }
   
}