Imports OnlineSales.Web.OnlineSales.Web
Public Class OurCustomerRepository
    Inherits GenericRepository(Of OurCustomer)

    Public Function GetBySubdomain(subdomain As String) As OurCustomer
        Return _context.OurCustomers.FirstOrDefault(Function(x) x.SubDomain.ToLower().Trim() = subdomain.ToLower().Trim())
    End Function

    Public Function GetByApiKey(apiKey As String) As OurCustomer
        Return _context.OurCustomers.FirstOrDefault(Function(x) x.APIkey.ToLower().Trim() = apiKey.ToLower().Trim())
    End Function

    Public Function GetDataById(id As Integer) As OurCustomer
        Return _context.OurCustomers.FirstOrDefault(Function(x) x.UserId = id)
    End Function

    Public Function GetbyEmailAddress(email As String) As OurCustomer
        Return _context.OurCustomers.FirstOrDefault(Function(x) x.Email = email)
    End Function

End Class


