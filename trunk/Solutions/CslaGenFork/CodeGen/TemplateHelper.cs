﻿using System;
using System.Collections.Generic;
using System.Data;
using CslaGenerator.Metadata;
using DBSchemaInfo.Base;

namespace CslaGenerator.CodeGen
{
    /// <summary>
    /// Summary description for TemplateHelper.
    /// </summary>
    public static class TemplateHelper
    {
        #region Types

        public static TypeCodeEx GetBackingFieldType(this ValueProperty prop)
        {
            if (prop.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.UnmanagedWithTypeConversion ||
                prop.DeclarationMode == PropertyDeclaration.ClassicPropertyWithTypeConversion)
                return prop.BackingFieldType;

            return prop.PropertyType;
        }

        public static SqlDbType GetSqlDbType(this TypeCodeEx type)
        {
            switch (type)
            {
                case TypeCodeEx.Boolean:
                    return SqlDbType.Bit;
                case TypeCodeEx.Byte:
                    return SqlDbType.TinyInt;
                case TypeCodeEx.ByteArray:
                    return SqlDbType.Image;
                case TypeCodeEx.Char:
                    return SqlDbType.Char;
                case TypeCodeEx.TimeSpan:
                    return SqlDbType.Time;
                case TypeCodeEx.DateTimeOffset:
                    return SqlDbType.DateTimeOffset;
                case TypeCodeEx.SmartDate:
                case TypeCodeEx.DateTime:
                    return SqlDbType.DateTime;
                case TypeCodeEx.Decimal:
                    return SqlDbType.Decimal;
                case TypeCodeEx.Double:
                    return SqlDbType.Float;
                case TypeCodeEx.Guid:
                    return SqlDbType.UniqueIdentifier;
                case TypeCodeEx.Int16:
                    return SqlDbType.SmallInt;
                case TypeCodeEx.Int32:
                    return SqlDbType.Int;
                case TypeCodeEx.Int64:
                    return SqlDbType.BigInt;
                case TypeCodeEx.SByte:
                    return SqlDbType.TinyInt;
                case TypeCodeEx.Single:
                    return SqlDbType.Real;
                case TypeCodeEx.String:
                    return SqlDbType.VarChar;
                case TypeCodeEx.UInt16:
                    return SqlDbType.Int;
                case TypeCodeEx.UInt32:
                    return SqlDbType.BigInt;
                case TypeCodeEx.UInt64:
                    return SqlDbType.BigInt;
                case TypeCodeEx.Object:
                    return SqlDbType.Image;
                default:
                    return SqlDbType.VarChar;
            }
        }

        public static DbType GetDbType(this TypeCodeEx type)
        {
            switch (type)
            {
                case TypeCodeEx.Boolean:
                    return DbType.Boolean;
                case TypeCodeEx.Byte:
                    return DbType.Byte;
                case TypeCodeEx.ByteArray:
                    return DbType.Binary;
                case TypeCodeEx.Char:
                    return DbType.StringFixedLength;
                case TypeCodeEx.TimeSpan:
                    return DbType.Time;
                case TypeCodeEx.DateTimeOffset:
                    return DbType.DateTimeOffset;
                case TypeCodeEx.SmartDate:
                case TypeCodeEx.DateTime:
                    return DbType.DateTime;
                case TypeCodeEx.Decimal:
                    return DbType.Decimal;
                case TypeCodeEx.Double:
                    return DbType.Double;
                case TypeCodeEx.Guid:
                    return DbType.Guid;
                case TypeCodeEx.Int16:
                    return DbType.Int16;
                case TypeCodeEx.Int32:
                    return DbType.Int32;
                case TypeCodeEx.Int64:
                    return DbType.Int64;
                case TypeCodeEx.SByte:
                    return DbType.SByte;
                case TypeCodeEx.Single:
                    return DbType.Single;
                case TypeCodeEx.String:
                    return DbType.String;
                case TypeCodeEx.UInt16:
                    return DbType.UInt16;
                case TypeCodeEx.UInt32:
                    return DbType.UInt32;
                case TypeCodeEx.UInt64:
                    return DbType.UInt64;
                case TypeCodeEx.Object:
                    return DbType.Binary;
                default:
                    return DbType.String;
            }
        }

