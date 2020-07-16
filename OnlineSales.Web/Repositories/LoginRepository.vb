Imports OnlineSales.Web.OnlineSales.Web

Public Class LoginRepository
    Inherits GenericRepository(Of C_login)

    Public Function GetByUserId(userId As Integer) As C_login
        Return _context.C_login.FirstOrDefault(Function(x) x.UserId = userId)
    End Function

    Public Function GetByEmail(email As String) As C_login
        Return _context.C_login.FirstOrDefault(Function(x) x.Email.ToLower().Trim() = email.ToLower().Trim())
    End Function



End Class
