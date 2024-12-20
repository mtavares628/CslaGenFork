<%
CslaObjectInfo authzInfo = Info;
if (TypeHelper.IsCollectionType(Info.ObjectType))
{
    authzInfo = FindChildInfo(Info, Info.ItemType);
    if (authzInfo == null)
    {
        Errors.Append("Collection " + Info.ObjectName + " missing Item Type." + Environment.NewLine);
        return;
    }
}

if (!Info.UseCustomLoading && !Info.DataSetLoadingScheme)
{
    if ((Info.ParentType != string.Empty || isItem) && !isChildLazyLoaded && !isChildSelfLoaded)
    {
        %>

        /// <summary>
        <%
        if (usesDTO)
        {
            if (TypeHelper.IsCollectionType(Info.ObjectType))
            {
                %>
        /// Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> object from the given list of <%= Info.ItemType %>Dto.
        /// </summary>
        /// <param name="data">The list of <see cref="<%= Info.ItemType %>Dto"/>.</param>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(List<<%= Info.ItemType %>Dto> data)
        <%
            }
            else
            {
                %>
        /// Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> object from the given <%= Info.ObjectName %>Dto.
        /// </summary>
        /// <param name="data">The <see cref="<%= Info.ObjectName %>Dto"/>.</param>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(<%= Info.ObjectName %>Dto data)
        <%
            }
        }
        else
        {
            %>
        /// Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        internal static <%= Info.ObjectName %> Get<%= Info.ObjectName %>(SafeDataReader dr)
        <%
        }
        %>
        {
            <%
        if (authzInfo.GetRoles.Trim() != String.Empty &&
            TypeHelper.IsCollectionType(Info.ObjectType) &&
            CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
            CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel)
        {
            %>
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.");

            <%
        }
        %>
            <%= Info.ObjectName %> obj = new <%= Info.ObjectName %>();
            <%
        if (Info.IsEditableSwitchable() ||
            (Info.IsEditableChild() ||
            Info.IsEditableChildCollection()))
        {
            %>
            // show the framework that this is a child object
            obj.MarkAsChild();
            <%
        }
        %>
            obj.Fetch(<%= usesDTO ? "data" : "dr" %>);
            <%
        if (isChildSelfLoaded && !TypeHelper.IsCollectionType(Info.ObjectType))
        {
            %>
            obj.FetchChildren(dr);
            <%
        }
        else if (ancestorLoaderLevel > 0)
        {
            foreach (ChildProperty childProp in Info.GetCollectionChildProperties())
            {
                CslaObjectInfo _child = FindChildInfo(Info, childProp.TypeName);
                if (_child != null)
                {
                    if (childProp.LoadingScheme == LoadingScheme.ParentLoad)
                    {
                        string internalCreateString = string.Empty;
                        if (TypeHelper.IsEditableType(_child.ObjectType))
                        {
                            if (UseChildFactoryHelper)
                                internalCreateString = FormatPascal(childProp.TypeName) + ".New" + FormatPascal(childProp.TypeName);
                            else
                                internalCreateString = "DataPortal.CreateChild<" + FormatPascal(childProp.TypeName) + ">";
                        }
                        else
                            internalCreateString = "new " + childProp.TypeName;

                        if ((childProp.DeclarationMode == PropertyDeclaration.Managed ||
                            childProp.DeclarationMode == PropertyDeclaration.ManagedWithTypeConversion))
                        {
                            %>
            obj.LoadProperty(<%= FormatPropertyInfoName(childProp.Name) %>, <%= internalCreateString %>());
        <%
                        }
                        else
                        {
                            %>
            <%= bpcSpacer %>obj.<%= GetFieldLoaderStatement(childProp, internalCreateString + "()") %>;
        <%
                        }
                    }
                }
            }
        }
        if (Info.IsNotReadOnlyObject() && !TypeHelper.IsCollectionType(Info.ObjectType))
        {
            %>
            obj.MarkOld();
            <%
        }
        if (Info.CheckRulesOnFetch && !Info.EditOnDemand && !TypeHelper.IsCollectionType(Info.ObjectType))
        {
            %>
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            <%
        }
        %>
            return obj;
        }
    <%
    }
}
%>
