Public Module WebSecurity

    Public ReadOnly Property Context() As HttpContextBase
        Get
            Return New HttpContextWrapper(HttpContext.Current)
        End Get
    End Property

    Public ReadOnly Property Request() As HttpRequestBase
        Get
            Return Context.Request
        End Get
    End Property

    Public ReadOnly Property Response() As HttpResponseBase
        Get
            Return Context.Response
        End Get
    End Property

    Public ReadOnly Property User() As System.Security.Principal.IPrincipal
        Get
            Return Context.User
        End Get
    End Property

    Public ReadOnly Property IsAuthenticated() As Boolean
        Get
            Return User.Identity.IsAuthenticated
        End Get
    End Property

    Public Function Register(Username As String, Password As String, Email As String, IsApproved As Boolean, FirstName As String, LastName As String) As System.Web.Security.MembershipCreateStatus
        Dim CreateStatus As MembershipCreateStatus
        Membership.CreateUser(Username, Password, Email, Nothing, Nothing, IsApproved, Nothing, CreateStatus)

        If CreateStatus = MembershipCreateStatus.Success Then
            Using Context As New DataContext
                Dim User = Context.Users.FirstOrDefault(Function(Usr) Usr.Username = Username)
                User.FirstName = FirstName
                User.LastName = LastName
                Context.SaveChanges()
            End Using

            If IsApproved Then
                FormsAuthentication.SetAuthCookie(Username, False)
            End If
        End If

        Return CreateStatus
    End Function

    Public Enum MembershipLoginStatus
        Success
        Failure
    End Enum

    Public Function Login(Username As String, Password As String, RememberMe As Boolean) As MembershipLoginStatus
        If Membership.ValidateUser(Username, Password) Then
            FormsAuthentication.SetAuthCookie(Username, RememberMe)
            Return MembershipLoginStatus.Success
        Else
            Return MembershipLoginStatus.Failure
        End If
    End Function

    Public Sub Logout()
        FormsAuthentication.SignOut()
    End Sub

    Public Function GetUser(Username As String) As MembershipUser
        Return Membership.GetUser(Username)
    End Function

    Public Function ChangePassword(OldPassword As String, NewPassword As String) As Boolean
        Dim CurrentUser = Membership.GetUser(User.Identity.Name)
        Return CurrentUser.ChangePassword(OldPassword, NewPassword)
    End Function

    Public Function DeleteUser(Username As String) As Boolean
        Return Membership.DeleteUser(Username)
    End Function

    Public Function FindUsersByEmail(Email As String, PageIndex As Integer, PageSize As Integer) As List(Of MembershipUser)
        Return Membership.FindUsersByEmail(Email, PageIndex, PageSize, Nothing).Cast(Of MembershipUser)().ToList
    End Function

    Public Function FindUsersByName(Username As String, PageIndex As Integer, PageSize As Integer) As List(Of MembershipUser)
        Return Membership.FindUsersByName(Username, PageIndex, PageSize, Nothing).Cast(Of MembershipUser)().ToList
    End Function

    Public Function GetAllUsers(PageIndex As Integer, PageSize As Integer) As List(Of MembershipUser)
        Return Membership.GetAllUsers(PageIndex, PageSize, Nothing).Cast(Of MembershipUser)().ToList
    End Function

End Module