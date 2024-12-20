using System;
using Csla;
using ParentLoad.DataAccess;
using ParentLoad.DataAccess.ERCLevel;

namespace ParentLoad.Business.ERCLevel
{

    /// <summary>
    /// B04_SubContinent (editable child object).<br/>
    /// This is a generated base class of <see cref="B04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B05_CountryObjects"/> of type <see cref="B05_CountryColl"/> (1:M relation to <see cref="B06_Country"/>)<br/>
    /// This class is an item of <see cref="B03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B04_SubContinent : BusinessBase<B04_SubContinent>
    {

        #region Static Fields

        private static int _lastID;

        #endregion

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_Continent_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SubContinent_IDProperty = RegisterProperty<int>(p => p.SubContinent_ID, "Sub Continent ID");
        /// <summary>
        /// Gets the Sub Continent ID.
        /// </summary>
        /// <value>The Sub Continent ID.</value>
        public int SubContinent_ID
        {
            get { return GetProperty(SubContinent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_NameProperty = RegisterProperty<string>(p => p.SubContinent_Name, "Sub Continent Name");
        /// <summary>
        /// Gets or sets the Sub Continent Name.
        /// </summary>
        /// <value>The Sub Continent Name.</value>
        public string SubContinent_Name
        {
            get { return GetProperty(SubContinent_NameProperty); }
            set { SetProperty(SubContinent_NameProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B05_SubContinent_Child> B05_SubContinent_SingleObjectProperty = RegisterProperty<B05_SubContinent_Child>(p => p.B05_SubContinent_SingleObject, "B05 SubContinent Single Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B05 Sub Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B05 Sub Continent Single Object.</value>
        public B05_SubContinent_Child B05_SubContinent_SingleObject
        {
            get { return GetProperty(B05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(B05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B05_SubContinent_ReChild> B05_SubContinent_ASingleObjectProperty = RegisterProperty<B05_SubContinent_ReChild>(p => p.B05_SubContinent_ASingleObject, "B05 SubContinent ASingle Object", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B05 Sub Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B05 Sub Continent ASingle Object.</value>
        public B05_SubContinent_ReChild B05_SubContinent_ASingleObject
        {
            get { return GetProperty(B05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(B05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B05_CountryColl> B05_CountryObjectsProperty = RegisterProperty<B05_CountryColl>(p => p.B05_CountryObjects, "B05 Country Objects", RelationshipTypes.Child);
        /// <summary>
        /// Gets the B05 Country Objects ("parent load" child property).
        /// </summary>
        /// <value>The B05 Country Objects.</value>
        public B05_CountryColl B05_CountryObjects
        {
            get { return GetProperty(B05_CountryObjectsProperty); }
            private set { LoadProperty(B05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="B04_SubContinent"/> object.
        /// </summary>
        /// <returns>A reference to the created <see cref="B04_SubContinent"/> object.</returns>
        internal static B04_SubContinent NewB04_SubContinent()
        {
            return DataPortal.CreateChild<B04_SubContinent>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="B04_SubContinent"/> object from the given B04_SubContinentDto.
        /// </summary>
        /// <param name="data">The <see cref="B04_SubContinentDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B04_SubContinent"/> object.</returns>
        internal static B04_SubContinent GetB04_SubContinent(B04_SubContinentDto data)
        {
            B04_SubContinent obj = new B04_SubContinent();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            obj.LoadProperty(B05_CountryObjectsProperty, B05_CountryColl.NewB05_CountryColl());
            obj.MarkOld();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public B04_SubContinent()
        {
            // Use factory methods and do not use direct creation.

            // show the framework that this is a child object
            MarkAsChild();
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads default values for the <see cref="B04_SubContinent"/> object properties.
        /// </summary>
        [Csla.RunLocal]
        protected override void Child_Create()
        {
            LoadProperty(SubContinent_IDProperty, System.Threading.Interlocked.Decrement(ref _lastID));
            LoadProperty(B05_SubContinent_SingleObjectProperty, DataPortal.CreateChild<B05_SubContinent_Child>());
            LoadProperty(B05_SubContinent_ASingleObjectProperty, DataPortal.CreateChild<B05_SubContinent_ReChild>());
            LoadProperty(B05_CountryObjectsProperty, DataPortal.CreateChild<B05_CountryColl>());
            var args = new DataPortalHookArgs();
            OnCreate(args);
            base.Child_Create();
        }

        /// <summary>
        /// Loads a <see cref="B04_SubContinent"/> object from the given <see cref="B04_SubContinentDto"/>.
        /// </summary>
        /// <param name="data">The B04_SubContinentDto to use.</param>
        private void Fetch(B04_SubContinentDto data)
        {
            // Value properties
            LoadProperty(SubContinent_IDProperty, data.SubContinent_ID);
            LoadProperty(SubContinent_NameProperty, data.SubContinent_Name);
            // parent properties
            parent_Continent_ID = data.Parent_Continent_ID;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B05_SubContinent_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B05_SubContinent_Child child)
        {
            LoadProperty(B05_SubContinent_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B05_SubContinent_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B05_SubContinent_ReChild child)
        {
            LoadProperty(B05_SubContinent_ASingleObjectProperty, child);
        }

        /// <summary>
        /// Inserts a new <see cref="B04_SubContinent"/> object in the database.
        /// </summary>
        /// <param name="parent">The parent object.</param>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Insert(B02_Continent parent)
        {
            var dto = new B04_SubContinentDto();
            dto.Parent_Continent_ID = parent.Continent_ID;
            dto.SubContinent_Name = SubContinent_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnInsertPre(args);
                var dal = dalManager.GetProvider<IB04_SubContinentDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Insert(dto);
                    LoadProperty(SubContinent_IDProperty, resultDto.SubContinent_ID);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnInsertPost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="B04_SubContinent"/> object.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_Update()
        {
            if (!IsDirty)
                return;

            var dto = new B04_SubContinentDto();
            dto.SubContinent_ID = SubContinent_ID;
            dto.SubContinent_Name = SubContinent_Name;
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs(dto);
                OnUpdatePre(args);
                var dal = dalManager.GetProvider<IB04_SubContinentDal>();
                using (BypassPropertyChecks)
                {
                    var resultDto = dal.Update(dto);
                    args = new DataPortalHookArgs(resultDto);
                }
                OnUpdatePost(args);
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
            }
        }

        /// <summary>
        /// Self deletes the <see cref="B04_SubContinent"/> object from database.
        /// </summary>
        [Transactional(TransactionalTypes.TransactionScope)]
        private void Child_DeleteSelf()
        {
            using (var dalManager = DalFactoryParentLoad.GetManager())
            {
                var args = new DataPortalHookArgs();
                // flushes all pending data operations
                FieldManager.UpdateChildren(this);
                OnDeletePre(args);
                var dal = dalManager.GetProvider<IB04_SubContinentDal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(ReadProperty(SubContinent_IDProperty));
                }
                OnDeletePost(args);
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
