﻿Imports OnlineSales.Web.OnlineSales.Web

Public Interface IAccount
    Function SignUp(ByVal signupViewModel As SignupViewModel) As OurCustomer
    Function Authenticate(ByVal loginViewModel As LoginViewModel) As ResponseViewModel
    Function UpdatePassword(ByVal userViewModel As UserViewModel)
    Function GetOurCustomerByEmail(ByVal email As String) As OurCustomer
    Function IsCouponValid(ByVal couponCode As String) As ResponseViewModel

End Interface
