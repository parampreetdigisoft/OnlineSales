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

Partial Public Class CatalogLevel2
    Public Property CategoryLevel2Id As Integer
    Public Property UserId As Integer
    Public Property Name As String
    Public Property Sequence As Byte
    Public Property TimeFrom As Short
    Public Property TimeTo As Short

    Public Overridable Property OurCustomer As OurCustomer
    Public Overridable Property CatalogLevel3 As ICollection(Of CatalogLevel3) = New HashSet(Of CatalogLevel3)

End Class
