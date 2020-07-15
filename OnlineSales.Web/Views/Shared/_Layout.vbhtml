<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Nifty Cart</title>
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap"
          rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,500;1,600;1,700;1,800;1,900&display=swap"
          rel="stylesheet" />
    <link rel="stylesheet" href="~/Content/bootstrap.min.css" />
    <link rel="stylesheet" href="~/Content/font-awesome.min.css" />
    <link rel="stylesheet" href="~/Content/reset.css" />
    <link rel="stylesheet" href="~/Content/style.css" />
    <link rel="stylesheet" href="~/Content/responsive.css" />
    <link href="~/Content/toastr.min.css" rel="stylesheet" />
    <script src="~/Scripts/toastr.min.js"></script>
</head>
<body>
    @*<div class="navbar navbar-inverse navbar-fixed-top">
                <div class="container">
                    <div class="navbar-header">
                        <div class="logo-div">
                            <a href=""><img src="images/logo.jpg" alt="" /></a>
                        </div>
                    </div>
                </div>
            </div>*@
    <header>
        <div class="logo-div">
            <a href=""><img src="~/Images/logo.jpg" /></a>
        </div>
    </header>
    <div>
        @RenderBody()
    </div>
    <script src="~/Scripts/jquery-3.4.1.min.js"></script>
    <script src="~/Scripts/Captcha/jquery.captcha.basic.min.js"></script>
</body>
</html>
<script type="text/javascript">
    function ErrorMessage(message) {
        var title = "Failed!";
        toastr.error(message, title, {
            "timeOut": "5",
            "extendedTImeout": "0"
        });
    }
    function InfoMessage(message) {
        var title = "INFO!";
        toastr.info(message, title);
    }
    function WarningMessage(message) {
        toastr.warning(message);
    }
    function SuccessMessage(message) {
        toastr.success(message);
    }
</script>
