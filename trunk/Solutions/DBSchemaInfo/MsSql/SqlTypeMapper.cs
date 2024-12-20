using System;
using System.Data;

namespace DBSchemaInfo.MsSql
{
    internal class SqlTypeMapper
    {
        public static Type GetManagedType(SqlDbType sqlDbType)
        {
            switch (sqlDbType)
            {
                case SqlDbType.BigInt:
                    return typeof (Int64);
                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                    return typeof (byte[]);
                case SqlDbType.Bit:
                    return typeof (bool);
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                case SqlDbType.Xml:
                    return typeof (string);
                case SqlDbType.Time:
                    return typeof (TimeSpan);
                case SqlDbType.DateTimeOffset:
                    return typeof (DateTimeOffset);
                case SqlDbType.Date:
                case SqlDbType.DateTime2:
                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                    return typeof (DateTime);
                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return typeof (decimal);
                case SqlDbType.Float:
                    return typeof (double);
                case SqlDbType.Int:
                    return typeof (int);
                case SqlDbType.Real:
                    return typeof (Single);
                case SqlDbType.UniqueIdentifier:
                    return typeof (Guid);
                case SqlDbType.SmallInt:
                    return typeof (Int16);
                case SqlDbType.TinyInt:
                    return typeof (byte);
                case SqlDbType.Variant:
                case SqlDbType.Udt:
                default:
                    return typeof (object);
            }
        }

        public static DbType GetDbType(SqlDbType sqlDbType)
        {
            switch (sqlDbType)
            {
                case SqlDbType.BigInt:
                    return DbType.Int64;
                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.Timestamp:
                case SqlDbType.VarBinary:
                    return DbType.Binary;
                case SqlDbType.Bit:
                    return DbType.Boolean;
                case SqlDbType.Char:
                case SqlDbType.NChar:
                    return DbType.StringFixedLength;
                case SqlDbType.Xml:
                    return DbType.Xml;
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                    return DbType.String;
                case SqlDbType.Time:
                    return DbType.Time;
                case SqlDbType.Date:
                    return DbType.Date;
                case SqlDbType.DateTime2:
                    return DbType.DateTime2;
                case SqlDbType.DateTimeOffset:
                    return DbType.DateTimeOffset;
                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                    return DbType.DateTime;
                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    return DbType.Decimal;
                case SqlDbType.Float:
                    return DbType.Double;
                case SqlDbType.Int:
                    return DbType.Int32;
                case SqlDbType.Real:
                    return DbType.Single;
                case SqlDbType.UniqueIdentifier:
                    return DbType.Guid;
                case SqlDbType.SmallInt:
                    return DbType.Int16;
                case SqlDbType.TinyInt:
                    return DbType.Byte;
                case SqlDbType.Variant:
                case SqlDbType.Udt:
                default:
                    return DbType.Object;
            }
        }

        public static SqlDbType GetSqlDbType(string type)
        {
            var tempType = type;
            if (tempType == "numeric")
                tempType = "decimal";
            if (tempType == "sql_variant" || tempType == "table type")
                tempType = "variant";
            if (tempType == "geography")
                tempType = "varchar";
            if (tempType == "geometry")
                tempType = "varchar";
            if (tempType == "hierarchyid")
                tempType = "nvarchar";

            SqlDbType returnType;
            try
            {
                returnType = (SqlDbType)Enum.Parse(typeof(SqlDbType), tempType, true);

            }
            catch (Exception ex)
            {
                // handle any user defined types here
                returnType = SqlDbType.Udt;
            }

            return returnType;
        }

        public static string GetCondensedDataType(string nativeType, long columnLength, int columnScale)
        {
            if (nativeType == "numeric" || nativeType == "decimal")
                return nativeType + "(" + columnLength + ", " + columnScale + ")";

            if (columnLength == -1 && nativeType != "geography" && nativeType != "geometry" && nativeType != "xml")
                return nativeType + "(MAX)";

            if (nativeType == "binary" ||
                nativeType == "char" ||
                nativeType == "nchar" ||
                nativeType == "nvarchar" ||
                nativeType == "varbinary" ||
                nativeType == "varchar" ||
                nativeType == "time" ||
                nativeType == "datetime2" ||
                nativeType == "datetimeoffset")
                return nativeType + "(" + columnLength + ")";

            return nativeType;
        }
    }
}