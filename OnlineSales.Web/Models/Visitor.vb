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

    Partial Public Class Visitor
        Public Property VisitorId As Long
        Public Property FirstVisit As Date
        Public Property UserId As Nullable(Of Long)
    
        Public Overridable Property VisitorTrackings As ICollection(Of VisitorTracking) = New HashSet(Of VisitorTracking)
    
    End Class

End Namespace
