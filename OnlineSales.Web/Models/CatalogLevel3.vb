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

    Partial Public Class CatalogLevel3
        Public Property CatalogLevel3Id As Integer
        Public Property UserId As Integer
        Public Property Sequence As Short
        Public Property Description As String
        Public Property Image As String
        Public Property FeaturedCategory As Boolean
    
        Public Overridable Property OurCustomer As OurCustomer
        Public Overridable Property CatalogLevel2 As ICollection(Of CatalogLevel2) = New HashSet(Of CatalogLevel2)
    
    End Class

End Namespace
