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

Namespace OnlineSales.Web

    Partial Public Class AffiliateProgram
        Public Property AffiliateProgramId As Integer
        Public Property UserId As Integer
        Public Property Name As String
        Public Property Description As String
        Public Property PayPerLead As Boolean
        Public Property PayPerSale As Boolean
        Public Property CookieDays As Short
        Public Property InfoUrl As String
        Public Property WebUrl As String
        Public Property PctFlag As Nullable(Of Boolean)
        Public Property Amt1 As Nullable(Of Decimal)
        Public Property Amt2 As Nullable(Of Decimal)
        Public Property Offline As Nullable(Of Boolean)
        Public Property EmailNotice As String
        Public Property EmailOrders As String
        Public Property MailListId As Nullable(Of Integer)
    
        Public Overridable Property Affiliates As ICollection(Of Affiliate) = New HashSet(Of Affiliate)
        Public Overridable Property AffiliateLinks As ICollection(Of AffiliateLink) = New HashSet(Of AffiliateLink)
        Public Overridable Property OurCustomer As OurCustomer
    
    End Class

End Namespace
