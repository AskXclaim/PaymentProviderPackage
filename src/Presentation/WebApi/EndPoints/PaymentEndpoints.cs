using System.Net;
using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.EndPoints;

public static class PaymentEndpoints
{
    public static RouteGroupBuilder MapPaymentEndpoints(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("/GeneratePaymentSession",
            async (IPaymentGateway paymentGateway, [FromBody] GeneratePaymentSessionRequest request) =>
            {
                    var response = await paymentGateway.GeneratePaymentSession(request);
                    return response != null ? new Response(response, HttpStatusCode.OK) : GetFailedResponse();
            });

        groupBuilder.MapGet("/GetPaymentSessionDetails",
            async (IPaymentGateway paymentGateway, string paymentSessionId) =>
            {
                    var response = await paymentGateway.GetPaymentSessionDetails(new PaymentSessionDetailRequest(paymentSessionId));
                    return response != null ? new Response(response, HttpStatusCode.OK) : GetFailedResponse();
            });

        return groupBuilder;
    }

    private static Response GetFailedResponse() =>
        new("An unexpected situation occurred please try again",
            HttpStatusCode.Ambiguous, true);
}