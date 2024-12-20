<%
string parentType = Info.ParentType;
if (parentInfo == null)
    parentType = "";
else if (parentInfo.IsEditableChildCollection())
    parentType = parentInfo.ParentType;
else if (parentInfo.IsEditableRootCollection())
    parentType = "";
else if (parentInfo.IsDynamicEditableRootCollection())
    parentType = "";

if (Info.GenerateDataPortalInsert)
{
    if (usesDTO)
    {
        if (isFirstMethod)
            isFirstMethod = false;
        else
            Response.Write(Environment.NewLine);

            %>
        /// <summary>
        /// Inserts a new <%= Info.ObjectName %> object in the database.
        /// </summary>
        /// <param name="<%= FormatCamel(Info.ObjectName) %>">The <%= PropertyHelper.SplitOnCaps(FormatPascal(Info.ObjectName)) %> DTO.</param>
        /// <returns>The new <see cref="<%= Info.ObjectName %>Dto"/>.</returns>
        <%= Info.ObjectName %>Dto Insert(<%= Info.ObjectName %>Dto <%= FormatCamel(Info.ObjectName) %>);
        <%
    }
    else
    {
        string strInsertComment = string.Empty;
        string strInsertCommentResult = string.Empty;
        string strInsertParams = string.Empty;
        bool hasInsertTimestamp = false;
        bool insertIsFirst = true;

        if (parentType.Length > 0)
        {
            foreach (ValueProperty parentProp in Info.GetParentValueProperties())
            {
                if (!parentProp.IsDatabaseBound)
                    continue;

                if (!insertIsFirst)
                    strInsertParams += ", ";
                else
                    insertIsFirst = false;

                strInsertComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + ".</param>";
                strInsertParams += string.Concat(GetDataTypeGeneric(parentProp, parentProp.PropertyType), " ", FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)));
            }
        }
        foreach (ValueProperty prop in Info.GetAllValueProperties())
        {
            if (!prop.IsDatabaseBound)
                continue;

            if (prop.DbBindColumn.NativeType == "timestamp")
            {
                hasInsertTimestamp = true;
                strInsertCommentResult = System.Environment.NewLine + new string(' ', 8) + "/// <returns>The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + " of the new " + Info.ObjectName + ".</returns>";
            }
            if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
                prop.DbBindColumn.NativeType != "timestamp" &&
                (prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly || prop.DbBindColumn.NativeType == "timestamp"))
            {
                if (!insertIsFirst)
                    strInsertParams += ", ";
                else
                    insertIsFirst = false;

                strInsertComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>";
                if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
                    strInsertParams += "out ";

                strInsertParams += string.Concat(GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)), " ", FormatCamel(prop.Name));
            }
        }
        if (isFirstMethod)
            isFirstMethod = false;
        else
            Response.Write(Environment.NewLine);

        %>
        /// <summary>
        /// Inserts a new <%= Info.ObjectName %> object in the database.
        /// </summary><%= strInsertComment %><%= strInsertCommentResult %>
        <%= hasInsertTimestamp ? "byte[]" : "void" %> Insert(<%= strInsertParams %>);
        <%
    }
}

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalUpdate)
{
    if (usesDTO)
    {
        if (isFirstMethod)
            isFirstMethod = false;
        else
            Response.Write(Environment.NewLine);

        %>
        /// <summary>
        /// Updates in the database all changes made to the <%= Info.ObjectName %> object.
        /// </summary>
        /// <param name="<%= FormatCamel(Info.ObjectName) %>">The <%= PropertyHelper.SplitOnCaps(FormatPascal(Info.ObjectName)) %> DTO.</param>
        /// <returns>The updated <see cref="<%= Info.ObjectName %>Dto"/>.</returns>
        <%= Info.ObjectName %>Dto Update(<%= Info.ObjectName %>Dto <%= FormatCamel(Info.ObjectName) %>);
        <%
    }
    else
    {
        string strUpdateComment = string.Empty;
        string strUpdateCommentResult = string.Empty;
        string strUpdateParams = string.Empty;
        bool hasUpdateTimestamp = false;
        bool updateIsFirst = true;

        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            foreach (ValueProperty parentProp in Info.GetParentValueProperties())
            {
                if (!parentProp.IsDatabaseBound)
                    continue;

                if (!updateIsFirst)
                    strUpdateParams += ", ";
                else
                    updateIsFirst = false;

                strUpdateComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + ".</param>";
                strUpdateParams += string.Concat(GetDataTypeGeneric(parentProp, parentProp.PropertyType), " ", FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)));
            }
        }
        foreach (ValueProperty prop in Info.GetAllValueProperties())
        {
            if (!prop.IsDatabaseBound)
                continue;

            if (prop.DbBindColumn.NativeType == "timestamp")
            {
                hasUpdateTimestamp = true;
                strUpdateCommentResult = System.Environment.NewLine + new string(' ', 8) + "/// <returns>The updated " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</returns>";
            }

            if (prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
                prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
                (prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly ||
                (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK ||
                prop.DataAccess == ValueProperty.DataAccessBehaviour.UpdateOnly)) ||
                prop.DbBindColumn.NativeType == "timestamp")
            {
                if (!updateIsFirst)
                    strUpdateParams += ", ";
                else
                    updateIsFirst = false;

                strUpdateComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>";
                strUpdateParams += string.Concat(GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)), " ", FormatCamel(prop.Name));
            }
        }
        if (isFirstMethod)
            isFirstMethod = false;
        else
            Response.Write(Environment.NewLine);

        %>
        /// <summary>
        /// Updates in the database all changes made to the <%= Info.ObjectName %> object.
        /// </summary><%= strUpdateComment %><%= strUpdateCommentResult %>
        <%= hasUpdateTimestamp ? "byte[]" : "void" %> Update(<%= strUpdateParams %>);
        <%
    }
}

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalDelete)
{
    string strDeleteCritParams = string.Empty;
    string strDeleteComment = string.Empty;
    bool deleteIsFirst = true;

    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (ValueProperty parentProp in Info.GetParentValueProperties())
        {
            if (!parentProp.IsDatabaseBound)
                continue;

            if (!deleteIsFirst)
                strDeleteCritParams += ", ";
            else
                deleteIsFirst = false;

            strDeleteComment += "/// <param name=\"" + FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strDeleteCritParams += string.Concat(GetDataTypeGeneric(parentProp, parentProp.PropertyType), " ", FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)));
        }
    }
    foreach (ValueProperty prop in Info.ValueProperties)
    {
        if (!prop.IsDatabaseBound)
            continue;

        if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            if (!deleteIsFirst)
                strDeleteCritParams += ", ";
            else
                deleteIsFirst = false;

            strDeleteCritParams += string.Concat(GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)), " ", FormatCamel(prop.Name));
            strDeleteComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
        }
    }
    if (isFirstMethod)
        isFirstMethod = false;
    else
        Response.Write(Environment.NewLine);

    %>
        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        <%= strDeleteComment %>void Delete(<%= strDeleteCritParams %>);
        <%
}
%>
