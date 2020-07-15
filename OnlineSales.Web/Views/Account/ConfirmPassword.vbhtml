@ModelType OnlineSales.Web.UserViewModel 
@Code
    ViewData("Title") = "ConfirmPassword"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Html.BeginForm("ConfirmPaasword", "Account", FormMethod.Post, New With {.id = "confirm-password"}){
<section class="login-div confirm-password">
    <div class="container">
        <input type="hidden" class="form-control" id="ApiKey" value="@Model.ApiKey" />
        <h1>Thanks for confirming your Email</h1>
        <div class="row">
            <div class="col-md-6 col-lg-5 mx-auto">
                <div class="inner-login-div">
                    <h4>Please create a password for your account</h4>
                    <div class="form-group">
                        <div class="for-icon">
                            <input type="password"
                                   class="form-control"
                                   id="password"
                                   placeholder="Password" />
                            <i class="fa fa-lock" aria-hidden="true"></i>
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
                            <input type="checkbox" checked="checked" />
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
}

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

            $.ajax({
                url: "/Account/ConfirmPassword",
                type: "POST",
                data: JSON.stringify(userViewModel),
                contentType: 'application/json',
                dataType: "json",
                success: function (data) {
                    if (data.Success === true) {
                        window.location.href = "/Account/Index";
                    }
                    else {
                        ErrorMessage("An error occured.");
                        return false;
                    }
                },
                error: function (er) {
                    ErrorMessage("An error occured.");
                    console.log(er);
                }
            });
        }
    }
</script>