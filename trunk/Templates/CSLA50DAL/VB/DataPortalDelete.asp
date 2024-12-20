<%
if (Info.GenerateDataPortalDelete)
{
    foreach (Criteria c in Info.CriteriaObjects)
    {
        if (c.DeleteOptions.DataPortal)
        {
            string strSelfDeleteCritParams = string.Empty;
            string strDeleteCritParams = string.Empty;
            string strDeleteInvokeParams = string.Empty;
            string strDeleteComment = string.Empty;
            bool deleteIsFirst = true;

            if (usesDTO)
            {
                foreach (CriteriaProperty p in c.Properties)
                {
                    if (!deleteIsFirst)
                    {
                        strSelfDeleteCritParams += ", ";
                        strDeleteCritParams += ", ";
                        strDeleteInvokeParams += ", ";
                        strDeleteComment += System.Environment.NewLine + new string(' ', 8);
                    }
                    else
                        deleteIsFirst = false;

                    strSelfDeleteCritParams += FormatGeneralParameter(Info, p, false, false, true);
                    strDeleteCritParams += p.Name;
                    strDeleteInvokeParams += FormatCamel(p.Name);
                }

                strDeleteComment += "/// <param name=\"" + (c.Properties.Count > 1 ? "crit" : HookSingleCriteria(c, "crit")) + "\">The delete criteria.</param>";

                if (Info.IsEditableSwitchable())
                {
                    strSelfDeleteCritParams = "false, " + strSelfDeleteCritParams;
                    strDeleteCritParams = "false, " + strDeleteCritParams;
                }
                if (c.Properties.Count > 1 || (Info.IsEditableSwitchable() && c.Properties.Count == 1))
                {
                    strSelfDeleteCritParams = "new " + c.Name + "(" + strSelfDeleteCritParams + ")";
                    strDeleteCritParams = "new " + c.Name + "(" + strDeleteCritParams + ")";
                    strDeleteInvokeParams = SendMultipleCriteria(c, "crit");
                }
                else if (c.Properties.Count > 0)
                {
                    strSelfDeleteCritParams = SendSingleCriteria(c, strSelfDeleteCritParams);
                    strDeleteCritParams = SendSingleCriteria(c, strDeleteCritParams);
                }
            }
            else
            {
                foreach (CriteriaProperty p in c.Properties)
                {
                    if (!deleteIsFirst)
                    {
                        strSelfDeleteCritParams += ", ";
                        strDeleteCritParams += ", ";
                        strDeleteInvokeParams += ", ";
                        strDeleteComment += System.Environment.NewLine + new string(' ', 8);
                    }
                    else
                        deleteIsFirst = false;

                    strSelfDeleteCritParams += FormatGeneralParameter(Info, p, false, false, true);
                    strDeleteCritParams += string.Concat(GetDataTypeGeneric(p, p.PropertyType), " ", FormatCamel(p.Name));
                    strDeleteInvokeParams += FormatCamel(p.Name);
                    strDeleteComment += "/// <param name=\"" + FormatCamel(p.Name) + "\">The " + CslaGenerator.Metadata.PropertyHelper.SplitOnCaps(p.Name) + ".</param>";
                }
            }
            %>

        /// <summary>
        /// Self deletes the <see cref="<%= Info.ObjectName %>"/> object.
        /// </summary>
        <%
            if (Info.TransactionType == TransactionType.EnterpriseServices)
            {
                %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
            }
            else if (Info.TransactionType == TransactionType.TransactionScope || Info.TransactionType == TransactionType.TransactionScope)
            {
                %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
            }
            if (Info.InsertUpdateRunLocal)
            {
                %>[RunLocal]
        <%
            }
            %>protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(<%= strSelfDeleteCritParams %>);
        }
        <%
            deleteIsFirst = true;

            if (usesDTO)
            {
                %>

        /// <summary>
        /// Deletes the <see cref="<%= Info.ObjectName %>"/> object from database.
        /// </summary>
        <%= strDeleteComment %>
        <%
                if (Info.TransactionType == TransactionType.EnterpriseServices)
                {
                    %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
                }
                else if (Info.TransactionType == TransactionType.TransactionScope)
                {
                    %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
                }
                if (c.DeleteOptions.RunLocal)
                {
                    %>[RunLocal]
        <%
                }
                if (c.Properties.Count > 1)
                {
                    %>private void DataPortal_Delete(<%= c.Name %> crit)<%
                }
                else
                {
                    %>private void DataPortal_Delete(<%= ReceiveSingleCriteria(c, "crit") %>)<%
                }
            }
            else
            {
                %>
        /// <summary>
        /// Deletes the <see cref="<%= Info.ObjectName %>"/> object from database.
        /// </summary>
        <%= strDeleteComment %>
        <%
                if (Info.TransactionType == TransactionType.EnterpriseServices)
                {
                    %>[Transactional(TransactionalTypes.EnterpriseServices)]
        <%
                }
                else if (Info.TransactionType == TransactionType.TransactionScope)
                {
                    %>[Transactional(TransactionalTypes.TransactionScope)]
        <%
                }
                if (c.DeleteOptions.RunLocal)
                {
                    %>[RunLocal]
        <%
                }
                %>private void DataPortal_Delete(<%= strDeleteCritParams %>)<%
            }
            %>
        {
            <%
            if (TemplateHelper.UseSimpleAuditTrail(Info))
            {
                %>// audit the object, just in case soft delete is used on this object
            SimpleAuditTrail();
            <%
            }
            %>using (var dalManager = DalFactory<%= GetDalNameDot(CurrentUnit) %>GetManager())
            {
                var args = new DataPortalHookArgs();
                <%
            if (Info.GetMyChildReadWriteProperties().Count > 0)
            {
                string ucpSpacer = new string(' ', 4);
                %>
<!-- #include file="UpdateChildProperties.asp" -->
                <%
            }
            %>
                OnDeletePre(args);
                var dal = dalManager.GetProvider<I<%= Info.ObjectName %>Dal>();
                using (BypassPropertyChecks)
                {
                    dal.Delete(<%= strDeleteInvokeParams %>);
                }
                OnDeletePost(args);
            }
        }
            <%
        }
    }
}
%>
