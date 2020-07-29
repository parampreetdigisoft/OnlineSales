Imports System.Net.Http
Imports Newtonsoft.Json
Imports OnlineSales.Web.OnlineSales.Web
Imports Stripe

Public Class AccountService
    Implements IAccount

#Region "Properties"
    Private Property _ourCustomerRepository As OurCustomerRepository
    Private Property _loginRepository As LoginRepository
    Private Property _couponRepository As CouponRepository

#End Region

#Region "Constructor"
    Public Sub New()
        _ourCustomerRepository = New OurCustomerRepository()
        _loginRepository = New LoginRepository()
        _couponRepository = New CouponRepository()
    End Sub
#End Region

#Region "Methods"

    ''' <summary>
    ''' sign up our customer
    ''' </summary>
    ''' <param name="signupViewModel"></param>
    ''' <returns></returns>
    Public Function SignUp(ByVal signupViewModel As SignupViewModel) As OurCustomer Implements IAccount.SignUp
        Dim cutomer As OurCustomer = New OurCustomer With {
            .Email = signupViewModel.Email,
            .SubDomain = Utils.CreateSubdomain(signupViewModel.StoreName),
            .bTestMode = True, ' need to to ask for this property from where come these value
            .FirstVisit = True,
            .DirectFlag = False,
            .SignupStep = 0,
            .ServiceLevel = 1,
            .OpenDate = DateTime.UtcNow,
            .Affiliate = False,
            .Qbooks = False,
            .Coupons = False,
            .CustomerTracking = False,
            .UpsDesktop = False,
            .DigitalDownloads = False,
            .Labels = False,
            .OtherOption2 = False,
            .OtherOption3 = False,
            .AutoResponder = 1,
            .Currency = "USD",
            .CurrencySymbol = "$",
            .SendText = True
        }

        'check subdomain name is already exist or not
        Dim ourCustomer = _ourCustomerRepository.GetBySubdomain(cutomer.SubDomain)

        ' if subdomain is unique then add
        If ourCustomer Is Nothing Then
            ' add in ourcustomer table
            _ourCustomerRepository.Add(cutomer)

            ' add in _login table
            Dim login As C_login = New C_login With {
            .UserId = cutomer.UserId,
            .Email = signupViewModel.Email,
            .Login = signupViewModel.Email,
            .AccessLevel = 1,
            .Master = False,
            .Active = False,
            .Signup = DateTime.UtcNow
        }
            _loginRepository.Add(login)
            _ourCustomerRepository = New OurCustomerRepository()
            Dim ourCustomerInfo = _ourCustomerRepository.GetDataById(cutomer.UserId)
            Return ourCustomerInfo
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' apply coupon
    ''' </summary>
    ''' <param name="couponCode"></param>
    ''' <returns></returns>
    Public Function IsCouponValid(ByVal couponCode As String) As ResponseViewModel Implements IAccount.IsCouponValid
        Dim responseViewModel As ResponseViewModel = New ResponseViewModel
        ' get login info by username
        Dim coupon = _couponRepository.GetByCode(couponCode)
        ' check username is exist or not
        If (coupon Is Nothing) Then
            responseViewModel.Status = False
            responseViewModel.Message = "Coupon is invalid."
        Else
            If coupon.ExpirationDate.Date <= DateTime.Now.Date Then
                responseViewModel.Status = False
                responseViewModel.Message = "Coupon is expired."
            Else
                responseViewModel.Status = True
                responseViewModel.Message = "Coupon is successfully applied."
            End If
        End If
        Return responseViewModel
    End Function

    ''' <summary>
    ''' update password
    ''' </summary>
    ''' <param name="userViewModel"></param>
    Public Function UpdatePassword(ByVal userViewModel As UserViewModel) Implements IAccount.UpdatePassword
        ' get customer info by apikey
        Dim ourCustomer = _ourCustomerRepository.GetByApiKey(userViewModel.ApiKey)
        ' get login info by user id
        Dim login = _loginRepository.GetByUserId(ourCustomer.UserId)
        If login IsNot Nothing Then
            ' update password into login table
            login.Password = Encryption.Encrypt(userViewModel.Password)
            login.Active = True
            login.IsNew = True
            _loginRepository.Update(login)

            ' Update into ourcutomer table
            ourCustomer.EmailVerified = 1
            ourCustomer.SignupStep = 1
            _ourCustomerRepository.Update(ourCustomer)
            ''Using client As HttpClient = New HttpClient()
            ''    'Using response As HttpResponseMessage = client.GetAsync(Page)
            ''    Dim Content As StringContent = New StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")
            ''    Dim apiBaseUrl As String = "https://app.getresponse.com/"
            ''    Dim endpoint As String = apiBaseUrl + "/Contact"
            ''    'Using content As HttpContent = response.Content
            ''    Using response As HttpResponseMessage = Await client.PostAsync(endpoint, Content)
            ''        If response.StatusCode = Net.HttpStatusCode.OK Then
            ''            'ourCustomer.IsNew = 1
            ''            _ourCustomerRepository.Update(ourCustomer)
            ''            'response.Write(String.Format("<script>window.location.href='{0}';</script>", "http://whatever.com"));
            ''        Else
            ''            _ourCustomerRepository.Update(ourCustomer)
            ''        End If
            ''    End Using
            ''    'End Using
            ''End Using
        End If
        Return ourCustomer.UserId
    End Function

    ''' <summary>
    ''' get ourcutomer detail by email address
    ''' </summary>
    ''' <param name="email"></param>
    ''' <returns></returns>
    Public Function GetOurCustomerByEmail(ByVal email As String) As OurCustomer Implements IAccount.GetOurCustomerByEmail
        Return _ourCustomerRepository.GetbyEmailAddress(email)
    End Function
    ''' <summary>
    ''' SaveStripe Auth details
    ''' </summary>
    ''' <param name="stripeResponse"></param>
    ''' <returns></returns>
    Public Function SaveStripeAuthToken(ByVal stripeResponse As OAuthToken) As ResponseViewModel Implements IAccount.SaveStripeAuthToken
        Dim responseViewModel As ResponseViewModel = New ResponseViewModel

        Dim email = HttpContext.Current.Session("email").ToString()
        If (Not String.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session("email")))) Then

            ' get ourCustomer info by email
            Dim ourCustomer = _ourCustomerRepository.GetbyEmailAddress("parampreet.digisoft@gmail.com")
            Try

                If ourCustomer IsNot Nothing Then

                    ' Update into ourcutomer table
                    ourCustomer.EmailVerified = 1
                    ourCustomer.SignupStep = 1
                    _ourCustomerRepository.Update(ourCustomer)
                    responseViewModel.Status = True
                    responseViewModel.Message = "Successfully Updated"
                Else
                    responseViewModel.Status = False
                    responseViewModel.Message = "Invalid Customer "

                End If
            Catch ex As Exception
                responseViewModel.Status = False
                responseViewModel.Message = "Invalid Customer"
                Return responseViewModel
            End Try
        End If


        Return responseViewModel
    End Function



    ''' <summary>
    ''' authenticate user
    ''' </summary>
    ''' <param name="loginViewModel"></param>
    ''' <returns></returns>
    Public Function Authenticate(ByVal loginViewModel As LoginViewModel) As ResponseViewModel Implements IAccount.Authenticate
        Dim responseViewModel As ResponseViewModel = New ResponseViewModel
        ' get login info by username
        Dim login = _loginRepository.GetByEmail(loginViewModel.Username)
        ' check username is exist or not
        If (login Is Nothing) Then
            responseViewModel.Status = False
            responseViewModel.Message = "Incorrect Username or Email"
        Else
            ' check password is match or not
            'Dim encryptPassword = Encryption.Decrypt(loginViewModel.Password)
            Dim encryptPassword = Encryption.Encrypt(loginViewModel.Password)
            If login.Password = encryptPassword Then
                responseViewModel.Status = True
                responseViewModel.Message = "Successfully Login"
            Else
                responseViewModel.Status = False
                responseViewModel.Message = "Incorrect Password"
            End If
        End If
        Return responseViewModel
    End Function

#End Region

End Class
