Imports Newtonsoft.Json

' Summary:
'     Contact Model to Create Contact on GetResponse Api 
'     According to api docs
'       

Public Class ContactModel
    <JsonProperty("name")>
    Public Property name As String
    <JsonProperty("email")>
    Public Property email As String
    <JsonProperty("dayOfCycle")>
    Public Property dayOfCycle As String
    <JsonProperty("ipAddress")>
    Public Property ipAddress As String
    <JsonProperty("campaign")>
    Public Property campaign As Compaign


End Class

Public Class Compaign
    <JsonProperty("campaignId")>
    Public Property campaignId As String
End Class