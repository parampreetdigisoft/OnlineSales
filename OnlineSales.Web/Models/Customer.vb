'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Customer
    Public Property CustomerId As Integer
    Public Property UserId As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property CompanyName As String
    Public Property Address1 As String
    Public Property Address2 As String
    Public Property City As String
    Public Property State As String
    Public Property Zip As String
    Public Property Country As String
    Public Property ShipToAddress1 As String
    Public Property ShipToAddress2 As String
    Public Property ShipToCity As String
    Public Property ShipToState As String
    Public Property ShipToZip As String
    Public Property ShipToCountry As String
    Public Property ShipToName As String
    Public Property Phone As String
    Public Property Phone2 As String
    Public Property eMailAddr As String
    Public Property CCnumber As String
    Public Property expdate As String
    Public Property StripeToken As String
    Public Property Password As String
    Public Property FacebookId As String
    Public Property TwitterId As String
    Public Property HasOrders As Boolean
    Public Property Active As Boolean
    Public Property OkToEmail As Boolean
    Public Property OkToText As Boolean
    Public Property AutoResponderToken As String
    Public Property SimplyListId As Integer
    Public Property QbCustomerId As String
    Public Property Last4 As String
    Public Property VisitorId As Nullable(Of Long)
    Public Property OpenDate As Nullable(Of Date)

    Public Overridable Property OurCustomer As OurCustomer
    Public Overridable Property OrderHeaders As ICollection(Of OrderHeader) = New HashSet(Of OrderHeader)

End Class
