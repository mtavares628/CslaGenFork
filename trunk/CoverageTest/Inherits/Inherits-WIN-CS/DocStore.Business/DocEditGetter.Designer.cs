//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocEditGetter
// ObjectType:  DocEditGetter
// CSLAType:    UnitOfWork

using System;
using Csla;
using DocStore.Business.Admin;
using UsingLibrary;

namespace DocStore.Business
{

    /// <summary>
    /// DocEditGetter (creator and getter unit of work pattern).<br/>
    /// This is a generated <see cref="DocEditGetter"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Serializable]
    public partial class DocEditGetter : ReadOnlyBase<DocEditGetter>, IHaveInterface, IHaveGenericInterface<DocEditGetter>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="Doc"/> property.
        /// </summary>
        public static readonly PropertyInfo<Doc> DocProperty = RegisterProperty<Doc>(p => p.Doc, "Doc");
        /// <summary>
        /// Gets the Doc object (unit of work child property).
        /// </summary>
        /// <value>The Doc.</value>
        public Doc Doc
        {
            get { return GetProperty(DocProperty); }
            private set { LoadProperty(DocProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="DocClassNVL"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocClassNVL> DocClassNVLProperty = RegisterProperty<DocClassNVL>(p => p.DocClassNVL, "Doc Class NVL");
        /// <summary>
        /// Gets the Doc Class NVL object (unit of work child property).
        /// </summary>
        /// <value>The Doc Class NVL.</value>
        public DocClassNVL DocClassNVL
        {
            get { return GetProperty(DocClassNVLProperty); }
            private set { LoadProperty(DocClassNVLProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="DocTypeNVL"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocTypeNVL> DocTypeNVLProperty = RegisterProperty<DocTypeNVL>(p => p.DocTypeNVL, "Doc Type NVL");
        /// <summary>
        /// Gets the Doc Type NVL object (unit of work child property).
        /// </summary>
        /// <value>The Doc Type NVL.</value>
        public DocTypeNVL DocTypeNVL
        {
            get { return GetProperty(DocTypeNVLProperty); }
            private set { LoadProperty(DocTypeNVLProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="DocStatusNVL"/> property.
        /// </summary>
        public static readonly PropertyInfo<DocStatusNVL> DocStatusNVLProperty = RegisterProperty<DocStatusNVL>(p => p.DocStatusNVL, "Doc Status NVL");
        /// <summary>
        /// Gets the Doc Status NVL object (unit of work child property).
        /// </summary>
        /// <value>The Doc Status NVL.</value>
        public DocStatusNVL DocStatusNVL
        {
            get { return GetProperty(DocStatusNVLProperty); }
            private set { LoadProperty(DocStatusNVLProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about unit of work (child) <see cref="UserNVL"/> property.
        /// </summary>
        public static readonly PropertyInfo<UserNVL> UserNVLProperty = RegisterProperty<UserNVL>(p => p.UserNVL, "User NVL");
        /// <summary>
        /// Gets the User NVL object (unit of work child property).
        /// </summary>
        /// <value>The User NVL.</value>
        public UserNVL UserNVL
        {
            get { return GetProperty(UserNVLProperty); }
            private set { LoadProperty(UserNVLProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Creates a new <see cref="DocEditGetter"/> unit of objects.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocEditGetter"/> unit of objects.</returns>
        public static DocEditGetter NewDocEditGetter()
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            return DataPortal.Fetch<DocEditGetter>(new Criteria1(true, new int()));
        }

        /// <summary>
        /// Factory method. Loads a <see cref="DocEditGetter"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the DocEditGetter to fetch.</param>
        /// <returns>A reference to the fetched <see cref="DocEditGetter"/> unit of objects.</returns>
        public static DocEditGetter GetDocEditGetter(int docID)
        {
            return DataPortal.Fetch<DocEditGetter>(new Criteria1(false, docID));
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="DocEditGetter"/> unit of objects.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewDocEditGetter(EventHandler<DataPortalResult<DocEditGetter>> callback)
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch<DocEditGetter>(new Criteria1(true, new int()), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                if (!DocClassNVL.IsCached)
                    DocClassNVL.SetCache(e.Object.DocClassNVL);
                if (!DocTypeNVL.IsCached)
                    DocTypeNVL.SetCache(e.Object.DocTypeNVL);
                if (!DocStatusNVL.IsCached)
                    DocStatusNVL.SetCache(e.Object.DocStatusNVL);
                if (!UserNVL.IsCached)
                    UserNVL.SetCache(e.Object.UserNVL);
                callback(o, e);
            });
        }

        /// <summary>
        /// Factory method. Asynchronously loads a <see cref="DocEditGetter"/> unit of objects, based on given parameters.
        /// </summary>
        /// <param name="docID">The DocID parameter of the DocEditGetter to fetch.</param>
        /// <param name="callback">The completion callback method.</param>
        public static void GetDocEditGetter(int docID, EventHandler<DataPortalResult<DocEditGetter>> callback)
        {
            DataPortal.BeginFetch<DocEditGetter>(new Criteria1(false, docID), (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;
                if (!DocClassNVL.IsCached)
                    DocClassNVL.SetCache(e.Object.DocClassNVL);
                if (!DocTypeNVL.IsCached)
                    DocTypeNVL.SetCache(e.Object.DocTypeNVL);
                if (!DocStatusNVL.IsCached)
                    DocStatusNVL.SetCache(e.Object.DocStatusNVL);
                if (!UserNVL.IsCached)
                    UserNVL.SetCache(e.Object.UserNVL);
                callback(o, e);
            });
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DocEditGetter"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocEditGetter()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Criteria

        /// <summary>
        /// Criteria1 criteria.
        /// </summary>
        [Serializable]
        protected class Criteria1 : CriteriaBase<Criteria1>
        {

            /// <summary>
            /// Maintains metadata about <see cref="CreateDoc"/> property.
            /// </summary>
            public static readonly PropertyInfo<bool> CreateDocProperty = RegisterProperty<bool>(p => p.CreateDoc, "Create Doc");
            /// <summary>
            /// Gets or sets the Create Doc.
            /// </summary>
            /// <value><c>true</c> if Create Doc; otherwise, <c>false</c>.</value>
            public bool CreateDoc
            {
                get { return ReadProperty(CreateDocProperty); }
                set { LoadProperty(CreateDocProperty, value); }
            }

            /// <summary>
            /// Maintains metadata about <see cref="DocID"/> property.
            /// </summary>
            public static readonly PropertyInfo<int> DocIDProperty = RegisterProperty<int>(p => p.DocID, "Doc ID");
            /// <summary>
            /// Gets or sets the Doc ID.
            /// </summary>
            /// <value>The Doc ID.</value>
            public int DocID
            {
                get { return ReadProperty(DocIDProperty); }
                set { LoadProperty(DocIDProperty, value); }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria1"/> class.
            /// </summary>
            /// <remarks> A parameterless constructor is required by the MobileFormatter.</remarks>
            [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
            public Criteria1()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Criteria1"/> class.
            /// </summary>
            /// <param name="createDoc">The CreateDoc.</param>
            /// <param name="docID">The DocID.</param>
            public Criteria1(bool createDoc, int docID)
            {
                CreateDoc = createDoc;
                DocID = docID;
            }

            /// <summary>
            /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
            /// </summary>
            /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
            /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
            public override bool Equals(object obj)
            {
                if (obj is Criteria1)
                {
                    var c = (Criteria1) obj;
                    if (!CreateDoc.Equals(c.CreateDoc))
                        return false;
                    if (!DocID.Equals(c.DocID))
                        return false;
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <returns>An hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                return string.Concat("Criteria1", CreateDoc.ToString(), DocID.ToString()).GetHashCode();
            }
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Creates or loads a <see cref="DocEditGetter"/> unit of objects, based on given criteria.
        /// </summary>
        /// <param name="crit">The create/fetch criteria.</param>
        protected void DataPortal_Fetch(Criteria1 crit)
        {
            if (crit.CreateDoc)
                LoadProperty(DocProperty, Doc.NewDoc());
            else
                LoadProperty(DocProperty, Doc.GetDoc(crit.DocID));
            LoadProperty(DocClassNVLProperty, DocClassNVL.GetDocClassNVL());
            LoadProperty(DocTypeNVLProperty, DocTypeNVL.GetDocTypeNVL());
            LoadProperty(DocStatusNVLProperty, DocStatusNVL.GetDocStatusNVL());
            LoadProperty(UserNVLProperty, UserNVL.GetUserNVL());
        }

        #endregion

    }
}
