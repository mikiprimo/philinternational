using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

public class GeneralUtilities {

    public static String GetQueryString(System.Collections.Specialized.NameValueCollection queries, String varname) {
        try {
            if (String.IsNullOrEmpty(queries[varname])) return null;
            else return queries[varname];
        } catch (Exception) { return null; }
    }

    public static String SubString(String stringa, Int32 length) {
        if (stringa.Length > length) return stringa.Substring(0, length);
        else return stringa;
    }

    public static String Encrypt(String toBeEncrypted) {
        MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
        Byte[] hashedBytes;
        UTF8Encoding encoder = new UTF8Encoding();
        hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(toBeEncrypted));

        UnicodeEncoding uni = new UnicodeEncoding();
        String encodedOne = BitConverter.ToString(hashedBytes);
        encodedOne = encodedOne.Replace("-", "");
        return encodedOne;
    }
}