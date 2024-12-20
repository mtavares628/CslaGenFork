using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Xml.Serialization;
using CslaGenerator.Attributes;
using CslaGenerator.Design;
using CslaGenerator.Util;

namespace CslaGenerator.Metadata
{
    /// <summary>
    /// Summary description for Property.
    /// </summary>
    [Serializable]
    [DefaultProperty("Name")]
    public class Property : ICloneable
    {
        private string _name = string.Empty;
        private TypeCodeEx _propertyType = TypeCodeEx.Empty;
        private bool _readOnly;
        private string _summary = string.Empty;
        private string _remarks = string.Empty;
        protected string _parameterName = string.Empty;
        protected string _parameterSize = string.Empty;
        private bool _nullable;

        #region Constructors

        public Property()
        {
        }

        public Property(Property prop)
        {
            Clone(prop);
        }

        public Property(string name, TypeCodeEx type)
        {
            _name = name;
            _propertyType = type;
        }

        public Property(string name, TypeCodeEx type, string parameterName)
        {
            _name = name;
            _propertyType = type;
            _parameterName = parameterName;
        }

        #endregion

        #region UI Properties

        #region 00. Database

        [Category("00. Database")]
        [Description("The stored procedure parameter name.")]
        [UserFriendlyName("Parameter Name")]
        public virtual string ParameterName
        {
            get
            {
                if (_parameterName.Equals(string.Empty))
                    return _name;
                return _parameterName;
            }
            set { _parameterName = PropertyHelper.Tidy(value); }
        }

        #endregion

        #region 01. Definition

        [Category("01. Definition")]
        [Description("The property name.")]
        public virtual string Name
        {
            get { return _name; }
            set { _name = PropertyHelper.Tidy(value); }
        }

        [Category("01. Definition")]
        [Description("The property data Type. Select \"CustomType\" to disable database interaction.")]
        [UserFriendlyName("Property Type")]
        public virtual TypeCodeEx PropertyType
        {
            get { return _propertyType; }
            set { _propertyType = value; }
        }

        [Category("01. Definition")]
        [Description("Whether this property can be changed by other classes.")]
        public virtual bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        [Category("01. Definition")]
        [Description("Whether this property can have a null value. The following types can't be null:  \"DBNull \" and \"Empty\".")]
        public virtual bool Nullable
        {
            get
            {
                if (_propertyType.IsNullAllowedOnType())
                    return _nullable;

                return false;
            }
            set { _nullable = value; }
        }

        #endregion

        #region 04. Documentation

        [Category("04. Documentation")]
        [Editor(typeof(XmlCommentEditor), typeof(UITypeEditor))]
        [Description("Summary of the property.")]
        public virtual string Summary
        {
            get { return _summary; }
            set { _summary = PropertyHelper.TidyXML(value); }
        }

        [Category("04. Documentation")]
        [Editor(typeof(XmlCommentEditor), typeof(UITypeEditor))]
        [Description("Remarks of the property.")]
        public virtual string Remarks
        {
            get { return _remarks; }
            set { _remarks = PropertyHelper.TidyXML(value); }
        }

        #endregion

        #endregion

        public override bool Equals(object item)
        {
            if (!item.GetType().Equals(GetType()))
                return false;

            if (CaseInsensitiveComparer.Default.Compare(_name, ((Property) item).Name) == 0)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        protected void ResetProperties(DbBindColumn dbc)
        {
            if (dbc != null && dbc.Column != null)
            {
                _name = dbc.ColumnName;
                _parameterName = dbc.ColumnName;
                _propertyType = dbc.Column.ManagedType.GetTypeCodeEx();
            }
        }

        public virtual object Clone()
        {
            using (var buffer = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof(Property));
                ser.Serialize(buffer, this);
                buffer.Position = 0;
                return ser.Deserialize(buffer);
            }
        }

        public virtual void Clone(Property prop)
        {
            ParameterName = prop.ParameterName;
            Name = prop.Name;
            PropertyType = prop.PropertyType;
            ReadOnly = prop.ReadOnly;
            Nullable = prop.Nullable;
            Summary = prop.Summary;
            Remarks = prop.Remarks;
        }
    }
}