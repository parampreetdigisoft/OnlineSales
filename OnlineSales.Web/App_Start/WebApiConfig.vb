Imports System.Web.Http

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)

        ' Web API routes
        config.MapHttpAttributeRoutes()
        config.Routes.MapHttpRoute(name:="DefaultApi", routeTemplate:="api/{controller}/{id}", defaults:=New With {Key .id = RouteParameter.[Optional]
        })

        Dim json = config.Formatters.JsonFormatter
        json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects
        config.Formatters.Remove(config.Formatters.XmlFormatter)
    End Sub
End Module

