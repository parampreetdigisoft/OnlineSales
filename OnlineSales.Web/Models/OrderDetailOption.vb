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

    Partial Public Class OrderDetailOption
        Public Property OrderOptionId As Integer
        Public Property OrderDetailId As Integer
        Public Property ItemOptionId As Integer
        Public Property OptionGroupId As Nullable(Of Integer)
        Public Property Price As Decimal
        Public Property Half As String
    
        Public Overridable Property ItemOption As ItemOption
        Public Overridable Property OrderSubOptions As ICollection(Of OrderSubOption) = New HashSet(Of OrderSubOption)
    
    End Class

End Namespace
