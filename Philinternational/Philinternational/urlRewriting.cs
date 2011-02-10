using System;
using System.Web;
using System.Web.UI;
using System.IO;
public class urlRewriting : IHttpHandlerFactory
{

    public IHttpHandler GetHandler(HttpContext context, string requestType, string URL, string pathTranslated)
    {
        context.Items["fileName"] = Path.GetFileNameWithoutExtension(URL).ToLower();

        return PageParser.GetCompiledPageInstance(URL, context.Server.MapPath("elencoLotto.aspx"), context);
    }

    public void ReleaseHandler(IHttpHandler handler) { }
}