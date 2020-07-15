Imports System.Web.Mvc

Namespace Controllers
    Public Class AccountController
        Inherits Controller

        Private Property _accountService As IAccount

        Public Sub New()
            _accountService = New AccountService()
        End Sub

        Function Index() As ActionResult
            Return View()
        End Function

        ''' <summary>
        ''' login
        ''' </summary>
        ''' <param name="loginViewModel"></param>
        ''' <returns></returns>
        <HttpPost>
        Public Function Index(ByVal loginViewModel As LoginViewModel) As ActionResult
            Try
                Dim resut As Boolean
                resut = _accountService.Authenticate(loginViewModel)
                If resut Then
                    Return Json(New With {Key .Message = "Sorry, An error occurred!", Key .Success = True})
                Else
                    Return Json(New With {Key .Message = "Store Name is already exist. Please change the name", Key .Success = False})
                End If
            Catch __unusedException1__ As Exception
                Return Json(New With {Key .Message = "Sorry, An error occurred!", Key .Success = False})
            End Try
        End Function

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
                Dim resut = _accountService.SignUp(signupViewModel)
                If resut IsNot Nothing Then
                    Dim link As String = "https://localhost:44340/Account/ConfirmPassword?key=" + resut.APIkey
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

        Function ForgotPassword() As ActionResult
            Return View()
        End Function

        ''' <summary>
        ''' confirm password
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Function ConfirmPassword(ByVal key As String) As ActionResult
            Try
                Dim userViewModel As UserViewModel = New UserViewModel()
                userViewModel.ApiKey = key
                Return View(userViewModel)
            Catch __unusedException1__ As Exception
                Return View()
            End Try
        End Function

        <HttpPost>
        Public Function ConfirmPassword(ByVal userViewModel As UserViewModel) As ActionResult
            Try
                _accountService.UpdatePassword(userViewModel)
                Return Json(New With {Key .Success = True})
            Catch __unusedException1__ As Exception
                Return Json(New With {Key .Success = False})
            End Try
        End Function

        Function EmailSent() As ActionResult
            Return View()
        End Function

    End Class
End Namespace