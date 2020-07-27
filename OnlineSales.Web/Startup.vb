Imports Microsoft.AspNet.Identity
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Owin

Public Class Startup
    Public Sub Configuration(ByVal app As IAppBuilder)
        ' setting for Owin
        app.UseCookieAuthentication(New CookieAuthenticationOptions With {
        .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        .LoginPath = New PathString("/Account/Index"),
        .CookieSecure = CookieSecureOption.SameAsRequest
    })
        ' set value from web.congig
        Utils.SystemEmail = ConfigurationManager.AppSettings("SystemEmail")
        Utils.SystemPassword = ConfigurationManager.AppSettings("SystemPassword")
        Utils.Account = ConfigurationManager.AppSettings("SMTP_Account")
        Utils.Port = ConfigurationManager.AppSettings("Port")
        Utils.Host = ConfigurationManager.AppSettings("Host")
    End Sub
End Class
