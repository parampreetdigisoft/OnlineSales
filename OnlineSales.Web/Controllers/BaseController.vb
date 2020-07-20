Imports System.Security.Claims
Imports System.Web.Mvc

Namespace Controllers
    Public Class BaseController
        Inherits Controller

#Region "Properties"
        Private Property _accountService As IAccount
#End Region

#Region "Constructor"
        Public Sub New()
            _accountService = New AccountService()
        End Sub
#End Region

        Function CurrentUserId() As Int32
            Dim identity = CType(User.Identity, System.Security.Claims.ClaimsIdentity)
            Dim emailId = identity.Claims.Where(Function(c) c.Type = ClaimTypes.Email).[Select](Function(c) c.Value).SingleOrDefault()
            Dim customer = _accountService.GetOurCustomerByEmail(emailId)
            Return customer.UserId
        End Function
    End Class
End Namespace