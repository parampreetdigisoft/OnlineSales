Public Interface IRepository(Of T As Class)

    Function GetById(ByVal key As Object) As T
    Function Add(ByVal record As T) As T
    Sub AddList(ByVal records As IEnumerable(Of T))
    Function Update(ByVal record As T) As T
    Sub Remove(ByVal key As Object)
    Sub RemoveList(ByVal records As IEnumerable(Of T))
End Interface
