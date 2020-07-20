Imports System.IO
Imports System.Runtime.CompilerServices

Module ViewExtensions
    <Extension()>
    Function RenderToString(ByVal partialView As PartialViewResult) As String
        Dim httpContext = System.Web.HttpContext.Current

        If httpContext Is Nothing Then
            Throw New NotSupportedException("An HTTP context is required to render the partial view to a string")
        End If

        Dim controllerName = httpContext.Request.RequestContext.RouteData.Values("controller").ToString()
        Dim controller = CType(ControllerBuilder.Current.GetControllerFactory().CreateController(httpContext.Request.RequestContext, controllerName), ControllerBase)
        Dim controllerContext = New ControllerContext(httpContext.Request.RequestContext, controller)
        Dim view = ViewEngines.Engines.FindPartialView(controllerContext, partialView.ViewName).View
        Dim sb = New StringBuilder()

        Using sw = New StringWriter(sb)

            Using tw = New HtmlTextWriter(sw)
                view.Render(New ViewContext(controllerContext, view, partialView.ViewData, partialView.TempData, tw), tw)
            End Using
        End Using

        Return sb.ToString()
    End Function
End Module
