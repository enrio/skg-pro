Imports System.ComponentModel.DataAnnotations

Public Class Role

    <Key()>
    Public Overridable Property RoleId As Guid

    <Required()>
    Public Overridable Property RoleName As String

    Public Overridable Property Description As String

    Public Overridable Property Users As ICollection(Of User)

End Class