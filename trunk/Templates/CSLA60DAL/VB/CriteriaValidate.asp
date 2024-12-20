<%
bool isCollection2 =
    Info.IsEditableChildCollection() ||
    Info.IsReadOnlyCollection();

bool isSelfLoadCollection =
    (Info.IsEditableChildCollection() ||
    Info.IsReadOnlyCollection()) &&
    IsChildSelfLoaded(Info);
bool isSelfLoad = IsChildSelfLoaded(Info);
bool createOptionsFactory;
bool createOptionsDataPortal;
bool createOptionsRunLocal;
bool getOptionsFactory = false;
bool getOptionsDataPortal;
bool deleteOptionsFactory;
bool deleteOptionsDataPortal;

foreach (Criteria crit in Info.CriteriaObjects)
{
    foreach (CriteriaProperty criteriaProperty in crit.Properties)
    {
        if (criteriaProperty.DbBindColumn.Column == null)
        {
            Warnings.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": property " + criteriaProperty.Name + " is missing DB Bind Column." + Environment.NewLine);
        }
    }
    getOptionsFactory = getOptionsFactory | crit.GetOptions.Factory;
}
if (isSelfLoad)
{
    if (!getOptionsFactory)
    {
        //Errors.Append("Object " + Info.ObjectName + " is missing get criteria; to \"SelfLoad\" an object, that object must have a criteria with GetOptions.Factory set." + Environment.NewLine);
        Warnings.Append("Object " + Info.ObjectName + " is missing get criteria; to \"SelfLoad\" an object, that object must have a criteria with GetOptions.Factory set." + Environment.NewLine);
        return;
    }
}
getOptionsFactory = false;

if (Info.IsEditableRoot() || (Info.IsReadOnlyObject() && Info.ParentType == string.Empty))
{
    foreach (Criteria crit in Info.CriteriaObjects)
    {
        getOptionsFactory = getOptionsFactory | crit.GetOptions.Factory;
    }

    if (!getOptionsFactory)
    {
        Warnings.Append(Info.ObjectName + "; root objects must have a criteria with GetOptions.Factory set." + Environment.NewLine);
    }
}
else
{
    foreach (Criteria crit in Info.CriteriaObjects)
    {
        createOptionsFactory = crit.CreateOptions.Factory;
        createOptionsDataPortal = crit.CreateOptions.DataPortal;
        createOptionsRunLocal = crit.CreateOptions.RunLocal;
        getOptionsFactory = crit.GetOptions.Factory;
        getOptionsDataPortal = crit.GetOptions.DataPortal;
        deleteOptionsFactory = crit.DeleteOptions.Factory;
        deleteOptionsDataPortal = crit.DeleteOptions.DataPortal;

        if (isCollection2)
        {
            // only get criteria
            if (createOptionsFactory || createOptionsDataPortal)
            {
                Warnings.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": all Create options should be \"False\" or empty." + Environment.NewLine);
            }
            if (deleteOptionsFactory || deleteOptionsDataPortal)
            {
                Warnings.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": all Delete options should be \"False\" or empty." + Environment.NewLine);
            }

            // not even get?
            if (!isSelfLoadCollection && Info.ParentType != string.Empty)
            {
                if (getOptionsFactory || getOptionsDataPortal)
                {
                    Warnings.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": all Get options should be \"False\" or empty." + Environment.NewLine);
                }
            }
        }
        else if (Info.IsEditableRootCollection() ||
            Info.IsDynamicEditableRootCollection())
        {
            if (!createOptionsFactory)
            {
                Warnings.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": Create option Factory should be \"True\"." + Environment.NewLine);
            }
            if (!createOptionsDataPortal)
            {
                Warnings.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": Create option DataPortal should be \"True\"." + Environment.NewLine);
            }
            if (!createOptionsRunLocal)
            {
                Warnings.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": Create option RunLocal should be \"True\"." + Environment.NewLine);
            }
            if (deleteOptionsFactory || deleteOptionsDataPortal)
            {
                Warnings.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": all Delete options should be \"False\" or empty." + Environment.NewLine);
            }
        }
        else if (!(Info.IsEditableRoot() ||
            Info.IsDynamicEditableRoot() ||
            Info.IsEditableChild() ||
            Info.IsEditableSwitchable() ||
            (Info.IsReadOnlyObject() && Info.ParentType == string.Empty)))
        {
            if (!isSelfLoad && (getOptionsFactory || getOptionsDataPortal))
            {
                Warnings.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": all Get options should be \"False\" or empty (neither a root object nor a SelfLoad object)." + Environment.NewLine);
            }
            if (deleteOptionsFactory || deleteOptionsDataPortal)
            {
                Warnings.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": Delete options " +
                    (deleteOptionsFactory ? " \"Factory\"" : "") +
                    ((deleteOptionsFactory && deleteOptionsDataPortal) ? " and" : "") +
                    (deleteOptionsDataPortal ? " \"DataPortal\"" : "") +
                    " should be set to \"False\"." +
                    Environment.NewLine);
                if (!(createOptionsFactory || createOptionsDataPortal || getOptionsFactory || getOptionsDataPortal) &&
                    crit.Properties.Count > 1)
                {
                    Warnings.Append("Useless \"" + crit.Name + "\" class will be generated as no other \"Factory\" or \"DataPortal\" options are set." + Environment.NewLine);
                }
            }
        }
        if (deleteOptionsDataPortal && crit.Properties.Count < 1)
        {
            Errors.Append("Criteria " + Info.ObjectName + "." + crit.Name + ": a Delete criteria needs at least one Criteria Property" + Environment.NewLine);
        }
    }
}
%>