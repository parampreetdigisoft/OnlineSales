@ModelType OnlineSales.Web.LoginViewModel

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<script type="text/javascript">
    $(document).ready(function () {
        $('#LoginForm').captcha();
        $("#captchaInput").addClass("form-control");
    });
</script>

@Html.BeginForm("Index", "Account", FormMethod.Post, New With {.id = "LoginForm"}){
@Html.ValidationSummary(True)
<section Class="login-div">
    <div Class="container">
        <div Class="row">
            <div Class="col-md-6 col-lg-5 mx-auto">
                <div Class="inner-login-div">
                    <span Class="user-round">
                        <i Class="fa fa-user" aria-hidden="true"></i>
                    </span>
                    <h4> Login</h4>
                    <div Class="form-group">
                        <Label for="exampleInputEmail1">Username Or Email</Label>
                        <div Class="for-icon">
                            @Html.TextBoxFor(Function(model) model.Username, New With {Key .class = "form-control", Key .Type = "email"})
                            <i class="fa fa-user" aria-hidden="true"></i>
                            @Html.ValidationMessageFor(Function(model) model.Username)
                        </div>
                    </div>
                    <div Class="form-group">
                        <Label for="exampleInputPassword1">Password</Label>
                        <div Class="for-icon">
                            @Html.PasswordFor(Function(model) model.Password, New With {Key .class = "form-control", Key .Type = "password", Key .id = "password"})
                            @*pass password textbox id in both methods (showpassword and hidepaasword)*@
                            <i class="fa fa-eye-slash cursor-pointer" id="eyeSlash" aria-hidden="true" onclick="showPassword('password')"></i>
                            <i class="fa fa-eye cursor-pointer d-none" id="eye" aria-hidden="true" onclick="hidePassword('password')"></i>
                            @Html.ValidationMessageFor(Function(model) model.Password)
                        </div>
                    </div>
                    <input type="submit" Class="btn custom-btn mt-3" value="Access"/>
                    @Html.ActionLink("Forgot your password?", "ForgotPassword", "Account", New With {.class = "forget-password"})
                    @Html.ActionLink("Sign up", "Signup", "Account", New With {.class = "btn custom-btn"})
                    <div class="form-group"><div class="error_message"></div></div>
                </div>
            </div>
        </div>
    </div>
</section>
    }
