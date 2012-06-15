Public Class CodeFirstMembershipProvider
    Inherits MembershipProvider

#Region "Properties"

    Public Overrides Property ApplicationName As String = My.Application.Info.AssemblyName

    Public Overrides ReadOnly Property MaxInvalidPasswordAttempts As Integer
        Get
            Return 5
        End Get
    End Property

    Public Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property MinRequiredPasswordLength As Integer
        Get
            Return 6
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordAttemptWindow As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordFormat As System.Web.Security.MembershipPasswordFormat
        Get
            Return MembershipPasswordFormat.Hashed
        End Get
    End Property

    Public Overrides ReadOnly Property PasswordStrengthRegularExpression As String
        Get
            Return String.Empty
        End Get
    End Property

    Public Overrides ReadOnly Property RequiresUniqueEmail As Boolean
        Get
            Return True
        End Get
    End Property

#End Region

#Region "Functions"

    Public Overrides Function CreateUser(username As String, password As String, email As String, passwordQuestion As String, passwordAnswer As String, isApproved As Boolean, providerUserKey As Object, ByRef status As System.Web.Security.MembershipCreateStatus) As System.Web.Security.MembershipUser
        If String.IsNullOrEmpty(username) Then
            status = MembershipCreateStatus.InvalidUserName
            Return Nothing
        End If
        If String.IsNullOrEmpty(password) Then
            status = MembershipCreateStatus.InvalidPassword
            Return Nothing
        End If
        If String.IsNullOrEmpty(email) Then
            status = MembershipCreateStatus.InvalidEmail
            Return Nothing
        End If

        Dim HashedPassword As String = Crypto.HashPassword(password)
        If HashedPassword.Length > 128 Then
            status = MembershipCreateStatus.InvalidPassword
            Return Nothing
        End If

        Using Context As New DataContext
            If Context.Users.Where(Function(Usr) Usr.Username = username).Any Then
                status = MembershipCreateStatus.DuplicateUserName
                Return Nothing
            End If

            If Context.Users.Where(Function(Usr) Usr.Email = email).Any Then
                status = MembershipCreateStatus.DuplicateEmail
                Return Nothing
            End If

            Dim NewUser As New User With {.UserId = Guid.NewGuid,
                                          .Username = username,
                                          .Password = HashedPassword,
                                          .IsApproved = isApproved,
                                          .Email = email,
                                          .CreateDate = DateTime.UtcNow,
                                          .LastPasswordChangedDate = DateTime.UtcNow,
                                          .PasswordFailuresSinceLastSuccess = 0,
                                          .LastLoginDate = DateTime.UtcNow,
                                          .LastActivityDate = DateTime.UtcNow,
                                          .LastLockoutDate = DateTime.UtcNow,
                                          .IsLockedOut = False,
                                          .LastPasswordFailureDate = DateTime.UtcNow}

            Context.Users.Add(NewUser)
            Context.SaveChanges()
            Return New MembershipUser(Membership.Provider.Name, NewUser.Username, NewUser.UserId, NewUser.Email, Nothing, Nothing, NewUser.IsApproved, NewUser.IsLockedOut, NewUser.CreateDate, NewUser.LastLoginDate, NewUser.LastActivityDate, NewUser.LastPasswordChangedDate, NewUser.LastLockoutDate)
        End Using
    End Function

    Public Overrides Function ValidateUser(username As String, password As String) As Boolean
        If String.IsNullOrEmpty(username) Then
            Return False
        End If
        If String.IsNullOrEmpty(password) Then
            Return False
        End If
        Using Context As New DataContext
            Dim User As User = Nothing
            User = Context.Users.FirstOrDefault(Function(Usr) Usr.Username = username)
            If User Is Nothing Then
                Return False
            End If
            If Not User.IsApproved Then
                Return False
            End If
            If User.IsLockedOut Then
                Return False
            End If
            Dim HashedPassword = User.Password
            Dim VerificationSucceeded As Boolean = (HashedPassword IsNot Nothing AndAlso Crypto.VerifyHashedPassword(HashedPassword, password))
            If VerificationSucceeded Then
                User.PasswordFailuresSinceLastSuccess = 0
                User.LastLoginDate = DateTime.UtcNow
                User.LastActivityDate = DateTime.UtcNow
            Else
                Dim Failures As Integer = User.PasswordFailuresSinceLastSuccess
                If Failures < MaxInvalidPasswordAttempts Then
                    User.PasswordFailuresSinceLastSuccess += 1
                    User.LastPasswordFailureDate = DateTime.UtcNow
                ElseIf Failures >= MaxInvalidPasswordAttempts Then
                    User.LastPasswordFailureDate = DateTime.UtcNow
                    User.LastLockoutDate = DateTime.UtcNow
                    User.IsLockedOut = True
                End If
            End If
            Context.SaveChanges()
            If VerificationSucceeded Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Public Overloads Overrides Function GetUser(username As String, userIsOnline As Boolean) As System.Web.Security.MembershipUser
        If String.IsNullOrEmpty(username) Then
            Return Nothing
        End If
        Using Context As New DataContext
            Dim User As User = Nothing
            User = Context.Users.FirstOrDefault(Function(Usr) Usr.Username = username)
            If User IsNot Nothing Then
                If userIsOnline Then
                    User.LastActivityDate = DateTime.UtcNow
                    Context.SaveChanges()
                End If
                Return New MembershipUser(Membership.Provider.Name, User.Username, User.UserId, User.Email, Nothing, Nothing, User.IsApproved, User.IsLockedOut, User.CreateDate, User.LastLoginDate, User.LastActivityDate, User.LastPasswordChangedDate, User.LastLockoutDate)
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Overloads Overrides Function GetUser(providerUserKey As Object, userIsOnline As Boolean) As System.Web.Security.MembershipUser
        If Not TypeOf providerUserKey Is Guid Then
            Return Nothing
        End If
        Using Context As New DataContext
            Dim User As User = Nothing
            User = Context.Users.Find(providerUserKey)
            If User IsNot Nothing Then
                If userIsOnline Then
                    User.LastActivityDate = DateTime.UtcNow
                    Context.SaveChanges()
                End If
                Return New MembershipUser(Membership.Provider.Name, User.Username, User.UserId, User.Email, Nothing, Nothing, User.IsApproved, User.IsLockedOut, User.CreateDate, User.LastLoginDate, User.LastActivityDate, User.LastPasswordChangedDate, User.LastLockoutDate)
            Else
                Return Nothing
            End If
        End Using
    End Function

    Public Overrides Function ChangePassword(username As String, oldPassword As String, newPassword As String) As Boolean
        If String.IsNullOrEmpty(username) Then
            Return False
        End If
        If String.IsNullOrEmpty(oldPassword) Then
            Return False
        End If
        If String.IsNullOrEmpty(newPassword) Then
            Return False
        End If
        Using Context As New DataContext
            Dim User As User = Nothing
            User = Context.Users.FirstOrDefault(Function(Usr) Usr.Username = username)
            If User Is Nothing Then
                Return False
            End If
            Dim HashedPassword = User.Password
            Dim VerificationSucceeded As Boolean = (HashedPassword IsNot Nothing AndAlso Crypto.VerifyHashedPassword(HashedPassword, oldPassword))
            If VerificationSucceeded Then
                User.PasswordFailuresSinceLastSuccess = 0
            Else
                Dim Failures As Integer = User.PasswordFailuresSinceLastSuccess
                If Failures < MaxInvalidPasswordAttempts Then
                    User.PasswordFailuresSinceLastSuccess += 1
                    User.LastPasswordFailureDate = DateTime.UtcNow
                ElseIf Failures >= MaxInvalidPasswordAttempts Then
                    User.LastPasswordFailureDate = DateTime.UtcNow
                    User.LastLockoutDate = DateTime.UtcNow
                    User.IsLockedOut = True
                End If
                Context.SaveChanges()
                Return False
            End If
            Dim NewHashedPassword = Crypto.HashPassword(newPassword)
            If NewHashedPassword.Length > 128 Then
                Return False
            End If
            User.Password = NewHashedPassword
            User.LastPasswordChangedDate = DateTime.UtcNow
            Context.SaveChanges()
            Return True
        End Using
    End Function

    Public Overrides Function UnlockUser(userName As String) As Boolean
        Using Context As New DataContext
            Dim User As User = Nothing
            User = Context.Users.FirstOrDefault(Function(Usr) Usr.Username = userName)
            If User IsNot Nothing Then
                User.IsLockedOut = False
                User.PasswordFailuresSinceLastSuccess = 0
                Context.SaveChanges()
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Public Overrides Function GetNumberOfUsersOnline() As Integer
        Dim DateActive As DateTime = DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(CDbl(Membership.UserIsOnlineTimeWindow)))
        Using Context As New DataContext
            Return Context.Users.Where(Function(Usr) Usr.LastActivityDate > DateActive).Count
        End Using
    End Function

    Public Overrides Function DeleteUser(username As String, deleteAllRelatedData As Boolean) As Boolean
        If String.IsNullOrEmpty(username) Then
            Return False
        End If
        Using Context As New DataContext
            Dim User As User = Nothing
            User = Context.Users.FirstOrDefault(Function(Usr) Usr.Username = username)
            If User IsNot Nothing Then
                Context.Users.Remove(User)
                Context.SaveChanges()
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Public Overrides Function GetUserNameByEmail(email As String) As String
        Using Context As New DataContext
            Dim User As User = Nothing
            User = Context.Users.FirstOrDefault(Function(Usr) Usr.Email = email)
            If User IsNot Nothing Then
                Return User.Username
            Else
                Return String.Empty
            End If
        End Using
    End Function

    Public Overrides Function FindUsersByEmail(emailToMatch As String, pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection
        Dim MembershipUsers As New MembershipUserCollection
        Using Context As New DataContext
            totalRecords = Context.Users.Where(Function(Usr) Usr.Email = emailToMatch).Count
            Dim Users = Context.Users.Where(Function(Usr) Usr.Email = emailToMatch).OrderBy(Function(Usrn) Usrn.Username).Skip(pageIndex * pageSize).Take(pageSize)
            For Each User In Users
                MembershipUsers.Add(New MembershipUser(Membership.Provider.Name, User.Username, User.UserId, User.Email, Nothing, Nothing, User.IsApproved, User.IsLockedOut, User.CreateDate, User.LastLoginDate, User.LastActivityDate, User.LastPasswordChangedDate, User.LastLockoutDate))
            Next
        End Using
        Return MembershipUsers
    End Function

    Public Overrides Function FindUsersByName(usernameToMatch As String, pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection
        Dim MembershipUsers As New MembershipUserCollection
        Using Context As New DataContext
            totalRecords = Context.Users.Where(Function(Usr) Usr.Username = usernameToMatch).Count
            Dim Users = Context.Users.Where(Function(Usr) Usr.Username = usernameToMatch).OrderBy(Function(Usrn) Usrn.Username).Skip(pageIndex * pageSize).Take(pageSize)
            For Each User In Users
                MembershipUsers.Add(New MembershipUser(Membership.Provider.Name, User.Username, User.UserId, User.Email, Nothing, Nothing, User.IsApproved, User.IsLockedOut, User.CreateDate, User.LastLoginDate, User.LastActivityDate, User.LastPasswordChangedDate, User.LastLockoutDate))
            Next
        End Using
        Return MembershipUsers
    End Function

    Public Overrides Function GetAllUsers(pageIndex As Integer, pageSize As Integer, ByRef totalRecords As Integer) As System.Web.Security.MembershipUserCollection
        Dim MembershipUsers As New MembershipUserCollection
        Using Context As New DataContext
            totalRecords = Context.Users.Count
            Dim Users = Context.Users.OrderBy(Function(Usrn) Usrn.Username).Skip(pageIndex * pageSize).Take(pageSize)
            For Each User In Users
                MembershipUsers.Add(New MembershipUser(Membership.Provider.Name, User.Username, User.UserId, User.Email, Nothing, Nothing, User.IsApproved, User.IsLockedOut, User.CreateDate, User.LastLoginDate, User.LastActivityDate, User.LastPasswordChangedDate, User.LastLockoutDate))
            Next
        End Using
        Return MembershipUsers
    End Function

#End Region

#Region "Not Supported"

    'CodeFirstMembershipProvider does not support password retrieval scenarios.
    Public Overrides ReadOnly Property EnablePasswordRetrieval As Boolean
        Get
            Return False
        End Get
    End Property
    Public Overrides Function GetPassword(username As String, answer As String) As String
        Throw New NotSupportedException("Consider using methods from WebSecurity module.")
    End Function

    'CodeFirstMembershipProvider does not support password reset scenarios.
    Public Overrides ReadOnly Property EnablePasswordReset As Boolean
        Get
            Return False
        End Get
    End Property
    Public Overrides Function ResetPassword(username As String, answer As String) As String
        Throw New NotSupportedException("Consider using methods from WebSecurity module.")
    End Function
   
    'CodeFirstMembershipProvider does not support question and answer scenarios.
    Public Overrides ReadOnly Property RequiresQuestionAndAnswer As Boolean
        Get
            Return False
        End Get
    End Property
    Public Overrides Function ChangePasswordQuestionAndAnswer(username As String, password As String, newPasswordQuestion As String, newPasswordAnswer As String) As Boolean
        Throw New NotSupportedException("Consider using methods from WebSecurity module.")
    End Function

    'CodeFirstMembershipProvider does not support UpdateUser because this method is useless.
    Public Overrides Sub UpdateUser(user As System.Web.Security.MembershipUser)
        Throw New NotSupportedException()
    End Sub

#End Region

End Class