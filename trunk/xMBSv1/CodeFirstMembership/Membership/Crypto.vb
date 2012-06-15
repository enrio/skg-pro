Imports System.Security.Cryptography
Imports System.Runtime.CompilerServices

Public NotInheritable Class Crypto

    Private Const TokenSizeInBytes As Integer = 16
    Private Const Pbkdf2Count As Integer = 1000
    Private Const Pbkdf2SubkeyLength As Integer = 256 / 8
    Private Const SaltSize As Integer = 128 / 8

    Friend Shared Function GenerateToken() As String
        Dim TokenBytes As Byte() = New Byte(TokenSizeInBytes - 1) {}
        Using Prng As New RNGCryptoServiceProvider()
            Prng.GetBytes(TokenBytes)
            Return Convert.ToBase64String(TokenBytes)
        End Using
    End Function

    Public Shared Function GenerateSalt(Optional ByteLength As Integer = SaltSize) As String
        Dim Buff As Byte() = New Byte(ByteLength - 1) {}
        Using Prng = New RNGCryptoServiceProvider()
            Prng.GetBytes(Buff)
        End Using
        Return Convert.ToBase64String(Buff)
    End Function

    Public Shared Function Hash(Input As String, Optional Algorithm As String = "sha256") As String
        If String.IsNullOrEmpty(Input) Then
            Throw New ArgumentNullException("Hash input null")
        End If
        Return Hash(Encoding.UTF8.GetBytes(Input), Algorithm)
    End Function

    Public Shared Function Hash(Input As Byte(), Optional Algorithm As String = "sha256") As String
        If Input Is Nothing Then
            Throw New ArgumentNullException("Hash input null")
        End If

        Using Alg As HashAlgorithm = HashAlgorithm.Create(Algorithm)
            If Alg IsNot Nothing Then
                Dim HashData As Byte() = Alg.ComputeHash(Input)
                Return BinaryToHex(HashData)
            Else
                Throw New InvalidOperationException(String.Format(String.Format("Not supported hash algorhitm {0}", Algorithm)))
            End If
        End Using
    End Function

    Public Shared Function SHA1(Input As String) As String
        Return Hash(Input, "sha1")
    End Function

    Public Shared Function SHA256(Input As String) As String
        Return Hash(Input, "sha256")
    End Function

    '=======================
    'HASHED PASSWORD FORMATS
    '=======================
    'Version 0:
    'PBKDF2 with HMAC-SHA1, 128-bit salt, 256-bit subkey, 1000 iterations.
    'See also: SDL crypto guidelines v5.1, Part III)
    'Format: { 0x00, salt, subkey }      

    Public Shared Function HashPassword(Password As String) As String
        If String.IsNullOrEmpty(Password) Then
            Throw New ArgumentNullException("Password input null")
        End If

        Dim Salt As Byte()
        Dim SubKey As Byte()
        Using DeriveBytes = New Rfc2898DeriveBytes(Password, SaltSize, Pbkdf2Count)
            Salt = DeriveBytes.Salt
            SubKey = DeriveBytes.GetBytes(Pbkdf2SubkeyLength)
        End Using

        Dim OutputBytes As Byte() = New Byte(1 + SaltSize + (Pbkdf2SubkeyLength - 1)) {}
        Buffer.BlockCopy(Salt, 0, OutputBytes, 1, SaltSize)
        Buffer.BlockCopy(SubKey, 0, OutputBytes, 1 + SaltSize, Pbkdf2SubkeyLength)
        Return Convert.ToBase64String(OutputBytes)
    End Function

    'HashedPassword must be of the format of HashWithPassword (Salt + Hash(Salt+Input)
    Public Shared Function VerifyHashedPassword(HashedPassword As String, Password As String) As Boolean
        If String.IsNullOrEmpty(HashedPassword) Then
            Throw New ArgumentNullException("HashedPassword is null")
        End If
        If String.IsNullOrEmpty(Password) Then
            Throw New ArgumentNullException("Password is null")
        End If

        Dim HashedPasswordBytes As Byte() = Convert.FromBase64String(HashedPassword)

        If HashedPasswordBytes.Length <> (1 + SaltSize + Pbkdf2SubkeyLength) OrElse HashedPasswordBytes(0) <> CByte(&H0) Then
            'Wrong length or version header.
            Return False
        End If

        Dim Salt As Byte() = New Byte(SaltSize - 1) {}
        Buffer.BlockCopy(HashedPasswordBytes, 1, Salt, 0, SaltSize)
        Dim StoredSubkey As Byte() = New Byte(Pbkdf2SubkeyLength - 1) {}
        Buffer.BlockCopy(HashedPasswordBytes, 1 + SaltSize, StoredSubkey, 0, Pbkdf2SubkeyLength)

        Dim GeneratedSubkey As Byte()
        Using DeriveBytes = New Rfc2898DeriveBytes(Password, Salt, Pbkdf2Count)
            GeneratedSubkey = DeriveBytes.GetBytes(Pbkdf2SubkeyLength)
        End Using
        Return ByteArraysEqual(StoredSubkey, GeneratedSubkey)
    End Function

    Friend Shared Function BinaryToHex(Data As Byte()) As String
        Dim Hex As Char() = New Char(Data.Length * 2 - 1) {}

        For Iter As Integer = 0 To Data.Length - 1
            Dim HexChar As Byte = CByte(Data(Iter) >> 4)
            Hex(Iter * 2) = ChrW(If(HexChar > 9, HexChar + &H37, HexChar + &H30))
            HexChar = CByte(Data(Iter) And &HF)
            Hex(Iter * 2 + 1) = ChrW(If(HexChar > 9, HexChar + &H37, HexChar + &H30))
        Next
        Return New String(Hex)
    End Function

    'Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized.
    <MethodImpl(MethodImplOptions.NoOptimization)>
    Private Shared Function ByteArraysEqual(A As Byte(), B As Byte()) As Boolean
        If Object.ReferenceEquals(A, B) Then
            Return True
        End If

        If A Is Nothing OrElse B Is Nothing OrElse A.Length <> B.Length Then
            Return False
        End If

        Dim AreSame As Boolean = True
        For i As Integer = 0 To A.Length - 1
            AreSame = AreSame And (A(i) = B(i))
        Next
        Return AreSame
    End Function

End Class