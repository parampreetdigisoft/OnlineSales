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

Partial Public Class Contact
    Public Property ContactId As Integer
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Address1 As String
    Public Property Address2 As String
    Public Property City As String
    Public Property State As String
    Public Property Zip As String
    Public Property Country As String
    Public Property Phone As String
    Public Property Phone2 As String
    Public Property email As String

    Public Overridable Property OurCustomers As ICollection(Of OurCustomer) = New HashSet(Of OurCustomer)

End Class
