Imports System.Web.Mvc
Imports Microsoft.Extensions
Imports Newtonsoft.Json
Imports RestSharp
Imports Stripe

Namespace Controllers
    Public Class StripeController
        Inherits Controller

        Function Index(ByVal code As String, ByVal scope As String, ByVal state As String) As String
            Dim result = GetStripeKey(code)
            Return code
        End Function

        Function GetStripeKey(ByVal code As String) As String
            ' Post request     https://connect.stripe.com/oauth/token
            'Dim StripeConfiguration.ApiKey = "sk_test_51H6xPoDq9WcbpAQn8LKmvqPSoClBKi7lT6TwCGCKRFkNXB6MZC4OtbWC1rwNx2KnBfZptfnXIcaNwxCjhpa6DAiz0094D84PAC";
            StripeConfiguration.ApiKey = "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"
            Dim Options As OAuthTokenCreateOptions = New OAuthTokenCreateOptions()
            Options.GrantType = "authorization_code"
            Options.Code = code '"ac_123456789"
            Dim service = New OAuthTokenService()
            Dim Response = service.Create(Options)
            Dim connected_account_id = Response.StripeUserId
            Return connected_account_id

            'Dim _client As IRestClient = New RestClient()
            'Dim Request = New RestRequest("https://connect.stripe.com/oauth/token", Method.POST) With {.RequestFormat = RestSharp.DataFormat.Json}
            'Request.AddJsonBody(Options)
            'Dim stripeResponse As IRestResponse = _client.Execute(Request)
        End Function

    End Class
End Namespace