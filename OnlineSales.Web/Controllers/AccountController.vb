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
Imports System.IO

Namespace Controllers
    Public Class AccountController
        Inherits Controller

#Region "Properties"
        Public Shared Property WebUrl As String
        Public Shared Property NiftyUrl As String
        Private Property _accountService As IAccount
#End Region

#Region "Constructor"
        Public Sub New()
            WebUrl = WebConfigurationManager.AppSettings("WebUrl")
            NiftyUrl = WebConfigurationManager.AppSettings("NiftyHost")
            _accountService = New AccountService()
        End Sub
#End Region

#Region "Methods"
        Function Index() As ActionResult
            Dim loginviewModel As LoginViewModel = New LoginViewModel()
            If (TempData("loginModel") IsNot Nothing) Then
                loginviewModel = TempData("loginModel")
            End If
            Return View(loginviewModel)
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
                    loginViewModel.Message = resut.Message
                    TempData("loginModel") = loginViewModel
                    Return RedirectToAction("Index", "Account")
                Else
                    SignIn(loginViewModel)
                    Return RedirectToAction("Index", "Home")
                End If
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
                    Dim url As String = WebUrl + "Account/ConfirmPassword?key=" + result.APIkey
                    Dim emailContentViewModel As EmailContentViewModel = New EmailContentViewModel()
                    emailContentViewModel.UserMailLink = "mailto:info@NiftyCart.com"
                    emailContentViewModel.Url = url
                    emailContentViewModel.StoreName = signupViewModel.StoreName
                    emailContentViewModel.Logo = WebUrl + "Images/nifty-logo.png"
                    Dim html = PartialView("~/Views/Account/_EmailContent.vbhtml", emailContentViewModel).RenderToString()
                    Utils.SendEmail(signupViewModel.Email, html, "Password Veification Link")
                    Return Json(New With {Key .Message = "Customer successully added", Key .Success = True})
                Else
                    Return Json(New With {Key .Message = "Store Name is already exist. Please change the name", Key .Success = False})
                End If
            Catch __unusedException1__ As Exception
                Return Json(New With {Key .Message = "Sorry, An error occurred!", Key .Success = False})
            End Try
        End Function

        Public Shared Function RenderPartialToString(ByVal controlName As String, ByVal viewData As Object) As String
            Dim viewPage As ViewPage = New ViewPage() With {
        .ViewContext = New ViewContext()
    }
            viewPage.ViewData = New ViewDataDictionary(viewData)
            viewPage.Controls.Add(viewPage.LoadControl(controlName))
            Dim sb As StringBuilder = New StringBuilder()

            Using sw As StringWriter = New StringWriter(sb)

                Using tw As HtmlTextWriter = New HtmlTextWriter(sw)
                    viewPage.RenderControl(tw)
                End Using
            End Using

            Return sb.ToString()
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
                Dim Url As String = WebUrl + "Account/ConfirmPassword?key=" + result.APIkey
                Dim emailContentViewModel As EmailContentViewModel = New EmailContentViewModel()
                emailContentViewModel.UserMailLink = "mailto:info@NiftyCart.com"
                emailContentViewModel.Url = Url
                emailContentViewModel.StoreName = String.Empty
                emailContentViewModel.Logo = WebUrl + "Images/nifty-logo.png"
                Dim html = PartialView("~/Views/Account/_EmailContent.vbhtml", emailContentViewModel).RenderToString()
                Utils.SendEmail(email, html, "Reset Password Link")
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
                Dim userID = _accountService.UpdatePassword(userViewModel)
                Dim Url As String = String.Format("{0}/account/index/{1}", NiftyUrl, userID)
                Return Json(New With {Key .Success = True, Key .UserId = userID, Key .Url = Url})
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

        ''' <summary>
        ''' customer
        ''' </summary>
        ''' <param name="couponCode"></param>
        ''' <returns></returns>
        <HttpPost>
        Public Function ApplyCoupon(ByVal couponCode As String) As ActionResult
            Try
                Dim result = _accountService.IsCouponValid(couponCode)
                Return Json(New With {Key .Message = result.Message, Key .Success = result.Status})
            Catch __unusedException1__ As Exception
                Return Json(New With {Key .Message = "Sorry, An error occurred!", Key .Success = False})
            End Try
        End Function

#End Region
    End Class
End Namespace