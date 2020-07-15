@ModelType OnlineSales.Web.SignupViewModel

@Code
    ViewData("Title") = "SignUp"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Html.BeginForm("Signup", "Account", FormMethod.Post, New With {.id = "SignupForm"}){
<section class="login-div signup-div">
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-lg-5 mx-auto">
                <div class="inner-login-div">
                    <h4>This is the Signup form</h4>
                    <figure>
                        <img src="~/Images/group.jpg" class="d-block w-100" alt="" />
                    </figure>
                    <h6>Start Yoyr 15day free trial</h6>
                    <div class="form-group">
                        <div class="for-icon">
                            <input type="email"
                                   class="form-control"
                                   id="email"
                                   aria-describedby="emailHelp"
                                   placeholder="Email" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="for-icon">
                            <input type="text"
                                   class="form-control"
                                   id="store-name"
                                   placeholder="Store Name" />
                        </div>
                    </div>

                    <button type="button" class="btn custom-btn" onclick="Signup()">
                        Start Trial
                    </button>
                    <a href="" class="free-days">
                        Try Nifty cart for 15days, No risk and no credit card
                        required
                    </a>
                </div>
            </div>
        </div>
    </div>
</section>
    }
<script type="text/javascript">
    function Signup() {
        var isValid = true;
        var email = $.trim($("#email").val());
        var storeName = $.trim($("#store-name").val()); 

        if (email.length == 0) {
            $("#email").addClass("is-invalid");
            isValid = false;
        }

        if (storeName.length == 0) {
            $("#store-name").addClass("is-invalid");
            isValid = false;
        }

        if (isValid) {
            var signupViewModel = {};
            signupViewModel.Email = email;
            signupViewModel.StoreName = storeName;

            $.ajax({
                url: "/Account/Signup",
                type: "POST",
                data: JSON.stringify(signupViewModel),
                contentType: 'application/json',
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    if (data.Success === true) {
                        window.location.href = "/Account/EmailSent";
                    }
                    else {
                        WarningMessage(data.Message);
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