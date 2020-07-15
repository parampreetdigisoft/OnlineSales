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

<body>
    @Html.BeginForm("Index", "Account", FormMethod.Post, New With {.id = "LoginForm"}){
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
                                <input type="email"
                                       Class="form-control"
                                       id="exampleInputEmail1"
                                       aria-describedby="emailHelp" /><i class="fa fa-user" aria-hidden="true"></i>
                            </div>
                        </div>
                        <div Class="form-group">
                            <Label for="exampleInputPassword1">Password</Label>
                            <div Class="for-icon">
                                <input type="password"
                                       Class="form-control"
                                       id="exampleInputPassword1" />
                                <i Class="fa fa-lock" aria-hidden="true"></i>
                            </div>
                        </div>
                        <input type="submit" Class="btn custom-btn mt-3" value="Access" />
                        @Html.ActionLink("Forgot your password?", "ForgotPassword", "Account", New With {.class = "forget-password"})
                        @Html.ActionLink("Sign up", "Signup", "Account", New With {.class = "btn custom-btn"})
                    </div>
                </div>
            </div>
        </div>
    </section>
    }
</body>

