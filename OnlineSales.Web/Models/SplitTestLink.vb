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

Partial Public Class SplitTestLink
    Public Property SplitTestLinkId As Integer
    Public Property SplitTestId As Integer
    Public Property TestURL As String
    Public Property PercentageRun As Short

    Public Overridable Property SplitTest As SplitTest
    Public Overridable Property SplitTestCaptures As ICollection(Of SplitTestCapture) = New HashSet(Of SplitTestCapture)

End Class
