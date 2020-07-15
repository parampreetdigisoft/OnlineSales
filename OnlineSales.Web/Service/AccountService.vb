Imports OnlineSales.Web.OnlineSales.Web

Public Class AccountService
    Implements IAccount
    Private Property _ourCustomerRepository As OurCustomerRepository
    Private Property _loginRepository As LoginRepository


    Public Sub New()
        _ourCustomerRepository = New OurCustomerRepository()
        _loginRepository = New LoginRepository()
    End Sub

    Public Function SignUp(ByVal signupViewModel As SignupViewModel) As OurCustomer Implements IAccount.SignUp
        Dim cutomer As OurCustomer = New OurCustomer With {
            .Email = signupViewModel.Email,
            .SubDomain = Utils.CreateSubdomain(signupViewModel.StoreName),
            .bTestMode = True, ' need to to ask for this property from where come these value
            .FirstVisit = True,
            .DirectFlag = False,
            .SignupStep = 0,
            .ServiceLevel = 1,
            .OpenDate = "2020-07-14 12:38:00",
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
            .Signup = "2020-07-08 18:51:00"
        }
            _loginRepository.Add(login)
            Return _ourCustomerRepository.GetById(cutomer.UserId)
        Else
            Return Nothing
        End If
    End Function

    Public Function Authenticate(ByVal loginViewModel As LoginViewModel) As Boolean Implements IAccount.Authenticate
        'Dim cutomer As OurCustomer = New OurCustomer With {
        '    .Email = SignupViewModel.Email,
        '    .SubDomain = CreateSubdomain(SignupViewModel.StoreName)
        '}

        ''check subdomain name is already exist or not
        'Dim ourCustomer = _ourCustomerRepository.GetBySubdomain(cutomer.SubDomain)
        'If ourCustomer IsNot Nothing Then
        '    _ourCustomerRepository.Add(cutomer)
        '    _ourCustomerRepository.Save()
        '    Return True
        'Else
        '    Return False
        'End If
        Return True
    End Function

    Sub UpdatePassword(ByVal userViewModel As UserViewModel) Implements IAccount.UpdatePassword
        Dim ourCustomer = _ourCustomerRepository.GetByApiKey(userViewModel.ApiKey)
        Dim login = _loginRepository.GetById(ourCustomer.UserId)
        ' need to do save encrypted password
        If login IsNot Nothing Then
            login.Password = userViewModel.Password
            login.Active = True
            _loginRepository.Update(login)
        End If
    End Sub

End Class
