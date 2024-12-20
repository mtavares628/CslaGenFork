//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    DocEditUoWCreator
// ObjectType:  DocEditUoWCreator
// CSLAType:    UnitOfWork

using System;
using Csla;
using DocStore.Business.Admin;
using UsingLibrary;

namespace DocStore.Business
{

    /// <summary>
    /// DocEditUoWCreator (creator unit of work pattern).<br/>
    /// This is a generated <see cref="DocEditUoWCreator"/> business object.
    /// This class is a root object that implements the Unit of Work pattern.
    /// </summary>
    [Serializable]
    public partial class DocEditUoWCreator : MyReadOnlyBase<DocEditUoWCreator>
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
        /// Factory method. Creates a new <see cref="DocEditUoWCreator"/> unit of objects.
        /// </summary>
        /// <returns>A reference to the created <see cref="DocEditUoWCreator"/> unit of objects.</returns>
        public static DocEditUoWCreator NewDocEditUoWCreator()
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            return DataPortal.Fetch<DocEditUoWCreator>();
        }

        /// <summary>
        /// Factory method. Asynchronously creates a new <see cref="DocEditUoWCreator"/> unit of objects.
        /// </summary>
        /// <param name="callback">The completion callback method.</param>
        public static void NewDocEditUoWCreator(EventHandler<DataPortalResult<DocEditUoWCreator>> callback)
        {
            // DataPortal_Fetch is used as ReadOnlyBase<T> doesn't allow the use of DataPortal_Create.
            DataPortal.BeginFetch<DocEditUoWCreator>((o, e) =>
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
        /// Initializes a new instance of the <see cref="DocEditUoWCreator"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Unit of Work. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DocEditUoWCreator()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Creates a new <see cref="DocEditUoWCreator"/> unit of objects.
        /// </summary>
        /// <remarks>
        /// ReadOnlyBase&lt;T&gt; doesn't allow the use of DataPortal_Create and thus DataPortal_Fetch is used.
        /// </remarks>
        protected void DataPortal_Fetch()
        {
            LoadProperty(DocProperty, Doc.NewDoc());
            LoadProperty(DocClassNVLProperty, DocClassNVL.GetDocClassNVL());
            LoadProperty(DocTypeNVLProperty, DocTypeNVL.GetDocTypeNVL());
            LoadProperty(DocStatusNVLProperty, DocStatusNVL.GetDocStatusNVL());
            LoadProperty(UserNVLProperty, UserNVL.GetUserNVL());
        }

        #endregion

    }
}
