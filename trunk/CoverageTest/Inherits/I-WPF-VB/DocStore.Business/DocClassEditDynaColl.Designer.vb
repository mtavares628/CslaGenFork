'  This file was generated by CSLA Object Generator - CslaGenFork v4.5
'
' Filename:    DocClassEditDynaColl
' ObjectType:  DocClassEditDynaColl
' CSLAType:    DynamicEditableRootCollection

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Csla
Imports Csla.Data
Imports DocStore.Business.Util
Imports Csla.Rules
Imports Csla.Rules.CommonRules
Imports UsingLibrary

Namespace DocStore.Business

    ''' <summary>
    ''' DocClassEditDynaColl (dynamic root list).<br/>
    ''' This is a generated base class of <see cref="DocClassEditDynaColl"/> business object.
    ''' </summary>
    ''' <remarks>
    ''' The items of the collection are <see cref="DocClassEditDyna"/> objects.
    ''' </remarks>
    <Serializable()>
    Partial Public Class DocClassEditDynaColl
        Inherits MyDynamicListBase(Of DocClassEditDyna)
        Implements IHaveInterface, IHaveGenericInterface(Of DocClassEditDynaColl)
    
        #Region " Collection Business Methods "

        ''' <summary>
        ''' Adds a new <see cref="DocClassEditDyna"/> item to the collection.
        ''' </summary>
        ''' <param name="item">The item to add.</param>
        ''' <exception cref="System.Security.SecurityException">if the user isn't authorized to add items to the collection.</exception>
        ''' <exception cref="ArgumentException">if the item already exists in the collection.</exception>
        Public Overloads Sub Add(item As DocClassEditDyna)
            If Not CanAddObject() Then
                Throw New System.Security.SecurityException("User not authorized to create a DocClassEditDyna.")
            End If
            If Contains(item.DocClassID) Then
                Throw New ArgumentException("DocClassEditDyna already exists.")
            End If

            Add(item)
        End Sub

        ''' <summary>
        ''' Removes a <see cref="DocClassEditDyna"/> item from the collection.
        ''' </summary>
        ''' <param name="item">The item to remove.</param>
        ''' <returns><c>True</c> if the item was removed from the collection, otherwise <c>false</c>.</returns>
        ''' <exception cref="System.Security.SecurityException">if the user isn't authorized to remove items from the collection.</exception>
        Public Overloads Function Remove(item As DocClassEditDyna) As Boolean
            If Not CanDeleteObject() Then
                Throw New System.Security.SecurityException("User not authorized to remove a DocClassEditDyna.")
            End If
            Return MyBase.Remove(item)
        End Function

        ''' <summary>
        ''' Adds a new <see cref="DocClassEditDyna"/> item to the collection.
        ''' </summary>
        ''' <returns>The new DocClassEditDyna item added to the collection.</returns>
        Public Overloads Function Add() As DocClassEditDyna
            Dim item = DocClassEditDyna.NewDocClassEditDyna()
            Add(item)
            Return item
        End Function

        ''' <summary>
        ''' Asynchronously adds a new <see cref="DocClassEditDyna"/> item to the collection.
        ''' </summary>
        Public Sub BeginAdd()
            Dim docClassEditDyna As DocClassEditDyna = Nothing
            DocClassEditDyna.NewDocClassEditDyna(Sub(o, e)
                    If e.Error IsNot Nothing Then
                        Throw e.Error
                    Else
                        docClassEditDyna = e.Object
                    End If
                End Sub)
            Add(docClassEditDyna)
        End Sub

        ''' <summary>
        ''' Removes a <see cref="DocClassEditDyna"/> item from the collection.
        ''' </summary>
        ''' <param name="docClassID">The DocClassID of the item to be removed.</param>
        Public Overloads Sub Remove(docClassID As Integer)
            For Each item As DocClassEditDyna In Me
                If item.DocClassID = docClassID Then
                    MyBase.Remove(item)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Determines whether a <see cref="DocClassEditDyna"/> item is in the collection.
        ''' </summary>
        ''' <param name="docClassID">The DocClassID of the item to search for.</param>
        ''' <returns><c>True</c> if the DocClassEditDyna is a collection item; otherwise, <c>false</c>.</returns>
        Public Overloads Function Contains(docClassID As Integer) As Boolean
            For Each item As DocClassEditDyna In Me
                If item.DocClassID = docClassID Then
                    Return True
                End If
            Next
            Return False
        End Function

        #End Region

        #Region " Factory Methods "

        ''' <summary>
        ''' Factory method. Creates a new <see cref="DocClassEditDynaColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the created <see cref="DocClassEditDynaColl"/> collection.</returns>
        Public Shared Function NewDocClassEditDynaColl() As DocClassEditDynaColl
            Return DataPortal.Create(Of DocClassEditDynaColl)()
        End Function

        ''' <summary>
        ''' Factory method. Loads a <see cref="DocClassEditDynaColl"/> collection.
        ''' </summary>
        ''' <returns>A reference to the fetched <see cref="DocClassEditDynaColl"/> collection.</returns>
        Public Shared Function GetDocClassEditDynaColl() As DocClassEditDynaColl
            Return DataPortal.Fetch(Of DocClassEditDynaColl)()
        End Function

        ''' <summary>
        ''' Factory method. Asynchronously creates a new <see cref="DocClassEditDynaColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub NewDocClassEditDynaColl(callback As EventHandler(Of DataPortalResult(Of DocClassEditDynaColl)))
            DataPortal.BeginCreate(Of DocClassEditDynaColl)(callback)
        End Sub

        ''' <summary>
        ''' Factory method. Asynchronously loads a <see cref="DocClassEditDynaColl"/> collection.
        ''' </summary>
        ''' <param name="callback">The completion callback method.</param>
        Public Shared Sub GetDocClassEditDynaColl(ByVal callback As EventHandler(Of DataPortalResult(Of DocClassEditDynaColl)))
            DataPortal.BeginFetch(Of DocClassEditDynaColl)(callback)
        End Sub

        #End Region

        #Region " Constructor "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="DocClassEditDynaColl"/> class.
        ''' </summary>
        ''' <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            ' Use factory methods and do not use direct creation.

            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            AllowNew = DocClassEditDynaColl.CanAddObject()
            AllowEdit = DocClassEditDynaColl.CanEditObject()
            AllowRemove = DocClassEditDynaColl.CanDeleteObject()
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " Object Authorization "

        ''' <summary>
        ''' Adds the object authorization rules.
        ''' </summary>
        Protected Shared Sub AddObjectAuthorizationRules()
            BusinessRules.AddRule(GetType(DocClassEditDynaColl), New IsInRole(AuthorizationActions.CreateObject, "Admin"))
            BusinessRules.AddRule(GetType(DocClassEditDynaColl), New IsInRole(AuthorizationActions.GetObject, "User"))
            BusinessRules.AddRule(GetType(DocClassEditDynaColl), New IsInRole(AuthorizationActions.EditObject, "Admin"))
            BusinessRules.AddRule(GetType(DocClassEditDynaColl), New IsInRole(AuthorizationActions.DeleteObject, "Admin"))

            AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Allows the set up of custom object authorization rules.
        ''' </summary>
        Partial Private Shared Sub AddObjectAuthorizationRulesExtend()
        End Sub

        ''' <summary>
        ''' Checks if the current user can create a new DocClassEditDynaColl object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanAddObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, GetType(DocClassEditDynaColl))
        End Function

        ''' <summary>
        ''' Checks if the current user can retrieve DocClassEditDynaColl's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanGetObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, GetType(DocClassEditDynaColl))
        End Function

        ''' <summary>
        ''' Checks if the current user can change DocClassEditDynaColl's properties.
        ''' </summary>
        ''' <returns><c>True</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanEditObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, GetType(DocClassEditDynaColl))
        End Function

        ''' <summary>
        ''' Checks if the current user can delete a DocClassEditDynaColl object.
        ''' </summary>
        ''' <returns><c>True</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        Public Overloads Shared Function CanDeleteObject() As Boolean
            Return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, GetType(DocClassEditDynaColl))
        End Function

        #End Region

        #Region " Data Access "

        ''' <summary>
        ''' Loads a <see cref="DocClassEditDynaColl"/> collection from the database.
        ''' </summary>
        Protected Overloads Sub DataPortal_Fetch()
            Using ctx = ConnectionManager(Of SqlConnection).GetManager(Database.DocStoreConnection, False)
                Using cmd = New SqlCommand("GetDocClassEditDynaColl", ctx.Connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim args As New DataPortalHookArgs(cmd)
                    OnFetchPre(args)
                    LoadCollection(cmd)
                    OnFetchPost(args)
                End Using
            End Using
        End Sub

        Private Sub LoadCollection(cmd As SqlCommand)
            Using dr As New SafeDataReader(cmd.ExecuteReader())
                Fetch(dr)
            End Using
        End Sub

        ''' <summary>
        ''' Loads all <see cref="DocClassEditDynaColl"/> collection items from the given SafeDataReader.
        ''' </summary>
        ''' <param name="dr">The SafeDataReader to use.</param>
        Private Sub Fetch(dr As SafeDataReader)
            Dim rlce = RaiseListChangedEvents
            RaiseListChangedEvents = False
            While dr.Read()
                Add(DocClassEditDyna.GetDocClassEditDyna(dr))
            End While
            RaiseListChangedEvents = rlce
        End Sub

        #End Region

        #Region " DataPortal Hooks "

        ''' <summary>
        ''' Occurs after setting query parameters and before the fetch operation.
        ''' </summary>
        Partial Private Sub OnFetchPre(args As DataPortalHookArgs)
        End Sub

        ''' <summary>
        ''' Occurs after the fetch operation (object or collection is fully loaded and set up).
        ''' </summary>
        Partial Private Sub OnFetchPost(args As DataPortalHookArgs)
        End Sub

        #End Region

    End Class
End Namespace