using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class GeneralUtilities {

    public static String GetQueryString(System.Collections.Specialized.NameValueCollection queries, String varname) {
        try {
            if (String.IsNullOrEmpty(queries[varname])) return null;
            else return queries[varname];
        } catch (Exception) { return null; }
    }
}