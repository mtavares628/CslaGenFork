using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G04Level11 (read only object).<br/>
    /// This is a generated base class of <see cref="G04Level11"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="G05Level111Objects"/> of type <see cref="G05Level111Coll"/> (1:M relation to <see cref="G06Level111"/>)<br/>
    /// This class is an item of <see cref="G03Level11Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G04Level11 : ReadOnlyBase<G04Level11>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Level_1_1_IDProperty = RegisterProperty<int>(p => p.Level_1_1_ID, "Level_1_1 ID", -1);
        /// <summary>
        /// Gets the Level_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1 ID.</value>
        public int Level_1_1_ID
        {
            get { return GetProperty(Level_1_1_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_NameProperty = RegisterProperty<string>(p => p.Level_1_1_Name, "Level_1_1 Name");
        /// <summary>
        /// Gets the Level_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1 Name.</value>
        public string Level_1_1_Name
        {
            get { return GetProperty(Level_1_1_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G05Level111SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G05Level111Child> G05Level111SingleObjectProperty = RegisterProperty<G05Level111Child>(p => p.G05Level111SingleObject, "A5 Level111 Single Object");
        /// <summary>
        /// Gets the G05 Level111 Single Object ("self load" child property).
        /// </summary>
        /// <value>The G05 Level111 Single Object.</value>
        public G05Level111Child G05Level111SingleObject
        {
            get { return GetProperty(G05Level111SingleObjectProperty); }
            private set { LoadProperty(G05Level111SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G05Level111ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G05Level111ReChild> G05Level111ASingleObjectProperty = RegisterProperty<G05Level111ReChild>(p => p.G05Level111ASingleObject, "A5 Level111 ASingle Object");
        /// <summary>
        /// Gets the G05 Level111 ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The G05 Level111 ASingle Object.</value>
        public G05Level111ReChild G05Level111ASingleObject
        {
            get { return GetProperty(G05Level111ASingleObjectProperty); }
            private set { LoadProperty(G05Level111ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G05Level111Objects"/> property.
        /// </summary>
        public static readonly PropertyInfo<G05Level111Coll> G05Level111ObjectsProperty = RegisterProperty<G05Level111Coll>(p => p.G05Level111Objects, "A5 Level111 Objects");
        /// <summary>
        /// Gets the G05 Level111 Objects ("self load" child property).
        /// </summary>
        /// <value>The G05 Level111 Objects.</value>
        public G05Level111Coll G05Level111Objects
        {
            get { return GetProperty(G05Level111ObjectsProperty); }
            private set { LoadProperty(G05Level111ObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="G04Level11"/> object.</returns>
        internal static G04Level11 GetG04Level11(SafeDataReader dr)
        {
            G04Level11 obj = new G04Level11();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G04Level11"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G04Level11()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G04Level11"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_IDProperty, dr.GetInt32("Level_1_1_ID"));
            LoadProperty(Level_1_1_NameProperty, dr.GetString("Level_1_1_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(G05Level111SingleObjectProperty, G05Level111Child.GetG05Level111Child(Level_1_1_ID));
            LoadProperty(G05Level111ASingleObjectProperty, G05Level111ReChild.GetG05Level111ReChild(Level_1_1_ID));
            LoadProperty(G05Level111ObjectsProperty, G05Level111Coll.GetG05Level111Coll(Level_1_1_ID));
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
