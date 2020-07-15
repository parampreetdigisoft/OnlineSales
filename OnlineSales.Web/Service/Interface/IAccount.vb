Imports OnlineSales.Web.OnlineSales.Web

Public Interface IAccount
    Function SignUp(ByVal signupViewModel As SignupViewModel) As OurCustomer
    Function Authenticate(ByVal loginViewModel As LoginViewModel) As Boolean
    Sub UpdatePassword(ByVal userViewModel As UserViewModel)
End Interface
