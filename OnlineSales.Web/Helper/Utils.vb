Imports System.Net
Imports System.Net.Mail
Imports Microsoft.Ajax.Utilities

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
                .UserName = "parampreet.digisoft@gmail.com",
                .Password = "BehindEyes2@"
            }
            client.Credentials = credential
            client.Host = "smtp.gmail.com"
            client.Port = 587
            client.EnableSsl = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Using emailMessage As MailMessage = New MailMessage()
                emailMessage.[To].Add(New MailAddress(emailTo))

                If Not String.IsNullOrEmpty(cc) Then
                    emailMessage.CC.Add(New MailAddress(cc))
                End If

                emailMessage.From = New MailAddress("parampreet.digisoft@gmail.com")
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
        content = "Hello " + storeName + "<br/><br/>" + "Welcome to the NiftyCart Tribe. We're here to assist you in getting the most of your store. <br/><br/>" +
            "Please confirm your email address by <a href='" + link + "'>clicking here</a>. <br/><br/> Please don't hesitate to contact us if we can be of assistance in any way." +
            "<br/><br/> Email - 'info@NiftyCart.com' or by phone 800-211-4931 in the US or 808-870-8741 elsewhere. <br/><br/><br/> Regards, <br/><br/> Nicholas Hurd" +
            "<br/><br/> NiftyCart.com (a Service of Listening Software, Inc. <br/> P.O. Box 532484 <br/> Kihei, Hi 96753 USA)"
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
