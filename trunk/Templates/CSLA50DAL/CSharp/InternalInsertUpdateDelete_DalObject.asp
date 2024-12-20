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
    lastCriteria = "";
    useInlineQuery = false;
    if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.Always)
       useInlineQuery = true;
    else if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.SpecifyByObject)
    {
        foreach (string item in Info.GenerateInlineQueries)
        {
            if (item == "Create")
            {
                useInlineQuery = true;
                break;
            }
        }
    }
    string strInsertPK = string.Empty;
    string strInsertComment = string.Empty;
    string strInsertCommentResult = string.Empty;
    string strInsertResult = string.Empty;
    string strInsertParams = string.Empty;
    string strInsertParamsOutLess = string.Empty;
    bool hasInsertTimestamp = false;
    bool insertIsFirst = true;

    if (usesDTO)
    {
        strInsertResult = Info.ObjectName + "Dto";
        strInsertParams = strInsertResult + " " + FormatCamel(Info.ObjectName);
        strInsertParamsOutLess = strInsertResult + " " + FormatCamel(Info.ObjectName);
        lastCriteria = FormatCamel(Info.ObjectName);
        strInsertComment = System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(Info.ObjectName) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(Info.ObjectName) + " DTO.</param>";
        strInsertCommentResult = System.Environment.NewLine + new string(' ', 8) + "/// <returns>The new <see cref=\"" + strInsertResult + "\"/>.</returns>";
    }
    else
    {
        if (parentType.Length > 0)
        {
            foreach (ValueProperty parentProp in Info.GetParentValueProperties())
            {
                if (!parentProp.IsDatabaseBound)
                    continue;

                if (!insertIsFirst)
                {
                    strInsertParams += ", ";
                    strInsertParamsOutLess += ", ";
                    lastCriteria += ", ";
                }
                else
                    insertIsFirst = false;

                strInsertComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + ".</param>";
                strInsertParams += string.Concat(GetDataTypeGeneric(parentProp, parentProp.PropertyType), " ", FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)));
                strInsertParamsOutLess += string.Concat(GetDataTypeGeneric(parentProp, parentProp.PropertyType), " ", FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)));
                lastCriteria += FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp));
            }
        }
        foreach (ValueProperty prop in Info.GetAllValueProperties())
        {
            if (!prop.IsDatabaseBound)
                continue;

            if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
                strInsertPK = FormatCamel(prop.Name) + " = -1;" + Environment.NewLine + new string(' ', 12);

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
                {
                    strInsertParams += ", ";
                    strInsertParamsOutLess += ", ";
                    lastCriteria += ", ";
                }
                else
                    insertIsFirst = false;

                strInsertComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>";
                if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
                    strInsertParams += "out ";

                strInsertParams += string.Concat(GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)), " ", FormatCamel(prop.Name));
                strInsertParamsOutLess += string.Concat(GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)), " ", FormatCamel(prop.Name));
                lastCriteria += FormatCamel(prop.Name);
            }
        }
        if (hasInsertTimestamp)
            strInsertResult = "byte[]";
        else
            strInsertResult = "void";
    }
    if (isFirstMethod)
        isFirstMethod = false;
    else
        Response.Write(Environment.NewLine);

    if (useInlineQuery)
        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(Info.InsertProcedureName, strInsertParamsOutLess));
    %>
        /// <summary>
        /// Inserts a new <%= Info.ObjectName %> object in the database.
        /// </summary><%= strInsertComment %><%= strInsertCommentResult %>
        public <%= strInsertResult %> Insert(<%= strInsertParams %>)
        {
            <%= strInsertPK %><%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, Info.InsertProcedureName, useInlineQuery, lastCriteria) %>
                {
                    <%
            if (Info.CommandTimeout != string.Empty)
            {
                %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
            }
            %>cmd.CommandType = CommandType.<%= useInlineQuery ? "Text" : "StoredProcedure" %>;
                    <%
    if (parentType.Length > 0)
    {
        foreach (ValueProperty parentProp in Info.GetParentValueProperties())
        {
            if (!parentProp.IsDatabaseBound)
                continue;

            %>cmd.Parameters.<%= AddParameterMethod %>("@<%= TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp) %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + ".Parent_" + FormatPascal(parentProp.Name) : FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp))) %><%= (parentProp.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(parentProp) %>;
                    <%
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.IsDatabaseBound &&
            prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default ||
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.UpdateOnly)))
        {
            if (prop.DbBindColumn.NativeType == "timestamp")
            {
                %>cmd.Parameters.Add("@New<%= prop.ParameterName %>", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    <%
            }
            else
            {
                TypeCodeEx propType = TemplateHelper.GetBackingFieldType(prop);
                string postfix = string.Empty;
                if (prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
                    postfix = ".Direction = ParameterDirection.Output";
                else
                    postfix = ".DbType = DbType." + TemplateHelper.GetDbType(prop);

                if (AllowNull(prop) && propType == TypeCodeEx.Guid)
                {
                    %>cmd.Parameters.<%= AddParameterMethod %>("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %>.Equals(Guid.Empty) ? (object)DBNull.Value : <%= FormatCamel(prop.Name) %>)<%= postfix %>;
                    <%
                }
                else if (AllowNull(prop) && prop.PropertyType == TypeCodeEx.CustomType)
                {
                    %>// For nullable PropertyConvert, null is persisted if the backing field is zero
                    cmd.Parameters.<%= AddParameterMethod %>("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %> == 0 ? (object)DBNull.Value : <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %>)<%= postfix %>;
                    <%
                }
                else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
                {
                    %>cmd.Parameters.<%= AddParameterMethod %>("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %> == null ? (object)DBNull.Value : <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %><%= TemplateHelper.IsNullableType(propType) ? ".Value" :"" %>)<%= postfix %>;
                    <%
                }
                else
                {
                    %>cmd.Parameters.<%= AddParameterMethod %>("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %><%= (propType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>)<%= postfix %>;
                    <%
                }
            }
        }
    }
    %>var args = new DalHookArgs(cmd)<%= usesDTO ? " { DtoArg = " + FormatCamel(Info.ObjectName) + " }" : "" %>;
                    OnInsertPre(args);
                    cmd.ExecuteNonQuery();
                    <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if ((prop.IsDatabaseBound &&
            //prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            //(prop.DbBindColumn.IsPrimaryKey &&
            prop.PrimaryKey == ValueProperty.UserDefinedKeyBehaviour.DBProvidedPK)
			|| prop.OutputParameter == ValueProperty.OutputParameterBehaviour.InsertOnly
			|| prop.OutputParameter == ValueProperty.OutputParameterBehaviour.InsertAndUpdate)
        {
            if (!String.IsNullOrEmpty(prop.OutputParameterFunction))
			{
			%>
                    <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %> = <%= prop.OutputParameterFunction.Replace("{val}", "cmd.Parameters[\"" + prop.ParameterName + "\"].Value") %>;
                    <%
			}
			else
			{
			%>
                    <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %> = (<%= GetLanguageVariableType(prop.DbBindColumn.DataType) %>)cmd.Parameters["@<%= prop.ParameterName %>"].Value;
                    <%
			}
        }
    }
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.IsDatabaseBound &&
            prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            prop.DbBindColumn.NativeType == "timestamp")
        {
            %>
                    <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) + " = ": "return ") %>(byte[])cmd.Parameters["@New<%= prop.ParameterName %>"].Value;
<%
        }
    }
    %>
                    args = new DalHookArgs(cmd)<%= usesDTO ? " { DtoArg = " + FormatCamel(Info.ObjectName) + " }" : "" %>;
                    OnInsertPost(args);
                }
            }
            <%
    if (usesDTO)
    {
        %>
            return <%= FormatCamel(Info.ObjectName) %>;
        <%
    }
    %>
        }
    <%
}

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalUpdate)
{
    lastCriteria = "";
    useInlineQuery = false;
    if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.Always)
        useInlineQuery = true;
    else if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.SpecifyByObject)
    {
        foreach (string item in Info.GenerateInlineQueries)
        {
            if (item == "Update")
            {
                useInlineQuery = true;
                break;
            }
        }
    }
    string strUpdateComment = string.Empty;
    string strUpdateResult = string.Empty;
    string strUpdateCommentResult = string.Empty;
    string strUpdateParams = string.Empty;
    bool hasUpdateTimestamp = false;
    bool updateIsFirst = true;

    if (usesDTO)
    {
        strUpdateResult = Info.ObjectName + "Dto";
        strUpdateParams = strUpdateResult + " " + FormatCamel(Info.ObjectName);
        lastCriteria = FormatCamel(Info.ObjectName);
        strUpdateComment = System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(Info.ObjectName) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(Info.ObjectName) + " DTO.</param>";
        strUpdateCommentResult = System.Environment.NewLine + new string(' ', 8) + "/// <returns>The updated <see cref=\"" + strUpdateResult + "\"/>.</returns>";
    }
    else
    {
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            foreach (ValueProperty parentProp in Info.GetParentValueProperties())
            {
                if (!parentProp.IsDatabaseBound)
                    continue;

                if (!updateIsFirst)
                {
                    strUpdateParams += ", ";
                    lastCriteria += ", ";
                }
                else
                    updateIsFirst = false;

                strUpdateComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + ".</param>";
                strUpdateParams += string.Concat(GetDataTypeGeneric(parentProp, parentProp.PropertyType), " ", FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)));
                lastCriteria += FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp));
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
                {
                    strUpdateParams += ", ";
                    lastCriteria += ", ";
                }
                else
                    updateIsFirst = false;

                strUpdateComment += System.Environment.NewLine + new string(' ', 8) + "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>";
                strUpdateParams += string.Concat(GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)), " ", FormatCamel(prop.Name));
                lastCriteria += FormatCamel(prop.Name);
            }
        }
        if (hasUpdateTimestamp)
            strUpdateResult = "byte[]";
        else
            strUpdateResult = "void";
    }
    if (isFirstMethod)
        isFirstMethod = false;
    else
        Response.Write(Environment.NewLine);

    if (useInlineQuery)
        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(Info.UpdateProcedureName, strUpdateParams));
    %>
        /// <summary>
        /// Updates in the database all changes made to the <%= Info.ObjectName %> object.
        /// </summary><%= strUpdateComment %><%= strUpdateCommentResult %>
        public <%= strUpdateResult %> Update(<%= strUpdateParams %>)
        {
            <%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, Info.UpdateProcedureName, useInlineQuery, lastCriteria) %>
                {
                    <%
            if (Info.CommandTimeout != string.Empty)
            {
                %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
                    <%
            }
            %>cmd.CommandType = CommandType.<%= useInlineQuery ? "Text" : "StoredProcedure" %>;
                    <%
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (ValueProperty parentProp in Info.GetParentValueProperties())
        {
            if (!parentProp.IsDatabaseBound)
                continue;

            %>cmd.Parameters.<%= AddParameterMethod %>("@<%= TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp) %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + ".Parent_" + FormatPascal(parentProp.Name) : FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp))) %><%= (parentProp.PropertyType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>).DbType = DbType.<%= TemplateHelper.GetDbType(parentProp) %>;
                    <%
        }
    }

    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.IsDatabaseBound &&
            prop.DbBindColumn.ColumnOriginType != ColumnOriginType.None &&
            (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default ||
            prop.DbBindColumn.NativeType == "timestamp" ||
            (prop.DataAccess != ValueProperty.DataAccessBehaviour.ReadOnly &&
            prop.DataAccess != ValueProperty.DataAccessBehaviour.CreateOnly)))
        {
            TypeCodeEx propType = TemplateHelper.GetBackingFieldType(prop);
            string postfix = ".DbType = DbType." + TemplateHelper.GetDbType(prop);

            if (AllowNull(prop) && propType == TypeCodeEx.Guid)
            {
                %>cmd.Parameters.<%= AddParameterMethod %>("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %>.Equals(Guid.Empty) ? (object)DBNull.Value : <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %>)<%= postfix %>;
                    <%
            }
            else if (AllowNull(prop) && prop.PropertyType == TypeCodeEx.CustomType)
            {
                %>// For nullable PropertyConvert, null is persisted if the backing field is zero
                    cmd.Parameters.<%= AddParameterMethod %>("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %> == 0 ? (object)DBNull.Value : <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %>)<%= postfix %>;
                    <%
            }
            else if (AllowNull(prop) && propType != TypeCodeEx.SmartDate)
            {
                %>cmd.Parameters.<%= AddParameterMethod %>("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %> == null ? (object)DBNull.Value : <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %><%= TemplateHelper.IsNullableType(propType) ? ".Value" :"" %>)<%= postfix %>;
                    <%
            }
            else
            {
                %>cmd.Parameters.<%= AddParameterMethod %>("@<%= prop.ParameterName %>", <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %><%= (propType == TypeCodeEx.SmartDate ? ".DBValue" : "") %>)<%= postfix %>;
                    <%
            }
            if (prop.DbBindColumn.NativeType == "timestamp")
            {
                %>cmd.Parameters.Add("@New<%= prop.ParameterName %>", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                    <%
            }
        }
    }
    %>
var args = new DalHookArgs(cmd)<%= usesDTO ? " { DtoArg = " + FormatCamel(Info.ObjectName) + " }" : "" %>;
                    OnUpdatePre(args);
                    cmd.ExecuteNonQuery();
                    <%
    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (prop.IsDatabaseBound &&
            (prop.OutputParameter == ValueProperty.OutputParameterBehaviour.UpdateOnly
            || prop.OutputParameter == ValueProperty.OutputParameterBehaviour.InsertAndUpdate))
        {
            if (!String.IsNullOrEmpty(prop.OutputParameterFunction))
            {
            %>
                    <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %> = <%= prop.OutputParameterFunction.Replace("{val}", "cmd.Parameters[\"" + prop.ParameterName + "\"].Value") %>;
                    <%
            }
            else
            {
            %>
                    <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) : FormatCamel(prop.Name)) %> = (<%= GetLanguageVariableType(prop.DbBindColumn.DataType) %>)cmd.Parameters["@<%= prop.ParameterName %>"].Value;
                    <%
            }
        }
    }

    foreach (ValueProperty prop in Info.GetAllValueProperties())
    {
        if (!prop.IsDatabaseBound)
            continue;

        if (prop.DbBindColumn.NativeType == "timestamp")
        {
            Response.Write(Environment.NewLine);
            %>
                    <%= (usesDTO ? FormatCamel(Info.ObjectName) + "." + FormatPascal(prop.Name) + " = ": "return ") %>(byte[])cmd.Parameters["@New<%= prop.ParameterName %>"].Value;
<%
        }
    }
    %>
                    args = new DalHookArgs(cmd)<%= usesDTO ? " { DtoArg = " + FormatCamel(Info.ObjectName) + " }" : "" %>;
                    OnUpdatePost(args);
                }
            }
            <%
    if (usesDTO)
    {
        %>
            return <%= FormatCamel(Info.ObjectName) %>;
        <%
    }
    %>
        }
    <%
}

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

