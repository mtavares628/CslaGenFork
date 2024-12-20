using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E10Level11111 (read only object).<br/>
    /// This is a generated base class of <see cref="E10Level11111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E11Level111111Objects"/> of type <see cref="E11Level111111Coll"/> (1:M relation to <see cref="E12Level111111"/>)<br/>
    /// This class is an item of <see cref="E09Level11111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E10Level11111 : ReadOnlyBase<E10Level11111>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int narentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_1_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_1_1_1_ID, "Level_1_1_1_1_1 ID", -1);
        /// <summary>
        /// Gets the Level_1_1_1_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1_1_1_1 ID.</value>
        public int Level_1_1_1_1_1_ID
        {
            get { return GetProperty(Level_1_1_1_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_1_1_Name, "Level_1_1_1_1_1 Name");
        /// <summary>
        /// Gets the Level_1_1_1_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1_1_1_1 Name.</value>
        public string Level_1_1_1_1_1_Name
        {
            get { return GetProperty(Level_1_1_1_1_1_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E11Level111111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E11Level111111Child> E11Level111111SingleObjectProperty = RegisterProperty<E11Level111111Child>(p => p.E11Level111111SingleObject, "E11 Level111111 Single Object");
        /// <summary>
        /// Gets the E11 Level111111 Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E11 Level111111 Single Object.</value>
        public E11Level111111Child E11Level111111SingleObject
        {
            get { return GetProperty(E11Level111111SingleObjectProperty); }
            private set { LoadProperty(E11Level111111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E11Level111111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E11Level111111ReChild> E11Level111111ASingleObjectProperty = RegisterProperty<E11Level111111ReChild>(p => p.E11Level111111ASingleObject, "E11 Level111111 ASingle Object");
        /// <summary>
        /// Gets the E11 Level111111 ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E11 Level111111 ASingle Object.</value>
        public E11Level111111ReChild E11Level111111ASingleObject
        {
            get { return GetProperty(E11Level111111ASingleObjectProperty); }
            private set { LoadProperty(E11Level111111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E11Level111111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E11Level111111Coll> E11Level111111ObjectsProperty = RegisterProperty<E11Level111111Coll>(p => p.E11Level111111Objects, "E11 Level111111 Objects");
        /// <summary>
        /// Gets the E11 Level111111 Objects ("parent load" child property).
        /// </summary>
        /// <value>The E11 Level111111 Objects.</value>
        public E11Level111111Coll E11Level111111Objects
        {
            get { return GetProperty(E11Level111111ObjectsProperty); }
            private set { LoadProperty(E11Level111111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E10Level11111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E10Level11111"/> object.</returns>
        internal static E10Level11111 GetE10Level11111(SafeDataReader dr)
        {
            E10Level11111 obj = new E10Level11111();
            obj.Fetch(dr);
            obj.LoadProperty(E11Level111111ObjectsProperty, new E11Level111111Coll());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E10Level11111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E10Level11111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E10Level11111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_1_1_IDProperty, dr.GetInt32("Level_1_1_1_1_1_ID"));
            LoadProperty(Level_1_1_1_1_1_NameProperty, dr.GetString("Level_1_1_1_1_1_Name"));
            narentID1 = dr.GetInt32("NarentID1");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="E11Level111111Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E11Level111111Child child)
        {
            LoadProperty(E11Level111111SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="E11Level111111ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E11Level111111ReChild child)
        {
            LoadProperty(E11Level111111ASingleObjectProperty, child);
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
