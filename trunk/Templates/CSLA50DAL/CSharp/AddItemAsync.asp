<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous || CurrentUnit.GenerationParams.SilverlightUsingServices)
{
    %>

        /// <summary>
        /// Asynchronously adds a new <see cref="<%= Info.ItemType %>"/> item to the collection.
        /// </summary>
<%
        string prmsAsync = string.Empty;
        string factoryParamsAsync = string.Empty;
        foreach (Property param in crit.Properties)
        {
            prmsAsync += string.Concat(", ", GetDataTypeGeneric(param, param.PropertyType), " ", FormatCamel(param.Name));
            factoryParamsAsync += string.Concat(", ", FormatCamel(param.Name));
        }
        if (factoryParamsAsync.Length > 1)
        {
            factoryParamsAsync = factoryParamsAsync.Substring(2);
            prmsAsync = prmsAsync.Substring(2);
        }
        for (int i = 0; i < crit.Properties.Count; i++)
        {
            %>
        /// <param name="<%= FormatCamel(crit.Properties[i].Name) %>">The <%= FormatProperty(crit.Properties[i].Name) %> of the object to be added.</param>
<%
        }
        %>
        public async Task<<%= Info.ItemType %>> AddAsync(<%= prmsAsync %>)
        {
        <%
        string newMethodNameAsync = "New" + Info.ItemType;
        if (itemInfo.IsEditableSwitchable())
        {
            newMethodNameAsync += "Child";
        }
        if (UseChildFactoryHelper)
        {
            %>
            var item = <%= Info.ItemType %>.<%= newMethodNameAsync %><%= crit.CreateOptions.FactorySuffix %>(<%= factoryParamsAsync %>);
            <%
        }
        else
        {
            %>
            var item = await DataPortal.Create<%= crit.CreateOptions.RunLocal ? "Child" : "" %>Async<<%= Info.ItemType %>>(<%= factoryParamsAsync %>);
            <%
        }
        %>
            Add(item);
            return item;
        }
        <%
}
%>
