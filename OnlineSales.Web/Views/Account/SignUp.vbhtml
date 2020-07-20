@ModelType OnlineSales.Web.SignupViewModel

@Code
    ViewData("Title") = "SignUp"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<section class="login-div signup-div">
    <div class="container">
        <div class="row">
            <div class="col-md-7 col-lg-5 mx-auto">
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

                    <div class="form-group row">
                        <div class=" col-sm-8">
                            <div class="for-icon">
                                <input type="text" class="form-control" id="coupon" placeholder="Coupon" oninput="EnableCoupon()" />
                                <input type="hidden" id="coupon-valid" class="form-control" />
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <button type="button" class="btn custom-btn" onclick="couponApply()" id="btnCouponApply">
                                Apply
                            </button>
                        </div>
                    </div>

                    <div class="form-group couponMessage d-none"></div>

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

<script type="text/javascript">
    function Signup() {
        var isValid = true;
        var email = $.trim($("#email").val());
        var storeName = $.trim($("#store-name").val());
        var coupon = $.trim($("#coupon").val());
        var IscouponValid = parseInt($("#coupon-valid").val());
        if (isNaN(IscouponValid)) { IscouponValid = 0;}

        if (email.length == 0) {
            $("#email").addClass("is-invalid");
            isValid = false;
        }

        if (storeName.length == 0) {
            $("#store-name").addClass("is-invalid");
            isValid = false;
        }

        if (coupon.length > 0 && IscouponValid != 1) {
            var btnText = $("#btnCouponApply").text();
            $("#coupon").addClass("is-invalid");
            isValid = false;
            if (IscouponValid == 0) {
                WarningMessage("Coupon is invalid. Please Remove or change the coupon code.");
            } else {
                WarningMessage("Please apply the coupon first or remove the coupon.");
            }
        }
       

        if (isValid) {
            var signupViewModel = {};
            signupViewModel.Email = email;
            signupViewModel.StoreName = storeName;
            signupViewModel.Coupon = coupon;

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

    function couponApply() {
        var coupon = $.trim($("#coupon").val());
        if (coupon.length > 0) {
            if ($("#coupon").hasClass("is-invalid")) {
                $("#coupon").removeClass("is-invalid")
            }
            var obj = {};
            obj.couponCode = coupon;
            showLoader();
            $.ajax({
                url: "/Account/ApplyCoupon",
                type: "POST",
                data: JSON.stringify(obj),
                contentType: 'application/json',
                dataType: "json",
                success: function (data) {                    
                    if (data.Success === true) {
                        $("#coupon-valid").val(1);
                        $(".couponMessage").removeClass("text-danger").addClass("text-success");
                        $("#btnCouponApply").text("Applied");
                        $("#btnCouponApply").attr("disabled",true);
                    }
                    else {
                        $("#coupon-valid").val(0);
                        $("#coupon").addClass("is-invalid");
                        $(".couponMessage").removeClass("text-success").addClass("text-danger");
                    }
                    $(".couponMessage").html(data.Message);
                    $(".couponMessage").removeClass("d-none");
                    hideLoader();
                },
                error: function (er) {
                    hideLoader();
                    ErrorMessage("An error occured.");
                    console.log(er);
                }
            });
        } else {
            $("#coupon").addClass("is-invalid");
        }
    }

    function EnableCoupon() {
        var btnText = $("#btnCouponApply").text();
        var couponMessage = $.trim($(".couponMessage").html());
        if (couponMessage.length > 0) {
            $(".couponMessage").html("")
        }
        if ($("#coupon").hasClass("is-invalid")) {
            $("#coupon").removeClass("is-invalid")
        }
        if (btnText != "Apply") {
            $("#btnCouponApply").text("Apply");
            $("#btnCouponApply").attr("disabled", false);
        }
        $("#coupon-valid").val(-1);
    }
</script>
