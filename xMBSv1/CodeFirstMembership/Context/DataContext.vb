Imports System.Data.Entity

Public Class DataContext
    Inherits DbContext

    'Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
    '    modelBuilder.Conventions.Remove(Of Infrastructure.IncludeMetadataConvention)()
    'End Sub

    Public Property Users As DbSet(Of User)
    Public Property Roles As DbSet(Of Role)

End Class