        public static DbType GetDbType(this Property prop)
        {
            return GetDbType(prop.PropertyType);
        }

        public static DbType GetDbType(this ValueProperty prop)
        {
            if (prop.DbBindColumn == null || prop.DbBindColumn.ColumnOriginType == ColumnOriginType.None)
                return GetDbType(prop.PropertyType);

            return GetDbType(prop.DbBindColumn);
        }

        public static DbType GetDbType(this CriteriaProperty prop)
        {
            if (prop.DbBindColumn.Column == null)
                return GetDbType(prop.PropertyType);

            return GetDbType(prop.DbBindColumn);
        }

        public static DbType GetDbType(this DbBindColumn prop)
        {
            if (prop.NativeType == "real")
                return DbType.Single;

            return prop.DataType;
        }

        public static bool IsNullableType(this TypeCodeEx type)
        {
            switch (type)
            {
                case TypeCodeEx.Boolean:
                case TypeCodeEx.Byte:
                case TypeCodeEx.Char:
                case TypeCodeEx.Decimal:
                case TypeCodeEx.Double:
                case TypeCodeEx.Guid:
                case TypeCodeEx.Int16:
                case TypeCodeEx.Int32:
                case TypeCodeEx.Int64:
                case TypeCodeEx.SByte:
                case TypeCodeEx.Single:
                case TypeCodeEx.UInt16:
                case TypeCodeEx.UInt32:
                case TypeCodeEx.UInt64:
                case TypeCodeEx.TimeSpan:
                case TypeCodeEx.DateTimeOffset:
                case TypeCodeEx.DateTime:
                    return true;

                /*
                 * These are not nullable:
                case TypeCodeEx.ByteArray:
                case TypeCodeEx.CustomType:
                case TypeCodeEx.SmartDate:
                case TypeCodeEx.DBNull:
                case TypeCodeEx.Empty:
                case TypeCodeEx.Object:
                case TypeCodeEx.String:
                 */
            }
            return false;
        }

        public static string ListBaseHelper(string rootStereotype, bool isBindingList)
        {
            var response = string.Empty;

            if (isBindingList)
            {
                response += rootStereotype + "BindingListBase";
            }
            else
            {
                response += rootStereotype + "ListBase";
            }

            return response;
        }

