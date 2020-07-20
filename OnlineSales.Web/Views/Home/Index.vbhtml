@ModelType OnlineSales.Web.StripeViewModel

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@If Model.IsStripeAccessToken Then
    @<div>Connect to Stripe</div>
Else
    @<div>else</div>
End If


