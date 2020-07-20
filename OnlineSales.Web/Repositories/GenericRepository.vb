Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports OnlineSales.Web.OnlineSales.Web

Public Class GenericRepository(Of T As Class)
    Implements IRepository(Of T)

    Public ReadOnly _context As OnlineSalesEntities
    Public _table As DbSet(Of T)
    Public Sub New()
        _context = New OnlineSalesEntities()
        _table = _context.Set(Of T)()
    End Sub

    Public Function Add(record As T) As T Implements IRepository(Of T).Add
        _table.Add(record)
        _context.SaveChanges()
        Return record
    End Function

    Public Sub AddList(records As IEnumerable(Of T)) Implements IRepository(Of T).AddList
        _table.AddRange(records)
        _context.SaveChanges()
    End Sub

    Public Function Update(record As T) As T Implements IRepository(Of T).Update
        _table.AddOrUpdate(record)
        If _context.Entry(record).State = EntityState.Detached Then
            _context.Entry(record).State = EntityState.Modified
        End If
        _context.SaveChanges()
        Return record
    End Function

    Public Sub Remove(key As Object) Implements IRepository(Of T).Remove
        Dim record As T = _table.Find(key)
        _table.Remove(record)
        _context.SaveChanges()
    End Sub

    Public Sub RemoveList(records As IEnumerable(Of T)) Implements IRepository(Of T).RemoveList
        _table.RemoveRange(records)
        _context.SaveChanges()
    End Sub


    Public Function GetById(key As Object) As T Implements IRepository(Of T).GetById
        Return _table.Find(key)
    End Function

End Class
