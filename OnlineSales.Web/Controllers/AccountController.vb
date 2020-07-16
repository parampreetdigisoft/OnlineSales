Imports System.Security.Claims
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Web.Configuration
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNetCore.Authentication
Imports Microsoft.Owin.Security.Cookies
Imports OnlineSales.Web.OnlineSales.Web
Imports System.Web
Imports System.Security.Principal

Namespace Controllers
    Public Class AccountController
        Inherits Controller

#Region "Properties"
        Public Shared Property WebUrl As String
        Private Property _accountService As IAccount
#End Region

#Region "Constructor"
        Public Sub New()
            WebUrl = WebConfigurationManager.AppSettings("WebUrl")
            _accountService = New AccountService()
        End Sub
#End Region

#Region "Methods"
        Function Index() As ActionResult
            Return View(New LoginViewModel())
        End Function

        ''' <summary>
        ''' login
        ''' </summary>
        ''' <param name="loginViewModel"></param>
        ''' <returns></returns>
        <HttpPost>
        Public Async Function Index(ByVal loginViewModel As LoginViewModel) As Task(Of ActionResult)

            If ModelState.IsValid Then
                Dim resut As ResponseViewModel
                resut = _accountService.Authenticate(loginViewModel)
                If resut.Status = False Then
                    ModelState.AddModelError("", resut.Message)
                Else
                    SignIn(loginViewModel)
                    Return RedirectToAction("Index", "Home")
                End If
                Return View()
            Else
                Return View()
            End If
        End Function

        Private Sub SignIn(ByVal loginViewModel As LoginViewModel)

            Dim claims = New List(Of Claim)()
            claims.Add(New Claim(ClaimTypes.Email, loginViewModel.Username))
            Dim identity = New ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie)
            Dim principal As ClaimsPrincipal = New ClaimsPrincipal(identity)
            Dim ctx = Request.GetOwinContext()
            Dim authenticationManager = ctx.Authentication
            authenticationManager.SignIn(identity)
        End Sub

        ''' <summary>
        ''' sign up page
        ''' </summary>
        ''' <returns></returns>
        Function Signup() As ActionResult
            Dim signupViewModel As SignupViewModel = New SignupViewModel()
            Return View(signupViewModel)
        End Function

        ''' <summary>
        ''' our customer signup
        ''' </summary>
        ''' <param name="signupViewModel"></param>
        ''' <returns></returns>
        <HttpPost>
        Public Function Signup(ByVal signupViewModel As SignupViewModel) As ActionResult
            Try
                Dim result = _accountService.SignUp(signupViewModel)
                If result IsNot Nothing Then
                    Dim link As String = WebUrl + "Account/ConfirmPassword?key=" + result.APIkey
                    Dim emailContent As String = Utils.VerificationPasswordContent(signupViewModel.StoreName, link)
                    Utils.SendEmail(signupViewModel.Email, emailContent, "Password Veification Link")
                    Return Json(New With {Key .Message = "Customer successully added", Key .Success = True})
                Else
                    Return Json(New With {Key .Message = "Store Name is already exist. Please change the name", Key .Success = False})
                End If
            Catch __unusedException1__ As Exception
                Return Json(New With {Key .Message = "Sorry, An error occurred!", Key .Success = False})
            End Try
        End Function

        ''' <summary>
        ''' forgot password
        ''' </summary>
        ''' <returns></returns>
        Function ForgotPassword() As ActionResult
            Return View()
        End Function

        ''' <summary>
        ''' forgot password
        ''' </summary>
        ''' <returns></returns>
        <HttpPost>
        Function ForgotPassword(ByVal email As String) As ActionResult
            Dim result = _accountService.GetOurCustomerByEmail(email)
            If result IsNot Nothing Then
                Dim link As String = WebUrl + "Account/ConfirmPassword?key=" + result.APIkey
                Dim emailContent As String = Utils.VerificationPasswordContent(String.Empty, link)
                Utils.SendEmail(email, emailContent, "Reset Password Link")
                Return Json(New With {Key .Message = "Customer successully added", Key .Success = True})
            Else
                Return Json(New With {Key .Message = "Email not exist. Please check your email address.", Key .Success = False})
            End If

        End Function

        ''' <summary>
        ''' confirm password
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Function ConfirmPassword(ByVal key As String) As ActionResult
            Try
                Dim userViewModel As UserViewModel = New UserViewModel()
                userViewModel.ApiKey = key.Replace(" ", "+")
                Return View(userViewModel)
            Catch __unusedException1__ As Exception
                Return View()
            End Try
        End Function

        ''' <summary>
        ''' update password
        ''' </summary>
        ''' <param name="userViewModel"></param>
        ''' <returns></returns>
        <HttpPost>
        Public Function ConfirmPassword(ByVal userViewModel As UserViewModel) As ActionResult
            Try
                _accountService.UpdatePassword(userViewModel)
                Return Json(New With {Key .Success = True})
            Catch __unusedException1__ As Exception
                Return Json(New With {Key .Success = False})
            End Try
        End Function

        ''' <summary>
        ''' email sent
        ''' </summary>
        ''' <returns></returns>
        Function EmailSent() As ActionResult
            Return View()
        End Function

        ''' <summary>
        ''' logout user
        ''' </summary>
        ''' <returns></returns>
        Function Logout() As ActionResult
            Dim ctx = Request.GetOwinContext()
            Dim authenticationManager = ctx.Authentication
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
            Return RedirectToAction("Index")
        End Function

#End Region
    End Class

End Namespace