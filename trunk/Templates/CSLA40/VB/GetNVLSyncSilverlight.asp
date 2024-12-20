<%
if (Info.SimpleCacheOptions != SimpleCacheResults.None)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.GetOptions.Factory)
        {
            %>

        ''' <summary>
        ''' Factory method. Loads a <see cref="<%= Info.ObjectName %>"/> object.
        ''' </summary>
        <%
            string crit = string.Empty;
            for (int i = 0; i < c.Properties.Count; i++)
            {
                if (string.IsNullOrEmpty(c.Properties[i].ParameterValue))
                {
                    Errors.Append("Property: " + c.Properties[i].Name + " on criteria: " + c.Name + " must have a ParameterValue. Add it or remove the Criteria Property." + Environment.NewLine);
                    return;
                }
                else
                {
                    c.Properties[i].ReadOnly = true;
                }
            }
            if (c.Properties.Count > 1)
                crit = "New " + c.Name + "()";
            else if (c.Properties.Count > 0)
                crit = SendSingleCriteria(c, c.Properties[0].ParameterValue);
            %>
        ''' <returns>A reference to the fetched <see cref="<%= Info.ObjectName %>"/> object.</returns>
        Public Shared Function Get<%= Info.ObjectName %><%= c.GetOptions.FactorySuffix %>() As <%= Info.ObjectName %>
            <%
            if (CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.None &&
                CurrentUnit.GenerationParams.GenerateAuthorization != AuthorizationLevel.PropertyLevel &&
                Info.GetRoles.Trim() != String.Empty)
            {
                %>If Not CanGetObject() Then
                Throw new System.Security.SecurityException("User not authorized to load a <%= Info.ObjectName %>.")
            End If

            <%
            }
                %>If _list IsNot Nothing Then
                Return _list
            End If

            Return New <%= Info.ObjectName %>()
        End Function
<%
        }
    }
}
%>
