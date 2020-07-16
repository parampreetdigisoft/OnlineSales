@Code
    ViewData("Title") = "ForgotPassword"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<section class="login-div confirm-password">
    <div class="container">
        <h1>Reset your password</h1>
        <div class="row">
            <div class="col-md-6 col-lg-5 mx-auto">
                <div class="inner-login-div">
                    <h4>Please enter an email</h4>
                    <div class="form-group">
                        <div class="for-icon">
                            <input type="email" class="form-control" id="email" placeholder="Email" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="error_message"></div>
                    </div>
                    <button type="button" class="btn custom-btn" onclick="forgotPassword()">CONTINUE</button>
                </div>
            </div>
        </div>
    </div>
</section>


<script type="text/javascript">
    function forgotPassword() {
        var isValid = true;
        var email = $.trim($("#email").val());

        if (email.length == 0) {
            $("#email").addClass("is-invalid");
            isValid = false;
            return false;
        }
        var obj = {};
        obj.email = email;
        if (isValid) {
            $.ajax({
                url: "/Account/ForgotPassword",
                type: "POST",
                data: JSON.stringify(obj),
                contentType: 'application/json',
                dataType: "json",
                success: function (data) {
                    if (data.Success === true) {
                        window.location.href = "/Account/EmailSent";
                    }
                    else {
                        ErrorMessage(data.Message);
                        return false;
                    }
                },
                error: function (er) {
                    ErrorMessage(ErrorMessageContent());
                    console.log(er);
                }
            });
        }
    }
</script>