Imports OnlineSales.Web.OnlineSales.Web

Public Class CouponRepository
    Inherits GenericRepository(Of Coupon)

    Public Function GetByCode(couponCode As String) As Coupon
        Return _context.Coupons.FirstOrDefault(Function(x) x.CouponCode.ToLower().Trim() = couponCode.ToLower().Trim())
    End Function

End Class
