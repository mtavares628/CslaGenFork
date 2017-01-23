//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    CircTypeTagEditColl
// ObjectType:  CircTypeTagEditColl
// CSLAType:    EditableRootCollection

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;
using UsingLibrary;

namespace DocStore.Business
{

    /// <summary>
    /// CircTypeTagEditColl (editable root list).<br/>
    /// This is a generated base class of <see cref="CircTypeTagEditColl"/> business object.
    /// </summary>
    /// <remarks>
    /// The items of the collection are <see cref="CircTypeTagEdit"/> objects.
    /// </remarks>
    [Serializable]
#if WINFORMS
    public partial class CircTypeTagEditColl : MyBusinessBindingListBase<CircTypeTagEditColl, CircTypeTagEdit>, IHaveInterface, IHaveGenericInterface<CircTypeTagEditColl>
#else
    public partial class CircTypeTagEditColl : MyBusinessListBase<CircTypeTagEditColl, CircTypeTagEdit>, IHaveInterface, IHaveGenericInterface<CircTypeTagEditColl>
#endif
    {

        #region Collection Business Methods

        /// <summary>
        /// Removes a <see cref="CircTypeTagEdit"/> item from the collection.
        /// </summary>
        /// <param name="circTypeID">The CircTypeID of the item to be removed.</param>
        public void Remove(int circTypeID)
        {
            foreach (var circTypeTagEdit in this)
            {
                if (circTypeTagEdit.CircTypeID == circTypeID)
                {
                    Remove(circTypeTagEdit);
                    break;
                }
            }
        }

        /// <summary>
        /// Determines whether a <see cref="CircTypeTagEdit"/> item is in the collection.
        /// </summary>
        /// <param name="circTypeID">The CircTypeID of the item to search for.</param>
        /// <returns><c>true</c> if the CircTypeTagEdit is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int circTypeID)
        {
            foreach (var circTypeTagEdit in this)
            {
                if (circTypeTagEdit.CircTypeID == circTypeID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a <see cref="CircTypeTagEdit"/> item is in the collection's DeletedList.
        /// </summary>
        /// <param name="circTypeID">The CircTypeID of the item to search for.</param>
        /// <returns><c>true</c> if the CircTypeTagEdit is a deleted collection item; otherwise, <c>false</c>.</returns>
        public bool ContainsDeleted(int circTypeID)
        {
            foreach (var circTypeTagEdit in DeletedList)
            {
                if (circTypeTagEdit.CircTypeID == circTypeID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="CircTypeTagEditColl"/> collection.
        /// </summary>
        /// <returns>A reference to the created <see cref="CircTypeTagEditColl"/> collection.</returns>
        public static CircTypeTagEditColl NewCircTypeTagEditColl()
        {
            return DataPortal.Create<CircTypeTagEditColl>();
        }

        /// <summary>
        /// Factory method. Loads a <see cref="CircTypeTagEditColl"/> collection.
        /// </summary>
        /// <returns>A reference to the fetched <see cref="CircTypeTagEditColl"/> collection.</returns>
        public static CircTypeTagEditColl GetCircTypeTagEditColl()
        {
            return DataPortal.Fetch<CircTypeTagEditColl>();
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="CircTypeTagEditColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewCircTypeTagEditColl(EventHandler<DataPortalResult<CircTypeTagEditColl>> callback)
        {
            DataPortal.BeginCreate<CircTypeTagEditColl>(callback);
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="CircTypeTagEditColl"/> collection.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void GetCircTypeTagEditColl(EventHandler<DataPortalResult<CircTypeTagEditColl>> callback)
        {
            DataPortal.BeginFetch<CircTypeTagEditColl>(callback);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CircTypeTagEditColl"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CircTypeTagEditColl()
        {
            // Use factory methods and do not use direct creation.

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = true;
            AllowEdit = true;
            AllowRemove = true;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="CircTypeTagEditColl"/> collection from the database.
        /// </summary>
        protected void DataPortal_Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager(Database.DocStoreConnection, false))
            {
                using (var cmd = new SqlCommand("GetCircTypeTagEditColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var args = new DataPortalHookArgs(cmd);
                    OnFetchPre(args);
                    LoadCollection(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void LoadCollection(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
            {
                Fetch(dr);
            }
        }

        /// <summary>
        /// Loads all <see cref="CircTypeTagEditColl"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            while (dr.Read())
            {
                Add(CircTypeTagEdit.GetCircTypeTagEdit(dr));
            }
            RaiseListChangedEvents = rlce;
        }

        /// <summary>
        /// Updates in the database all changes made to the <see cref="CircTypeTagEditColl"/> object.
        /// </summary>
        protected override void DataPortal_Update()
        {
            using (var ctx = TransactionManager<SqlConnection, SqlTransaction>.GetManager(Database.DocStoreConnection, false))
            {
                base.Child_Update();
                ctx.Commit();
            }
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        #endregion

    }
}