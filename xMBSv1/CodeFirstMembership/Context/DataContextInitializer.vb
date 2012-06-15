Imports System.Data.Entity

Public Class DataContextInitializer
    Inherits DropCreateDatabaseAlways(Of DataContext)

    Protected Overrides Sub Seed(context As DataContext)
        Membership.CreateUser("Demo", "123456", "demo@demo.com", Nothing, Nothing, True, Nothing)
        Roles.CreateRole("Admin")
        Roles.AddUserToRole("Demo", "Admin")
    End Sub

End Class