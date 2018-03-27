//  This file was generated by CSLA Object Generator - CslaGenFork v4.5
//
// Filename:    CircInfo
// ObjectType:  CircInfo
// CSLAType:    ReadOnlyObject

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using DocStore.Business.Util;

namespace DocStore.Business.Circulations
{

    /// <summary>
    /// Circulation of document or folder (read only object).<br/>
    /// This is a generated <see cref="CircInfo"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="CircList"/> collection.
    /// </remarks>
    [Serializable]
    public partial class CircInfo : ReadOnlyBase<CircInfo>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="CircID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CircIDProperty = RegisterProperty<int>(p => p.CircID, "Circ ID", -1);
        /// <summary>
        /// Gets the Circ ID.
        /// </summary>
        /// <value>The Circ ID.</value>
        public int CircID
        {
            get { return GetProperty(CircIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DocID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int?> DocIDProperty = RegisterProperty<int?>(p => p.DocID, "Doc ID", null);
        /// <summary>
        /// Gets the Doc ID.
        /// </summary>
        /// <value>The Doc ID.</value>
        public int? DocID
        {
            get { return GetProperty(DocIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="FolderID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int?> FolderIDProperty = RegisterProperty<int?>(p => p.FolderID, "Folder ID", null);
        /// <summary>
        /// Gets the Folder ID.
        /// </summary>
        /// <value>The Folder ID.</value>
        public int? FolderID
        {
            get { return GetProperty(FolderIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="NeedsReply"/> property.
        /// </summary>
        public static readonly PropertyInfo<bool> NeedsReplyProperty = RegisterProperty<bool>(p => p.NeedsReply, "Needs Reply");
        /// <summary>
        /// Gets the Needs Reply.
        /// </summary>
        /// <value><c>true</c> if Needs Reply; otherwise, <c>false</c>.</value>
        public bool NeedsReply
        {
            get { return GetProperty(NeedsReplyProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="NeedsReplyDecision"/> property.
        /// </summary>
        public static readonly PropertyInfo<bool> NeedsReplyDecisionProperty = RegisterProperty<bool>(p => p.NeedsReplyDecision, "Needs Reply Decision");
        /// <summary>
        /// Gets the Needs Reply Decision.
        /// </summary>
        /// <value><c>true</c> if Needs Reply Decision; otherwise, <c>false</c>.</value>
        public bool NeedsReplyDecision
        {
            get { return GetProperty(NeedsReplyDecisionProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CircTypeTag"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> CircTypeTagProperty = RegisterProperty<string>(p => p.CircTypeTag, "Circ Type Tag");
        /// <summary>
        /// Gets the Circ Type Tag.
        /// </summary>
        /// <value>The Circ Type Tag.</value>
        public string CircTypeTag
        {
            get { return GetProperty(CircTypeTagProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SenderEntityID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int?> SenderEntityIDProperty = RegisterProperty<int?>(p => p.SenderEntityID, "Sender Entity ID", null);
        /// <summary>
        /// Gets the Sender Entity ID.
        /// </summary>
        /// <value>The Sender Entity ID.</value>
        public int? SenderEntityID
        {
            get { return GetProperty(SenderEntityIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SentDateTime"/> property.
        /// </summary>
        public static readonly PropertyInfo<SmartDate> SentDateTimeProperty = RegisterProperty<SmartDate>(p => p.SentDateTime, "Sent Date Time", null);
        /// <summary>
        /// Gets the Sent Date Time.
        /// </summary>
        /// <value>The Sent Date Time.</value>
        public SmartDate SentDateTime
        {
            get { return GetProperty(SentDateTimeProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DaysToReply"/> property.
        /// </summary>
        public static readonly PropertyInfo<short> DaysToReplyProperty = RegisterProperty<short>(p => p.DaysToReply, "Days To Reply");
        /// <summary>
        /// Gets the Days To Reply.
        /// </summary>
        /// <value>The Days To Reply.</value>
        public short DaysToReply
        {
            get { return GetProperty(DaysToReplyProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="DaysToLive"/> property.
        /// </summary>
        public static readonly PropertyInfo<short> DaysToLiveProperty = RegisterProperty<short>(p => p.DaysToLive, "Days To Live");
        /// <summary>
        /// Gets the Days To Live.
        /// </summary>
        /// <value>The Days To Live.</value>
        public short DaysToLive
        {
            get { return GetProperty(DaysToLiveProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="CircInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="CircInfo"/> object.</returns>
        internal static CircInfo GetCircInfo(SafeDataReader dr)
        {
            CircInfo obj = new CircInfo();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CircInfo"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public CircInfo()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="CircInfo"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(CircIDProperty, dr.GetInt32("CircID"));
            LoadProperty(DocIDProperty, (int?)dr.GetValue("DocID"));
            LoadProperty(FolderIDProperty, (int?)dr.GetValue("FolderID"));
            LoadProperty(NeedsReplyProperty, dr.GetBoolean("NeedsReply"));
            LoadProperty(NeedsReplyDecisionProperty, dr.GetBoolean("NeedsReplyDecision"));
            LoadProperty(CircTypeTagProperty, dr.GetString("CircTypeTag"));
            LoadProperty(SenderEntityIDProperty, (int?)dr.GetValue("SenderEntityID"));
            LoadProperty(SentDateTimeProperty, dr.IsDBNull("SentDateTime") ? null : dr.GetSmartDate("SentDateTime", true));
            LoadProperty(DaysToReplyProperty, dr.GetInt16("DaysToReply"));
            LoadProperty(DaysToLiveProperty, dr.GetInt16("DaysToLive"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
