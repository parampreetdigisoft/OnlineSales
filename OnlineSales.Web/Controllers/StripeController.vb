Imports System.Net
Imports System.Web.Http
Imports Stripe

Public Class StripeController
    Inherits ApiController


#Region "Properties"
    Private Property _accountService As IAccount
#End Region

    ' POST api/Stripe/StripeAuth?scope&code
    <HttpGet>
    Public Function StripeAuth(ByVal code As String, ByVal scope As String)

        StripeConfiguration.ApiKey = Utils.StripeApiKey
        Dim options = New OAuthTokenCreateOptions With {
            .GrantType = "authorization_code",
            .Code = If(String.IsNullOrEmpty(code), "", Convert.ToString(code))
        }
        Dim service = New OAuthTokenService()
        Dim response = service.Create(options)

        If response IsNot Nothing Then
            Dim connected_account_id = response.StripeUserId
            Dim result = _accountService.SaveStripeAuthToken(response)
            Return Json(New With {Key .Message = result.Message, Key .Success = result.Status})
        Else
            Return Json(New With {Key .Message = "Access Denied  Please Contact Admin", Key .Success = False})
        End If

    End Function



    ' GET api/<controller>
    'Public Function GetValues() As IEnumerable(Of String)
    '    Return New String() {"value1", "value2"}
    'End Function

    '' GET api/<controller>/5
    'Public Function GetValue(ByVal id As Integer) As String
    '    Return "value"
    'End Function

    '' POST api/<controller>
    'Public Sub PostValue(<FromBody()> ByVal value As String)

    'End Sub

    ' PUT api/<controller>/5
    'Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    'End Sub

    '' DELETE api/<controller>/5
    'Public Sub DeleteValue(ByVal id As Integer)

    'End Sub
End Class
