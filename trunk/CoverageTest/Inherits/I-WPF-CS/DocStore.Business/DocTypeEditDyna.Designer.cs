//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocTypeEditDyna
// ObjectType:  DocTypeEditDyna
// CSLAType:    DynamicEditableRoot

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using DocStore.Business.Security;
using UsingLibrary;

namespace DocStore.Business
{

    /// <summary>
    /// Types of document (dynamic root object).<br/>
    /// This is a generated base class of <see cref="DocTypeEditDyna"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="DocTypeEditDynaColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class DocTypeEditDyna : MyBusinessBase<DocTypeEditDyna>
    {

        #region Static Fields

        private static int _lastId;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="DocTypeID"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<int> DocTypeIDProperty = RegisterProperty<int>(p => p.DocTypeID, "Doc Type ID");
        /// <summary>
        /// Gets the Doc Type ID.
        /// </summary>
        /// <value>The Doc Type ID.</value>
        public int DocTypeID
        {
            get { return GetProperty(DocTypeIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocTypeName"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> DocTypeNameProperty = RegisterProperty<string>(p => p.DocTypeName, "Doc Type Name");
        /// <summary>
        /// Gets or sets the Doc Type Name.
        /// </summary>
        /// <value>The Doc Type Name.</value>
        public string DocTypeName
        {
            get { return GetProperty(DocTypeNameProperty); }
            set { SetProperty(DocTypeNameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> CreateDateProperty = RegisterProperty<SmartDate>(p => p.CreateDate, "Create Date");
        /// <summary>
        /// Date of creation
        /// </summary>
        /// <value>The Create Date.</value>
        public SmartDate CreateDate
        {
            get { return GetProperty(CreateDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CreateUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CreateUserIDProperty = RegisterProperty<int>(p => p.CreateUserID, "Create User ID");
        /// <summary>
        /// ID of the creating user
        /// </summary>
        /// <value>The Create User ID.</value>
        public int CreateUserID
        {
            get { return GetProperty(CreateUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeDate"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> ChangeDateProperty = RegisterProperty<SmartDate>(p => p.ChangeDate, "Change Date");
        /// <summary>
        /// Date of last change
        /// </summary>
        /// <value>The Change Date.</value>
        public SmartDate ChangeDate
        {
            get { return GetProperty(ChangeDateProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="ChangeUserID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ChangeUserIDProperty = RegisterProperty<int>(p => p.ChangeUserID, "Change User ID");
        /// <summary>
        /// ID of the last changing user
        /// </summary>
        /// <value>The Change User ID.</value>
        public int ChangeUserID
        {
            get { return GetProperty(ChangeUserIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="RowVersion"/> property.
        /// </summary>
        [NotUndoable]
        public static readonly PropertyInfo<byte[]> RowVersionProperty = RegisterProperty<byte[]>(p => p.RowVersion, "Row Version");
        /// <summary>
        /// Row version counter for concurrency control
        /// </summary>
        /// <value>The Row Version.</value>
        public byte[] RowVersion
        {
            get { return GetProperty(RowVersionProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocTypeEditDyna"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocTypeEditDyna"/> object.</returns>
        internal static DocTypeEditDyna NewDocTypeEditDyna()
        {
            return DataPortal.Create<DocTypeEditDyna>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocTypeEditDyna"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="DocTypeEditDyna"/> object.</returns>
        internal static DocTypeEditDyna GetDocTypeEditDyna(SafeDataReader dr)
        {
            DocTypeEditDyna obj = new DocTypeEditDyna();
            obj.Fetch(dr);
            obj.MarkOld();
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        /// <summary>
        /// Factory method. Deletes a <see cref="DocTypeEditDyna"/> object, based on given parameters.
        /// </summary>
        /// <param name="docTypeID">The DocTypeID of the DocTypeEditDyna to delete.</param>
        internal static void DeleteDocTypeEditDyna(int docTypeID)
        {
            DataPortal.Delete<DocTypeEditDyna>(docTypeID);
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="DocTypeEditDyna"/> object.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        internal static void NewDocTypeEditDyna(EventHandler<DataPortalResult<DocTypeEditDyna>> callback)
        {
            DataPortal.BeginCreate<DocTypeEditDyna>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously deletes a <see cref="DocTypeEditDyna"/> object, based on given parameters.
        /// </summary>
        /// <param name="docTypeID">The DocTypeID of the DocTypeEditDyna to delete.</param>
        /// <param name="callback">The completion callback method.</param>
        internal static void DeleteDocTypeEditDyna(int docTypeID, EventHandler<DataPortalResult<DocTypeEditDyna>> callback)
        {
            DataPortal.BeginDelete<DocTypeEditDyna>(docTypeID, callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocTypeEditDyna"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocTypeEditDyna()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="DocTypeEditDyna"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void DataPortal_Create()
        {
            LoadProperty(DocTypeIDProperty, System.Threading.Interlocked.Decrement(ref _lastId));
            LoadProperty(CreateDateProperty, new SmartDate(DateTime.Now));
            LoadProperty(CreateUserIDProperty, UserInformation.UserId);
            LoadProperty(ChangeDateProperty, ReadProperty(CreateDateProperty));
            LoadProperty(ChangeUserIDProperty, ReadProperty(CreateUserIDProperty));
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.DataPortal_Create();
        }

        /// <summary>
        /// Loads a <see cref="DocTypeEditDyna"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(DocTypeIDProperty, dr.GetInt32("DocTypeID"));
            LoadProperty(DocTypeNameProperty, dr.GetString("DocTypeName"));
            LoadProperty(CreateDateProperty, dr.GetSmartDate("CreateDate", true));
            LoadProperty(CreateUserIDProperty, dr.GetInt32("CreateUserID"));
            LoadProperty(ChangeDateProperty, dr.GetSmartDate("ChangeDate", true));
            LoadProperty(ChangeUserIDProperty, dr.GetInt32("ChangeUserID"));
            LoadProperty(RowVersionProperty, dr.GetValue("RowVersion") as byte[]);
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Inserts a new <see cref="DocTypeEditDyna"/> object in the database.
        /// </summary>
        protected override void DataPortal_Insert()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("AddDocTypeEditDyna", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@DocTypeName", ReadProperty(DocTypeNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@CreateDate", ReadProperty(CreateDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@CreateUserID", ReadProperty(CreateUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    OnInsertPost(args);
                    LoadProperty(DocTypeIDProperty, (int) cmd.Parameters["@DocTypeID"].Value);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                ctx.Commit();
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="DocTypeEditDyna"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("UpdateDocTypeEditDyna", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocTypeID", ReadProperty(DocTypeIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@DocTypeName", ReadProperty(DocTypeNameProperty)).DbType = DbType.String;
                    cmd.Parameters.AddWithValue("@ChangeDate", ReadProperty(ChangeDateProperty).DBValue).DbType = DbType.DateTime2;
                    cmd.Parameters.AddWithValue("@ChangeUserID", ReadProperty(ChangeUserIDProperty)).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@RowVersion", ReadProperty(RowVersionProperty)).DbType = DbType.Binary;
                    cmd.Parameters.Add("@NewRowVersion", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    var args = new DataPortalHookArgs(cmd);
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    OnUpdatePost(args);
                    LoadProperty(RowVersionProperty, (byte[]) cmd.Parameters["@NewRowVersion"].Value);
                }
                ctx.Commit();
            }
        }

        private void SimpleAuditTrail()
        {
            LoadProperty(ChangeDateProperty, DateTime.Now);
            LoadProperty(ChangeUserIDProperty, UserInformation.UserId);
            if (IsNew)
            {
                LoadProperty(CreateDateProperty, ReadProperty(ChangeDateProperty));
                LoadProperty(CreateUserIDProperty, ReadProperty(ChangeUserIDProperty));
            }
        }

        /// <summary>
        /// Self deletes the <see cref="DocTypeEditDyna"/> object.
        /// </summary>
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(DocTypeID);
        }

        /// <summary>
        /// Deletes the <see cref="DocTypeEditDyna"/> object from database.
        /// </summary>
        /// <param name="docTypeID">The delete criteria.</param>
        protected void DataPortal_Delete(int docTypeID)
        {
            // audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("DeleteDocTypeEditDyna", ctx.Connection))
                {
                    cmd.Transaction = ctx.Transaction;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DocTypeID", docTypeID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, docTypeID);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
                ctx.Commit();
            }
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting all defaults for object creation.
        /// </summary>
        partial void OnCreate(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after setting query parameters and before the delete operation.
        /// </summary>
        partial void OnDeletePre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs in DataPortal_Delete, after the delete operation, before Commit().
        /// </summary>
        partial void OnDeletePost(DataPortalHookArgs args);

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
