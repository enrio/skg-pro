Imports System.ComponentModel.DataAnnotations

Public Class User

    <Key()>
    Public Overridable Property UserId As Guid

    <Required()>
    Public Overridable Property Username As String
    <Required()>
    Public Overridable Property Email As String
    <Required, DataType(DataType.Password)>
    Public Overridable Property Password As String

    Public Overridable Property FirstName As String
    Public Overridable Property LastName As String

    <DataType(DataType.MultilineText)>
    Public Overridable Property Comment As String

    Public Overridable Property IsApproved As Boolean
    Public Overridable Property PasswordFailuresSinceLastSuccess As Integer
    Public Overridable Property LastPasswordFailureDate As DateTime?
    Public Overridable Property LastActivityDate As DateTime?
    Public Overridable Property LastLockoutDate As DateTime?
    Public Overridable Property LastLoginDate As DateTime?
    Public Overridable Property ConfirmationToken As String
    Public Overridable Property CreateDate As DateTime?
    Public Overridable Property IsLockedOut As Boolean
    Public Overridable Property LastPasswordChangedDate As DateTime?
    Public Overridable Property PasswordVerificationToken As String
    Public Overridable Property PasswordVerificationTokenExpirationDate As DateTime?

    Public Overridable Property Roles As ICollection(Of Role)

End Class