if (Info.GenerateDataPortalDelete)
{
    lastCriteria = "";
    useInlineQuery = false;
    if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.Always)
        useInlineQuery = true;
    else if (CurrentUnit.GenerationParams.UseInlineQueries == UseInlineQueries.SpecifyByObject)
    {
        foreach (string item in Info.GenerateInlineQueries)
        {
            if (item == "Delete")
            {
                useInlineQuery = true;
                break;
            }
        }
    }
    string strDeleteCritParams = string.Empty;
    string strDeleteComment = string.Empty;
    bool deleteIsFirst = true;
    int hookArgCounter = 0;

    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (ValueProperty parentProp in Info.GetParentValueProperties())
        {
            if (!parentProp.IsDatabaseBound)
                continue;

            if (!deleteIsFirst)
            {
                strDeleteCritParams += ", ";
                lastCriteria += ", ";
            }
            else
                deleteIsFirst = false;

            strDeleteComment += "/// <param name=\"" + FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + "\">The parent " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strDeleteCritParams += string.Concat(GetDataTypeGeneric(parentProp, parentProp.PropertyType), " ", FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)));
            lastCriteria += FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp));
            hookArgCounter++;
        }
    }
    foreach (ValueProperty prop in Info.ValueProperties)
    {
        if (!prop.IsDatabaseBound)
            continue;

        if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            if (!deleteIsFirst)
            {
                strDeleteCritParams += ", ";
                lastCriteria += ", ";
            }
            else
                deleteIsFirst = false;

            strDeleteComment += "/// <param name=\"" + FormatCamel(prop.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(prop.Name) + ".</param>" + System.Environment.NewLine + new string(' ', 8);
            strDeleteCritParams += string.Concat(GetDataTypeGeneric(prop, TemplateHelper.GetBackingFieldType(prop)), " ", FormatCamel(prop.Name));
            lastCriteria += FormatCamel(prop.Name);
            hookArgCounter++;
        }
    }
    if (isFirstMethod)
        isFirstMethod = false;
    else
        Response.Write(Environment.NewLine);

    if (useInlineQuery)
        InlineQueryList.Add(new AdvancedGenerator.InlineQuery(Info.DeleteProcedureName, strDeleteCritParams));
    %>
        /// <summary>
        /// Deletes the <%= Info.ObjectName %> object from database.
        /// </summary>
        <%= strDeleteComment %>public void Delete(<%= strDeleteCritParams %>)
        {
            <%= GetConnection(Info, false) %>
            {
                <%= GetCommand(Info, Info.DeleteProcedureName, useInlineQuery, lastCriteria) %>
                {
                    <%
    if (Info.CommandTimeout != string.Empty)
    {
        %>cmd.CommandTimeout = <%= Info.CommandTimeout %>;
            <%
    }
    %>cmd.CommandType = CommandType.<%= useInlineQuery ? "Text" : "StoredProcedure" %>;
                    <%
    if (parentType.Length > 0 && !Info.ParentInsertOnly)
    {
        foreach (ValueProperty parentProp in Info.GetParentValueProperties())
        {
            if (!parentProp.IsDatabaseBound)
                continue;

    %>cmd.Parameters.<%= AddParameterMethod %>("@<%= TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp) %>", <%= FormatCamel(TemplateHelper.GetFkParameterNameForParentProperty(Info, parentProp)) %>).DbType = DbType.<%= TemplateHelper.GetDbType(parentProp) %>;
                    <%
        }
    }
    foreach (ValueProperty prop in Info.ValueProperties)
    {
        if (!prop.IsDatabaseBound)
            continue;

        if (prop.PrimaryKey != ValueProperty.UserDefinedKeyBehaviour.Default)
        {
            %>cmd.Parameters.<%= AddParameterMethod %>("@<%= prop.ParameterName %>", <%= FormatCamel(prop.Name) %>).DbType = DbType.<%= TemplateHelper.GetDbType(prop) %>;
                    <%
        }
    }
    string hookArgs = string.Empty;
    if (hookArgCounter > 1)
    {
        if (parentType.Length > 0 && !Info.ParentInsertOnly)
        {
            hookArgs = HookMultipleParameters(Info.GetParentValueProperties(), Info.ValueProperties);
        }
        else
        {
            hookArgs = HookMultipleParameters(null, Info.ValueProperties);
        }
    }
    else if (hookArgCounter > 0)
    {
        hookArgs = HookSingleParameterKey(Info.ValueProperties);
    }
    %>var args = new DalHookArgs(cmd, <%= hookArgs %>);
                    OnDeletePre(args);
                    cmd.ExecuteNonQuery();
                    OnDeletePost(args);
                }
            }
        }
    <%
}
%>