        internal static string ColumnFKMatchesParentProperty(CslaObjectInfo parent, CslaObjectInfo info,
            IColumnInfo validatingColumn)
        {
            foreach (var prop in info.ParentProperties)
            {
                var parentPropertyFound = parent.GetAllValueProperties().Find(prop.Name);
                if (parentPropertyFound != null)
                {
                    var parentSchema = parentPropertyFound.DbBindColumn.SchemaName;
                    var parentTable = parentPropertyFound.DbBindColumn.ObjectName;
                    var parentColumn = parentPropertyFound.DbBindColumn.Column;
                    if (parentColumn != null)
                    {
                        if (validatingColumn.FKConstraint != null)
                        {
                            if (parentSchema == validatingColumn.FKConstraint.PKTable.ObjectSchema ||
                                parentTable == validatingColumn.FKConstraint.PKTable.ObjectName)
                            {
                                foreach (var pkColumn in validatingColumn.FKConstraint.Columns)
                                {
                                    if (pkColumn.PKColumn == parentColumn)
                                        return validatingColumn.FKConstraint.ConstraintTable.ObjectName + "." +
                                               validatingColumn.ColumnName;
                                }
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }

        public static string PropertyFKMatchesParentProperty(CslaObjectInfo parent, CslaObjectInfo info,
            ValueProperty prop)
        {
            return ColumnFKMatchesParentProperty(parent, info, prop.DbBindColumn.Column);
        }

        public static bool MultiplePropertyFKMatchesParent(CslaObjectInfo parent, CslaObjectInfo info,
            ValueProperty prop)
        {
            return MultipleColumnFKMatchesParent(parent, info, prop.DbBindColumn.Column);
        }

        internal static bool MultipleColumnFKMatchesParent(CslaObjectInfo parent, CslaObjectInfo info,
            IColumnInfo validatingColumn)
        {
            foreach (var prop in info.ParentProperties)
            {
                var parentPropertyFound = parent.GetAllValueProperties().Find(prop.Name);
                if (parentPropertyFound != null)
                {
                    var parentSchema = parentPropertyFound.DbBindColumn.SchemaName;
                    var parentTable = parentPropertyFound.DbBindColumn.ObjectName;
                    var parentColumn = parentPropertyFound.DbBindColumn.Column;
                    if (parentColumn != null)
                    {
                        if (validatingColumn.FKConstraint != null)
                        {
                            if (parentSchema == validatingColumn.FKConstraint.PKTable.ObjectSchema ||
                                parentTable == validatingColumn.FKConstraint.PKTable.ObjectName)
                            {
                                foreach (var pkColumn in validatingColumn.FKConstraint.Columns)
                                {
                                    if (pkColumn.PKColumn == parentColumn)
                                    {
                                        var matchCounter =
                                            CountMatchingInfoColumns(validatingColumn.FKConstraint.ConstraintTable,
                                                parentSchema, parentTable, parentColumn);
                                        return matchCounter > 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        private static int CountMatchingInfoColumns(ITableInfo infoTable, string parentSchema, string parentTable,
            IColumnInfo parentColumn)
        {
            var matchCounter = 0;
            foreach (var infoColumn in infoTable.Columns)
            {
                if (infoColumn.FKConstraint != null)
                {
                    if (parentSchema == infoColumn.FKConstraint.PKTable.ObjectSchema ||
                        parentTable == infoColumn.FKConstraint.PKTable.ObjectName)
                    {
                        foreach (var columnPair in infoColumn.FKConstraint.Columns)
                        {
                            if (columnPair.PKColumn == parentColumn)
                                matchCounter++;
                        }
                    }
                }
            }

            return matchCounter;
        }

        public static string GetFkParameterNameForParentProperty(CslaObjectInfo info, ValueProperty parentProperty)
        {
            var parameterName = GetFkColumnNameForParentProperty(info, parentProperty);
            if (parameterName == string.Empty)
                parameterName = parentProperty.ParameterName;

            return parameterName;
        }

        private static string GetFkColumnNameForParentProperty(CslaObjectInfo info, ValueProperty parentProperty)
        {
            var parentSchema = parentProperty.DbBindColumn.SchemaName;
            var parentTable = parentProperty.DbBindColumn.ObjectName;
            var parentColumn = parentProperty.DbBindColumn.Column;

            var objectTables = new List<IResultObject>();
            var tableNames = new List<string>();
            foreach (var property in info.ValueProperties)
            {
                if (property.DbBindColumn != null)
                {
                    var table = property.DbBindColumn.DatabaseObject as IResultObject;
                    if (table != null &&  !tableNames.Contains(table.ObjectName))
                    {
                        objectTables.Add(table);
                        tableNames.Add(table.ObjectName);
                    }
                }
            }

            foreach (var table in objectTables)
            {
                foreach (var column in table.Columns)
                {
                    if (column.FKConstraint != null)
                    {
                        if (parentSchema == column.FKConstraint.PKTable.ObjectSchema ||
                            parentTable == column.FKConstraint.PKTable.ObjectName)
                        {
                            foreach (var pkColumn in column.FKConstraint.Columns)
                            {
                                if (pkColumn.PKColumn == parentColumn)
                                {
                                    // if it's the same column name, use the parameter name
                                    if (pkColumn.PKColumn.ColumnName == column.ColumnName)
                                        return string.Empty;

                                    return column.ColumnName;
                                }
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }

        #endregion

        #region SimpleAudit

        public static bool UseSimpleAuditTrail(this CslaObjectInfo info)
        {
            if (!string.IsNullOrEmpty(info.Parent.Params.CreationDateColumn) ||
                !string.IsNullOrEmpty(info.Parent.Params.CreationUserColumn) ||
                !string.IsNullOrEmpty(info.Parent.Params.ChangedDateColumn) ||
                !string.IsNullOrEmpty(info.Parent.Params.ChangedUserColumn))
            {
                foreach (var valueProperty in info.GetAllValueProperties())
                {
                    if (valueProperty.Name == info.Parent.Params.CreationDateColumn ||
                        valueProperty.Name == info.Parent.Params.CreationUserColumn ||
                        valueProperty.Name == info.Parent.Params.ChangedDateColumn ||
                        valueProperty.Name == info.Parent.Params.ChangedUserColumn)
                        return true;
                }
            }
            return false;
        }

        public static bool IsCreationDateColumnPresent(this CslaObjectInfo info)
        {
            foreach (var valueProperty in info.GetAllValueProperties())
            {
                if (valueProperty.Name == info.Parent.Params.CreationDateColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsCreationUserColumnPresent(this CslaObjectInfo info)
        {
            foreach (var valueProperty in info.GetAllValueProperties())
            {
                if (valueProperty.Name == info.Parent.Params.CreationUserColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsChangedDateColumnPresent(this CslaObjectInfo info)
        {
            foreach (var valueProperty in info.GetAllValueProperties())
            {
                if (valueProperty.Name == info.Parent.Params.ChangedDateColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsChangedUserColumnPresent(this CslaObjectInfo info)
        {
            foreach (var valueProperty in info.GetAllValueProperties())
            {
                if (valueProperty.Name == info.Parent.Params.ChangedUserColumn)
                {
                    return true;
                }
            }
            return false;
        }

        public static string ConvertedPropertyName(CslaObjectInfo info, ValueProperty prop)
        {
            foreach (var convertProperty in info.ConvertValueProperties)
            {
                if (convertProperty.SourcePropertyName == prop.Name)
                    return convertProperty.Name;
            }

            return string.Empty;
        }

        #endregion

        #region DbProviders

        internal static string[] GetNamespaces()
        {
            if (DbProvider == null)
                return new[] {"System.Data.SqlClient"};

            return DbProvider.DBProviderNamespaces;
        }

        internal static string GetConnectionMethod()
        {
            if (DbProvider == null)
                return "SqlConnection";

            return DbProvider.ConnectionMethod;
        }

        internal static string GetCommandMethod()
        {
            if (DbProvider == null)
                return "SqlCommand";

            return DbProvider.CommandMethod;
        }

        internal static string GetAddParameterMethod()
        {
            if (DbProvider == null)
                return "AddWithValue";

            return DbProvider.AddParameterMethod;
        }

        internal static string GetDalNamespaceSuffix()
        {
            if (GenerationDbProvider == null)
                return string.Empty;

            return GenerationDbProvider.NamespaceSuffix;
        }

        internal static GenerationDbProvider GenerationDbProvider { get; private set; }

        internal static DbProvider DbProvider { get; private set; }

        internal static void SetDefaultDbProvider(GenerationParameters generationParams)
        {
            GenerationDbProvider = null;
            DbProvider = null;

            if (!generationParams.UseDal)
            {
                SetCurrentDbProvider(
                    GeneratorController.Current.CurrentUnit.GenerationParams.GenerationDbProviderCollection.GetActive());
            }
        }

        internal static void SetCurrentDbProvider(GenerationDbProvider generationDbProvider)
        {
            GenerationDbProvider = generationDbProvider;
            DbProvider = SetDbProviderFromGenerationDbProvider();
        }

        internal static DbProvider SetDbProviderFromGenerationDbProvider()
        {
            if (GenerationDbProvider != null)
            {
                foreach (var globalProvider in GeneratorController.Current.GlobalParameters.DbProviderCollection)
                {
                    if (globalProvider.DbProviderShortName == GenerationDbProvider.DBProviderShortName)
                        return globalProvider;
                }
            }
            return null;
        }

        #endregion
    }
}