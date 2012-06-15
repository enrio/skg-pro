Public Class CodeFirstRoleProvider
    Inherits RoleProvider

    Public Overrides Property ApplicationName As String = My.Application.Info.AssemblyName

    Public Overrides Function RoleExists(roleName As String) As Boolean
        If String.IsNullOrEmpty(roleName) Then
            Return False
        End If
        Using Context As New DataContext
            Dim Role As Role = Nothing
            Role = Context.Roles.FirstOrDefault(Function(Rl) Rl.RoleName = roleName)
            If Role IsNot Nothing Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Public Overrides Function IsUserInRole(username As String, roleName As String) As Boolean
        If String.IsNullOrEmpty(username) Then
            Return False
        End If
        If String.IsNullOrEmpty(roleName) Then
            Return False
        End If
        Using Context As New DataContext
            Dim User As User = Nothing
            User = Context.Users.FirstOrDefault(Function(Usr) Usr.Username = username)
            If User Is Nothing Then
                Return False
            End If
            Dim Role = Context.Roles.FirstOrDefault(Function(Rl) Rl.RoleName = roleName)
            If Role Is Nothing Then
                Return False
            End If
            Return User.Roles.Contains(Role)
        End Using
    End Function

    Public Overrides Function GetAllRoles() As String()
        Using Context As New DataContext
            Return Context.Roles.Select(Function(Rl) Rl.RoleName).ToArray
        End Using
    End Function

    Public Overrides Function GetUsersInRole(roleName As String) As String()
        If String.IsNullOrEmpty(roleName) Then
            Return Nothing
        End If
        Using Context As New DataContext
            Dim Role As Role = Nothing
            Role = Context.Roles.FirstOrDefault(Function(Rl) Rl.RoleName = roleName)
            If Role IsNot Nothing Then
                Return Role.Users.Select(Function(Usr) Usr.Username).ToArray
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Overrides Function GetRolesForUser(username As String) As String()
        If String.IsNullOrEmpty(username) Then
            Return Nothing
        End If
        Using Context As New DataContext
            Dim User As User = Nothing
            User = Context.Users.FirstOrDefault(Function(Usr) Usr.Username = username)
            If User IsNot Nothing Then
                Return User.Roles.Select(Function(Rl) Rl.RoleName).ToArray
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Overrides Function FindUsersInRole(roleName As String, usernameToMatch As String) As String()
        If String.IsNullOrEmpty(roleName) Then
            Return Nothing
        End If
        If String.IsNullOrEmpty(usernameToMatch) Then
            Return Nothing
        End If
        Using Context As New DataContext
            Return (From Rl In Context.Roles From Usr In Rl.Users Where Rl.RoleName = roleName AndAlso Usr.Username.Contains(usernameToMatch) Select Usr.Username).ToArray()
        End Using
    End Function

    Public Overrides Sub CreateRole(roleName As String)
        If Not String.IsNullOrEmpty(roleName) Then
            Using Context As New DataContext
                Dim Role As Role = Nothing
                Role = Context.Roles.FirstOrDefault(Function(Rl) Rl.RoleName = roleName)
                If Role Is Nothing Then
                    Dim NewRole As New Role With {.RoleId = Guid.NewGuid, .RoleName = roleName}
                    Context.Roles.Add(NewRole)
                    Context.SaveChanges()
                End If
            End Using
        End If
    End Sub

    Public Overrides Function DeleteRole(roleName As String, throwOnPopulatedRole As Boolean) As Boolean
        If String.IsNullOrEmpty(roleName) Then
            Return False
        End If
        Using Context As New DataContext
            Dim Role As Role = Nothing
            Role = Context.Roles.FirstOrDefault(Function(Rl) Rl.RoleName = roleName)
            If Role Is Nothing Then
                Return False
            End If
            If throwOnPopulatedRole Then
                If Role.Users.Any Then
                    Return False
                End If
            Else
                Role.Users.Clear()
            End If
            Context.Roles.Remove(Role)
            Context.SaveChanges()
            Return True
        End Using
    End Function

    Public Overrides Sub AddUsersToRoles(usernames() As String, roleNames() As String)
        Using Context As New DataContext
            Dim Users = Context.Users.Where(Function(Usr) usernames.Contains(Usr.Username)).ToList()
            Dim Roles = Context.Roles.Where(Function(Rl) roleNames.Contains(Rl.RoleName)).ToList()
            For Each User In Users
                For Each Role In Roles
                    If Not User.Roles.Contains(Role) Then
                        User.Roles.Add(Role)
                    End If
                Next
            Next
            Context.SaveChanges()
        End Using
    End Sub

    Public Overrides Sub RemoveUsersFromRoles(usernames() As String, roleNames() As String)
        Using Context As New DataContext
            For Each Username In usernames
                Dim Us = Username
                Dim User = Context.Users.FirstOrDefault(Function(U) U.Username = Us)
                If User IsNot Nothing Then
                    For Each RoleName In roleNames
                        Dim Rl = RoleName
                        Dim Role = User.Roles.FirstOrDefault(Function(R) R.RoleName = Rl)
                        If Role IsNot Nothing Then
                            User.Roles.Remove(Role)
                        End If
                    Next
                End If
            Next
            Context.SaveChanges()
        End Using
    End Sub

End Class