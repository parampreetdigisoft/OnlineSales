Imports System.Security.Claims
Imports OnlineSales.Web.Controllers

<Authorize>
Public Class HomeController
    Inherits BaseController

#Region "Properties"
    Private Property _accountService As IAccount
#End Region

#Region "Constructor"
    Public Sub New()
        _accountService = New AccountService()
    End Sub
#End Region

    Function Index() As ActionResult
        Dim identity = CType(User.Identity, System.Security.Claims.ClaimsIdentity)
        Dim emailId = identity.Claims.Where(Function(c) c.Type = ClaimTypes.Email).[Select](Function(c) c.Value).SingleOrDefault()
        Dim customer = _accountService.GetOurCustomerByEmail(emailId)
        Dim stripeViewModel As StripeViewModel = New StripeViewModel()
        If customer IsNot Nothing And customer.StripeAccessToken IsNot Nothing And customer.StripeAccessToken IsNot "0" Then
            stripeViewModel.IsStripeAccessToken = True
        Else
            stripeViewModel.IsStripeAccessToken = False
        End If
        Return View(stripeViewModel)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
