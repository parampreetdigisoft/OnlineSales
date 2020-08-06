Imports System.Net
Imports System.Net.Mail
Imports RestSharp

Public Class Utils

    Public Shared Property SystemEmail As String
    Public Shared Property SystemPassword As String
    Public Shared Property Account As String
    Public Shared Property Port As String
    Public Shared Property Host As String
    Public Shared Property StripeApiKey As String

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
                .UserName = Account,
                .Password = SystemPassword
            }
            client.UseDefaultCredentials = False
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
    ''' convert store name to subdomain
    ''' </summary>
    ''' <param name="storeName"></param>
    ''' <returns></returns>
    Public Shared Function CreateSubdomain(ByVal storeName As String) As String
        Return Regex.Replace(storeName, "[^\w\d\s]", "").Replace(" ", "")
    End Function

    Public Shared Function GetPublicIPAddress() As String
        Dim address As String = String.Empty
        Try
            Dim client As RestClient = New RestClient("http://checkip.dyndns.org/")
            Dim request = New RestRequest(Method.GET)

            Dim response As IRestResponse = client.Execute(request)
            If response.StatusCode = HttpStatusCode.OK Then
                address = Convert.ToString(response.Content)
                Dim first As Integer = address.IndexOf("Address: ") + 9
                Dim last As Integer = address.LastIndexOf("</body>")
                address = Convert.ToString(address.Substring(first, last - first))
                Return address
            End If
        Catch __unusedException1__ As Exception
            Dim er As String = __unusedException1__.Message
        End Try
        Return address
    End Function

End Class
