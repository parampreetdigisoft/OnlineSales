Imports System.Net
Imports System.Net.Mail

Public Class Utils

    Public Shared Property SystemEmail As String
    Public Shared Property SystemPassword As String
    Public Shared Property Port As String
    Public Shared Property Host As String

    ''' <summary>
    ''' send mail
    ''' </summary>
    ''' <param name="emailTo"></param>
    ''' <param name="body"></param>
    ''' <param name="subject"></param>
    ''' <param name="cc"></param>
    Public Shared Sub SendEmail(ByVal emailTo As String, ByVal body As String, ByVal subject As String, ByVal Optional cc As String = Nothing)
        Using client As SmtpClient = New SmtpClient()
            Dim credential As NetworkCredential = New NetworkCredential With {
                .UserName = SystemEmail,
                .Password = SystemPassword
            }
            client.UseDefaultCredentials = false
            client.Credentials = credential
            client.Host = Host
            client.Port = Convert.ToInt32(Port)
            client.EnableSsl = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Using emailMessage As MailMessage = New MailMessage()
                emailMessage.[To].Add(New MailAddress(emailTo))

                If Not String.IsNullOrEmpty(cc) Then
                    emailMessage.CC.Add(New MailAddress(cc))
                End If

                emailMessage.From = New MailAddress(SystemEmail)
                emailMessage.Subject = subject
                emailMessage.Body = body.ToString()
                emailMessage.IsBodyHtml = True
                client.Send(emailMessage)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' verifiction email content
    ''' </summary>
    ''' <param name="storeName"></param>
    ''' <param name="link"></param>
    ''' <returns></returns>
    Public Shared Function VerificationPasswordContent(ByVal storeName As String, ByVal link As String) As String
        Dim content As String
        Dim userMailLink As String = "mailto:info@NiftyCart.com"
        content = "<b>Hello " + storeName + ",</b><br/><br/>" + "Welcome to the NiftyCart Tribe. We're here to assist you in getting the most out of your store. <br/><br/>" +
            "Please confirm your email address by <a href='" + link + "'>clicking here</a>. <br/><br/> Please don't hesitate to contact us if we can be of assistance in any way." +
            "<br/><br/> Email -  <a href='" + userMailLink + "'>  info@NiftyCart.com </a> or by phone <b>800-211-4931</b> in the US or <b>808-870-8741</b> elsewhere. <br/><br/> Regards, <br/><br/> Nicholas Hurd" +
            "<br/> <b>NiftyCart.com (a Service of Listening Software, Inc. <br/> P.O. Box 532484 <br/> Kihei, Hi 96753 USA)</b>"
        Return content
    End Function

    ''' <summary>
    ''' convert store name to subdomain
    ''' </summary>
    ''' <param name="storeName"></param>
    ''' <returns></returns>
    Public Shared Function CreateSubdomain(ByVal storeName As String) As String
        Return Regex.Replace(storeName, "[^\w\d\s]", "").Replace(" ", "")
    End Function

End Class
