//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    Doc
// ObjectType:  Doc
// CSLAType:    EditableRoot

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using Csla.Rules;
using Csla.Rules.CommonRules;
using CslaGenFork.Rules.AuthorizationRules;
using CslaGenFork.Rules.DateRules;
using CslaGenFork.Rules.TransformationRules;
using DocStore.Business.Circulations;
using DocStore.Business.Security;
using System.Collections.Generic;

namespace DocStore.Business
{

    /// <summary>
    /// Doc (editable root object).<br/>
    /// This is a generated base class of <see cref="Doc"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains three child collections:<br/>
    /// - <see cref="Folders"/> of type <see cref="DocFolderColl"/> (M:M relation to <see cref="Folder"/>)<br/>
    /// - <see cref="Circulations"/> of type <see cref="DocCircColl"/> (1:M relation to <see cref="DocCirc"/>)<br/>
    /// - <see cref="Contents"/> of type <see cref="DocContentList"/> (1:M relation to <see cref="DocContentInfo"/>)
    /// </remarks>
    [Serializable]
    public partial class Doc : BusinessBase<Doc>
    {

        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> DocIDProperty = RegisterProperty<int>(p => p.DocID, "Doc ID");
        /// <summary>
        /// Gets or sets the Document ID.
        /// </summary>
        /// <value>The Doc ID.</value>
        public int DocID
        {
            get { return GetProperty(DocIDProperty); }
            private set { SetProperty(DocIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocClassID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> DocClassIDProperty = RegisterProperty<int>(p => p.DocClassID, "Doc Class ID");
        /// <summary>
        /// Gets or sets the Document Class ID.
        /// </summary>
        /// <value>The Doc Class ID.</value>
        public int DocClassID
        {
            get { return GetProperty(DocClassIDProperty); }
            set { SetProperty(DocClassIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocTypeID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> DocTypeIDProperty = RegisterProperty<int>(p => p.DocTypeID, "Doc Type ID");
        /// <summary>
        /// Gets or sets the Document Type ID.
        /// </summary>
        /// <value>The Doc Type ID.</value>
        public int DocTypeID
        {
            get { return GetProperty(DocTypeIDProperty); }
            set { SetProperty(DocTypeIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SenderID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SenderIDProperty = RegisterProperty<int>(p => p.SenderID, "Sender ID");
        /// <summary>
        /// Gets or sets the Entity ID of the document sender.
        /// </summary>
        /// <value>The Sender ID.</value>
        public int SenderID
        {
            get { return GetProperty(SenderIDProperty); }
            set { SetProperty(SenderIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RecipientID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> RecipientIDProperty = RegisterProperty<int>(p => p.RecipientID, "Recipient ID");
        /// <summary>
        /// Gets or sets the Entity ID of the document recipient.
        /// </summary>
        /// <value>The Recipient ID.</value>
        public int RecipientID
        {
            get { return GetProperty(RecipientIDProperty); }
            set { SetProperty(RecipientIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocRef"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocRefProperty = RegisterProperty<string>(p => p.DocRef, "Doc Ref");
        /// <summary>
        /// Gets or sets the Doc Ref.
        /// </summary>
        /// <value>The Doc Ref.</value>
        public string DocRef
        {
            get { return GetProperty(DocRefProperty); }
            set { SetProperty(DocRefProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> DocDateProperty = RegisterProperty<SmartDate>(p => p.DocDate, "Doc Date");
        /// <summary>
        /// Gets or sets the Doc Date.
        /// </summary>
        /// <value>The Doc Date.</value>
        [DateNotInFutureAttr("Please pay attention: {0} can't be in the future.")]
        public string DocDate
        {
            get { return GetPropertyConvert<SmartDate, string>(DocDateProperty); }
            set { SetPropertyConvert<SmartDate, string>(DocDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Subject"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubjectProperty = RegisterProperty<string>(p => p.Subject, "Subject");
        /// <summary>
        /// Gets or sets the Subject.
        /// </summary>
        /// <value>The Subject.</value>
        public string Subject
        {
            get { return GetProperty(SubjectProperty); }
            set { SetProperty(SubjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocStatusID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> DocStatusIDProperty = RegisterProperty<int>(p => p.DocStatusID, "Doc Status ID");
        /// <summary>
        /// Gets or sets the Doc Status ID.
        /// </summary>
        /// <value>The Doc Status ID.</value>
        public int DocStatusID
        {
            get { return GetProperty(DocStatusIDProperty); }
            set { SetProperty(DocStatusIDProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Secret"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SecretProperty = RegisterProperty<string>(p => p.Secret, "Secret");
        /// <summary>
        /// Gets or sets the Secret.
        /// </summary>
        /// <value>The Secret.</value>
        public string Secret
        {
            get { return GetProperty(SecretProperty); }
            set { SetProperty(SecretProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<DateTime> CreateDateProperty = RegisterProperty<DateTime>(p => p.CreateDate, "Create Date");
        /// <summary>
        /// Gets or sets the Create Date.
        /// </summary>
        /// <value>The Create Date.</value>
        public DateTime CreateDate
        {
            get { return GetProperty(CreateDateProperty); }
            private set { SetProperty(CreateDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CreateUserIDProperty = RegisterProperty<int>(p => p.CreateUserID, "Create User ID");
        /// <summary>
        /// Gets or sets the Create User ID.
        /// </summary>
        /// <value>The Create User ID.</value>
        public int CreateUserID
        {
            get { return GetProperty(CreateUserIDProperty); }
            private set
            {
                SetProperty(CreateUserIDProperty, value);
                OnPropertyChanged("CreateUserName");
            }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<DateTime> ChangeDateProperty = RegisterProperty<DateTime>(p => p.ChangeDate, "Change Date");
        /// <summary>
        /// Gets or sets the Change Date.
        /// </summary>
        /// <value>The Change Date.</value>
        public DateTime ChangeDate
        {
            get { return GetProperty(ChangeDateProperty); }
            private set { SetProperty(ChangeDateProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ChangeUserIDProperty = RegisterProperty<int>(p => p.ChangeUserID, "Change User ID");
        /// <summary>
        /// Gets or sets the Change User ID.
        /// </summary>
        /// <value>The Change User ID.</value>
        public int ChangeUserID
        {
            get { return GetProperty(ChangeUserIDProperty); }
            private set
            {
                SetProperty(ChangeUserIDProperty, value);
                OnPropertyChanged("ChangeUserName");
            }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RowVersion"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<byte[]> RowVersionProperty = RegisterProperty<byte[]>(p => p.RowVersion, "Row Version");
        /// <summary>
        /// Gets the Row Version.
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion
        {
            get { return GetProperty(RowVersionProperty); }
        }

        /// <summary>
        /// Gets the Create User Name.
        /// </summary>
        /// <value>The Create User Name.</value>
        public string CreateUserName
        {
            get
            {
                var result = string.Empty;
                if (Admin.UserNVL.GetUserNVL().ContainsKey(CreateUserID))
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(CreateUserID).Value;
                return result;
            }
        }

        /// <summary>
        /// Gets the Change User Name.
        /// </summary>
        /// <value>The Change User Name.</value>
        public string ChangeUserName
        {
            get
            {
                var result = string.Empty;
                if (Admin.UserNVL.GetUserNVL().ContainsKey(ChangeUserID))
                    result = Admin.UserNVL.GetUserNVL().GetItemByKey(ChangeUserID).Value;
                return result;
            }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="ViewContent"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocContentRO> ViewContentProperty = RegisterProperty<DocContentRO>(p => p.ViewContent, "View Content", RelationshipTypes.Child);
        /// <summary>
        /// Gets the View Content ("parent load" child property).
        /// </summary>
        /// <value>The View Content.</value>
        public DocContentRO ViewContent
        {
            get { return GetProperty(ViewContentProperty); }
            private set { LoadProperty(ViewContentProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="EditContent"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocContent> EditContentProperty = RegisterProperty<DocContent>(p => p.EditContent, "Edit Content", RelationshipTypes.Child);
        /// <summary>
        /// Gets the Edit Content ("parent load" child property).
        /// </summary>
        /// <value>The Edit Content.</value>
        public DocContent EditContent
        {
            get { return GetProperty(EditContentProperty); }
            set { SetProperty(EditContentProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="Folders"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocFolderColl> FoldersProperty = RegisterProperty<DocFolderColl>(p => p.Folders, "Folders", RelationshipTypes.Child);
        /// <summary>
        /// Gets the Folders ("parent load" child property).
        /// </summary>
        /// <value>The Folders.</value>
        public DocFolderColl Folders
        {
            get { return GetProperty(FoldersProperty); }
            private set { LoadProperty(FoldersProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="Circulations"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocCircColl> CirculationsProperty = RegisterProperty<DocCircColl>(p => p.Circulations, "Circulations", RelationshipTypes.Child);
        /// <summary>
        /// Gets the Circulations ("parent load" child property).
        /// </summary>
        /// <value>The Circulations.</value>
        public DocCircColl Circulations
        {
            get { return GetProperty(CirculationsProperty); }
            private set { LoadProperty(CirculationsProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="Contents"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocContentList> ContentsProperty = RegisterProperty<DocContentList>(p => p.Contents, "Contents", RelationshipTypes.Child);
        /// <summary>
        /// Gets the Contents ("parent load" child property).
        /// </summary>
        /// <value>The Contents.</value>
        public DocContentList Contents
        {
            get { return GetProperty(ContentsProperty); }
            private set { LoadProperty(ContentsProperty, value); }
        }

        #endregion

        #region BusinessBase<T> overrides

        /// <summary>
        /// Returns a string that represents the current <see cref="Doc"/>
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            // Return the Primary Key as a string
            return DocID.ToString() + ", " + DocRef.ToString();
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="Doc"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="Doc"/> object.</returns>
        public static Doc NewDoc()
        {
            return DataPortal.Create<Doc>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="Doc"/> object, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the Doc to fetch.</param>
        /// <returns>A reference to the fetched <see cref="Doc"/> object.</returns>
        public static Doc GetDoc(int docID)
        {
            return DataPortal.Fetch<Doc>(docID);
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="Doc"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewDoc(EventHandler<DataPortalResult<Doc>> callback)
        {
            DocEditGetter.NewDocEditGetter((o, e) =>
            {
                callback(o, new DataPortalResult<Doc>(e.Object.Doc, e.Error, null));
            });
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="Doc"/> object, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the Doc to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetDoc(int docID, EventHandler<DataPortalResult<Doc>> callback)
        {
            DocEditGetter.GetDocEditGetter(docID, (o, e) =>
            {
                callback(o, new DataPortalResult<Doc>(e.Object.Doc, e.Error, null));
            });
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Doc"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Doc()
        {
            // Use factory methods and do not use direct creation.
            Saved += OnDocSaved;
        }

        #endregion

        #region Object Authorization

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            BusinessRules.AddRule(typeof (Doc), new IsInRole(AuthorizationActions.CreateObject, "Author"));
            BusinessRules.AddRule(typeof (Doc), new IsInRole(AuthorizationActions.GetObject, "User"));
            BusinessRules.AddRule(typeof (Doc), new IsInRole(AuthorizationActions.EditObject, "Author"));

            AddObjectAuthorizationRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom object authorization rules.
        /// </summary>
        static partial void AddObjectAuthorizationRulesExtend();

        /// <summary>
        /// Checks if the current user can create a new Doc object.
        /// </summary>
        /// <returns><c>true</c> if the user can create a new object; otherwise, <c>false</c>.</returns>
        public static bool CanAddObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.CreateObject, typeof(Doc));
        }

        /// <summary>
        /// Checks if the current user can retrieve Doc's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can read the object; otherwise, <c>false</c>.</returns>
        public static bool CanGetObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.GetObject, typeof(Doc));
        }

        /// <summary>
        /// Checks if the current user can change Doc's properties.
        /// </summary>
        /// <returns><c>true</c> if the user can update the object; otherwise, <c>false</c>.</returns>
        public static bool CanEditObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.EditObject, typeof(Doc));
        }

        /// <summary>
        /// Checks if the current user can delete a Doc object.
        /// </summary>
        /// <returns><c>true</c> if the user can delete the object; otherwise, <c>false</c>.</returns>
        public static bool CanDeleteObject()
        {
            return BusinessRules.HasPermission(Csla.Rules.AuthorizationActions.DeleteObject, typeof(Doc));
        }

        #endregion

        #region Business Rules and Property Authorization

        /// <summary>
        /// Override this method in your business class to be notified when you need to set up shared business rules.
        /// </summary>
        /// <remarks>
        /// This method is automatically called by CSLA.NET when your object should associate
        /// per-type validation rules with its properties.
        /// </remarks>
        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();

            // Property Business Rules

            // DocClassID
            BusinessRules.AddRule(new Required(DocClassIDProperty));
            // DocTypeID
            BusinessRules.AddRule(new Required(DocTypeIDProperty));
            // SenderID
            BusinessRules.AddRule(new Required(SenderIDProperty));
            // RecipientID
            BusinessRules.AddRule(new Required(RecipientIDProperty));
            // DocRef
            BusinessRules.AddRule(new CollapseWhiteSpace(DocRefProperty) { Priority = -1 });
            BusinessRules.AddRule(new MaxLength(DocRefProperty, 35));
            // DocDate
            BusinessRules.AddRule(new Required(DocDateProperty));
            // Subject
            BusinessRules.AddRule(new CollapseWhiteSpace(SubjectProperty) { Priority = -1 });
            BusinessRules.AddRule(new Required(SubjectProperty));
            BusinessRules.AddRule(new MaxLength(SubjectProperty, 255));
            // DocStatusID
            BusinessRules.AddRule(new Required(DocStatusIDProperty));

            // Authorization Rules

            // DocClassID
            BusinessRules.AddRule(new RestrictByStatusOrIsInRole(AuthorizationActions.WriteProperty, DocClassIDProperty, "DocStatusID", new List<int> {4}, "Admin"));
            // DocTypeID
            BusinessRules.AddRule(new IsNewOrIsInRole(AuthorizationActions.WriteProperty, DocTypeIDProperty, "Admin"));
            // SenderID
            BusinessRules.AddRule(new IsNewOrIsInRole(AuthorizationActions.WriteProperty, SenderIDProperty, "Admin"));
            // RecipientID
            BusinessRules.AddRule(new IsNewOrIsInRole(AuthorizationActions.WriteProperty, RecipientIDProperty, "Admin"));
            // DocRef
            BusinessRules.AddRule(new IsEmptyOrIsInRole(AuthorizationActions.WriteProperty, DocRefProperty, "Admin"));
            // DocDate
            BusinessRules.AddRule(new IsNewOrIsInRole(AuthorizationActions.WriteProperty, DocDateProperty, "Admin"));
            // Subject
            BusinessRules.AddRule(new RestrictByStatusOrIsInRole(AuthorizationActions.WriteProperty, SubjectProperty, "DocStatusID", new List<int> {3, 4}, "Admin"));
            // DocStatusID
            BusinessRules.AddRule(new RestrictByStatusOrIsInRole(AuthorizationActions.WriteProperty, DocStatusIDProperty, "DocStatusID", new List<int> {4}, "Admin"));
            // Secret
            BusinessRules.AddRule(new IsOwnerOrIsInRole(AuthorizationActions.ReadProperty, SecretProperty, "CreateUserID", () => UserInformation.UserId, "Admin", "Manager"));
            BusinessRules.AddRule(new IsOwner(AuthorizationActions.WriteProperty, SecretProperty, "CreateUserID", () => UserInformation.UserId));

            AddBusinessRulesExtend();
        }

        /// <summary>
        /// Allows the set up of custom shared business rules.
        /// </summary>
        partial void AddBusinessRulesExtend();

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="Doc"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(DocIDProperty, System.Threading.Interlocked.Decrement(ref _lastId));
            LoadProperty(DocClassIDProperty, -1);
            LoadProperty(DocTypeIDProperty, -1);
            LoadProperty(SenderIDProperty, -1);
            LoadProperty(DocDateProperty, new SmartDate(DateTime.Today));
            LoadProperty(DocStatusIDProperty, -1);
            LoadProperty(CreateDateProperty, DateTime.Now);
            LoadProperty(CreateUserIDProperty, UserInformation.UserId);
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty));
            LoadProperty(EditContentProperty, DataPortal.CreateChild<DocContent>());
            LoadProperty(FoldersProperty, DataPortal.CreateChild<DocFolderColl>());
            LoadProperty(CirculationsProperty, DataPortal.CreateChild<DocCircColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="Doc"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="docID">The Doc ID.</param>
        protected void DataPortal_Fetch(int docID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetDoc", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", docID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, docID);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                    FetchChildren(dr);
                }
            }
        }

        /// <summary>
        /// Loads a <see cref="Doc"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DocIDProperty, dr.GetInt32("DocID"));
            LoadProperty(DocClassIDProperty, dr.GetInt32("DocClassID"));
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"));
            LoadProperty(SenderIDProperty, dr.GetInt32("SenderID"));
            LoadProperty(RecipientIDProperty, dr.GetInt32("RecipientID"));
            LoadProperty(DocRefProperty, dr.GetString("DocRef"));
            LoadProperty(DocDateProperty, dr.GetSmartDate("DocDate", true));
            LoadProperty(SubjectProperty, dr.GetString("Subject"));
            LoadProperty(DocStatusIDProperty, dr.GetInt32("DocStatusID"));
            LoadProperty(SecretProperty, dr.GetString("Secret"));
            LoadProperty(CreateDateProperty, dr.GetDateTime("CreateDate"));
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"));
            LoadProperty(ChangeDateProperty, dr.GetDateTime("ChangeDate"));
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"));
            LoadProperty(RowVersionProperty, dr.GetValue("RowVersion") as byte[]);
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            if (dr.Read())
                LoadProperty(ViewContentProperty, DocContentRO.GetDocContentRO(dr));
            dr.NextResult();
            if (dr.Read())
                LoadProperty(EditContentProperty, DocContent.GetDocContent(dr));
            dr.NextResult();
            LoadProperty(FoldersProperty, DocFolderColl.GetDocFolderColl(dr));
            dr.NextResult();
            LoadProperty(CirculationsProperty, DocCircColl.GetDocCircColl(dr));
            dr.NextResult();
            LoadProperty(ContentsProperty, DocContentList.GetDocContentList(dr));
        }

        /// <summary>
        /// Inserts a new <see cref="Doc"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("AddDoc", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@DocClassID", ReadProperty(DocClassIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SenderID", ReadProperty(SenderIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RecipientID", ReadProperty(RecipientIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocRef", ReadProperty(DocRefProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocDate", ReadProperty(DocDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocStatusID", ReadProperty(DocStatusIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Secret", ReadProperty(SecretProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty)).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty)).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(DocIDProperty, (int) cmd.Parameters["@DocID"].Value);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="Doc"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateDoc", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocID", ReadProperty(DocIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocClassID", ReadProperty(DocClassIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@SenderID", ReadProperty(SenderIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RecipientID", ReadProperty(RecipientIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocRef", ReadProperty(DocRefProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocDate", ReadProperty(DocDateProperty).DBValue).DbType = DbType.Date;
                    cmd.Parameters.AddWithValue("@Subject", ReadProperty(SubjectProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@DocStatusID", ReadProperty(DocStatusIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Secret", ReadProperty(SecretProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty)).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                ctx.Commit();
            }
        }

        private void SimpleAuditTrail()
        {
            LoadProperty(ChangeDateProperty, DateTime.Now);
            LoadProperty(ChangeUserIDProperty, UserInformation.UserId);
            OnPropertyChanged("ChangeUserName");
            if (IsNew)
            {
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty));
                LoadProperty(CreateUserIDProperty, ReadProperty(ChangeUserIDProperty));
                OnPropertyChanged("CreateUserName");
            }
        }

        #endregion

        #region Saved Event

        private void OnDocSaved(object sender, Csla.Core.SavedEventArgs e)
        {
            if (DocSaved != null)
                DocSaved(sender, e);
        }

        /// <summary> Use this event to signal a <see cref="Doc"/> object was saved.</summary>
        public static event EventHandler<Csla.Core.SavedEventArgs> DocSaved;

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after setting query parameters and before the update operation.
        /// </summary>
        partial void OnUpdatePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the update operation, before setting back row identifiers (RowVersion) and Commit().
        /// </summary>
        partial void OnUpdatePost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after setting query parameters and before the insert operation.
        /// </summary>
        partial void OnInsertPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Insert, after the insert operation, before setting back row identifiers (ID and RowVersion) and Commit().
        /// </summary>
        partial void OnInsertPost(DataPortalHookArgs args);

        #endregion

    }
}
