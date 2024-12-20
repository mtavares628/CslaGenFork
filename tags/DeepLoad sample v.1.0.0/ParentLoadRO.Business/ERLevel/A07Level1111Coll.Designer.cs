using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A07Level1111Coll (read only list).<br/>
    /// This is a generated base class of <see cref="A07Level1111Coll"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is child of <see cref="A06Level111"/> read only object.<br/>
    /// The items of the collection are <see cref="A08Level1111"/> objects.
    /// </remarks>
    [Serializable]
    public partial class A07Level1111Coll : ReadOnlyListBase<A07Level1111Coll, A08Level1111>
    {

        #region Collection Business Methods

        /// <summary>
        /// Determines whether a <see cref="A08Level1111"/> item is in the collection.
        /// </summary>
        /// <param name="level_1_1_1_1_ID">The Level_1_1_1_1_ID of the item to search for.</param>
        /// <returns><c>true</c> if the A08Level1111 is a collection item; otherwise, <c>false</c>.</returns>
        public bool Contains(int level_1_1_1_1_ID)
        {
            foreach (var a08Level1111 in this)
            {
                if (a08Level1111.Level_1_1_1_1_ID == level_1_1_1_1_ID)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Find Methods

        /// <summary>
        /// Finds a <see cref="A08Level1111"/> item of the <see cref="A07Level1111Coll"/> collection, based on item key properties.
        /// </summary>
        /// <param name="level_1_1_1_1_ID">The Level_1_1_1_1_ID.</param>
        /// <returns>A <see cref="A08Level1111"/> object.</returns>
        public A08Level1111 FindA08Level1111ByParentProperties(int level_1_1_1_1_ID)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].Level_1_1_1_1_ID.Equals(level_1_1_1_1_ID))
                {
                    return this[i];
                }
            }

            return null;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A07Level1111Coll"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A07Level1111Coll"/> object.</returns>
        internal static A07Level1111Coll GetA07Level1111Coll(SafeDataReader dr)
        {
            A07Level1111Coll obj = new A07Level1111Coll();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A07Level1111Coll"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        internal A07Level1111Coll()
        {
            // Prevent direct creation

            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            AllowNew = false;
            AllowEdit = false;
            AllowRemove = false;
            RaiseListChangedEvents = rlce;
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads all <see cref="A07Level1111Coll"/> collection items from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(dr);
            OnFetchPre(args);
            while (dr.Read())
            {
                Add(A08Level1111.GetA08Level1111(dr));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        /// <summary>
        /// Loads <see cref="A08Level1111"/> items on the A07Level1111Objects collection.
        /// </summary>
        /// <param name="collection">The grand parent <see cref="A05Level111Coll"/> collection.</param>
        internal void LoadItems(A05Level111Coll collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindA06Level111ByParentProperties(item.larentID1);
                obj.A07Level1111Objects.IsReadOnly = false;
                var rlce = obj.A07Level1111Objects.RaiseListChangedEvents;
                obj.A07Level1111Objects.RaiseListChangedEvents = false;
                obj.A07Level1111Objects.Add(item);
                obj.A07Level1111Objects.RaiseListChangedEvents = rlce;
                obj.A07Level1111Objects.IsReadOnly = true;
            }
        }

        #endregion

        #region Pseudo Events

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
