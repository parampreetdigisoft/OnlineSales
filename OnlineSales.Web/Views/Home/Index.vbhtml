@ModelType OnlineSales.Web.StripeViewModel

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<section class="login-div confirm-password">
    <div class="container">
        <center>
            @If Model.IsStripeAccessToken Then
                @<a href="javascript:void(0)" data-toggle="modal" data-target="#stripeModal" class="font-20">Connect to Stripe</a>
            Else
                @<div>else</div>
            End If
        </center>
    </div>
</section>

<!-- Modal -->
<div class="modal fade custom-modal" id="stripeModal" tabindex="-1" role="dialog" aria-labelledby="stripeModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="stripeModalLabel">
                    Stripe Configuration
                </h5>
                <button type="button"
                        class="close"
                        data-dismiss="modal"
                        aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <p>If you have already have a Stripe <a href="https://connect.stripe.com/login?redirect=/oauth/authorize?scope=read_write&&response_type=code&&client_id=ca_6x6xL1lJr39m1ShFHsDFeSBPa2e9XqXB&&force_login=true">Click here</a></p>
                <a href="" class="modal-logo">
                    <img src="images/logo.png" alt="" />
                </a>
                <h5>
                    Nifty cart would like you to start accepting payment with stripe.
                </h5>
                <p>
                    Take a minute to answer a few questions and then you'll be ready
                    to go. Niftycard will have access to your data, and can create
                    payments and customers on your behalf.
                </p>
            </div>
            <div class="modal-footer">
                <a href="https://connect.stripe.com/oauth/authorize?response_type=code&&client_id=ca_6x6xL1lJr39m1ShFHsDFeSBPa2e9XqXB&&scope=read_write&&redirect_uri=https://myniftycart.com/niftyapi/api/stripe/StripeAuth" class="custom-modal-btn">Continue</a>
                <a href="" class="custom-modal-btn chn-bg-col" data-dismiss="modal">
                    Close
                </a>
            </div>
        </div>
    </div>
</div>
