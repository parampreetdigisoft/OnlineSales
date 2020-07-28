@ModelType OnlineSales.Web.UserViewModel
@Code
    ViewData("Title") = "ConfirmPassword"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<section class="login-div confirm-password">
    <div class="container">
        <input type="hidden" class="form-control" id="ApiKey" value="@Model.ApiKey" />
        <h1>Thanks for confirming your Email</h1>
        <div class="row">
            <div class="col-md-7 col-lg-5 mx-auto">
                <div class="inner-login-div">
                    <h4>Please create a password for your account</h4>
                    <div class="form-group">
                        <div class="for-icon">
                            <input type="password"
                                   class="form-control"
                                   id="password"
                                   placeholder="Password" />
                            @*pass password textbox id in both methods (showpassword and hidepaasword)*@
                            <i class="fa fa-eye-slash cursor-pointer" id="eyeSlash" aria-hidden="true" onclick="showPassword('password')"></i>
                            <i class="fa fa-eye cursor-pointer d-none" id="eye" aria-hidden="true" onclick="hidePassword('password')"></i>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="for-icon">
                            <input type="password"
                                   class="form-control"
                                   id="confirmPassword"
                                   placeholder="Confirm Password" />
                            <i class="fa fa-lock" aria-hidden="true"></i>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="container-checkbox">
                            I accept the <a href="">Service Agreement</a>
                            <input type="checkbox" checked="checked" id="service-agreement" />
                            <span class="checkmark"></span>
                        </label>
                    </div>
                    <div class="form-group">
                        <div class="error_message"></div>
                    </div>
                    <button type="button" class="btn custom-btn" onclick="SavePassword()">CONTINUE</button>
                </div>
            </div>
        </div>
    </div>
</section>

<script type="text/javascript">
    function SavePassword() {
        var isValid = true;
        var apiKey = $("#ApiKey").val();
        var password = $.trim($("#password").val());
        var confirmPassword = $.trim($("#confirmPassword").val());

        if (password.length == 0) {
            $("#password").addClass("is-invalid");
            isValid = false;
        }

        if (confirmPassword.length == 0) {
            $("#confirmPassword").addClass("is-invalid");
            isValid = false;
        }

        if (!$("#service-agreement").is(":checked")) {
            $(".error_message").html("<div class='alert alert-danger'>Please accept the service agrrement.</div>");
            isValid = false;
        }


        if (!isValid) {
            return false;
        }

        if (password != confirmPassword) {
            $(".error_message").html("<div class='alert alert-danger'>Password does not match!</div>");
            return false;
        }

        var error = "Password Requires :<br /><br />1. Minimum 8 characters<br />2. Maximum 20 characters<br />3. At least one uppercase character<br />4. At least one lowercase character<br />5. At least one digit<br />6. At least one special character";
        var strongRegex = new RegExp(/^(?=.*\d)(?=.*[!@@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{8,}$/);
        if (!strongRegex.test(password)) {
            $(".error_message").html("<div class='alert alert-danger text-left'>" + error + "</div>");
            return false;
        }

        if (isValid) {
            var userViewModel = {};
            userViewModel.ApiKey = apiKey;
            userViewModel.Password = password;
            showLoader();
            $.ajax({
                url: "/Account/ConfirmPassword",
                type: "POST",
                data: JSON.stringify(userViewModel),
                contentType: 'application/json',
                dataType: "json",
                success: function (data) {
                    if (data.Success === true) {
                        SuccessMessage("Update Successfully.");
                        setTimeout(function () {
                            //window.location.href = data.Url;
                            window.location.href = "/Account/Index";
                        }, 2000);
                    }
                    else {
                        ErrorMessage(ErrorMessageContent());                        
                    }
                    hideLoader();
                },
                error: function (er) {
                    hideLoader();
                    ErrorMessage(ErrorMessageContent());
                    console.log(er);
                }
            });
        }
    }
</script>