using System;
using System.Xml;
using System.Web.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using Philinternational.Layers;


namespace Philinternational{
    public partial class Sitemap : System.Web.UI.Page{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/xml";
        // uso la classe XmlTextWriter ed instanzio l’oggetto writer per formattare il risultato in XML
        using (XmlTextWriter writer = new XmlTextWriter(Response.OutputStream, Encoding.UTF8))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            // Apro la connessione al database, uso ms sql server express
            String SqlLotti = "SELECT p.descrizione capitolo, b.id_argomento idargomento,pa.descrizione paragrafo,b.idlotto idlotto from lotto b,paragrafo_argomento pa,paragrafo p WHERE b.id_argomento = pa.idargomento and pa.idparagrafo = p.idparagrafo and b.stato =1";
            String SqlParagrafo = "SELECT a.descrizione capitolo,b.idargomento idargomento,b.descrizione paragrafo FROM paragrafo a, paragrafo_argomento b where a.idparagrafo = b.idparagrafo and b.stato =1 ORDER BY a.idparagrafo";
            MySqlConnection conn = ConnectionGateway.ConnectDB();
            DataView dr = Layers.ConnectionGateway.SelectQuery(SqlLotti);
            // la home page è sempre la stessa
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", "http://www.philinternational.it/Default.aspx");
            // la data della home page la setto alla data attuale
            writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
            writer.WriteElementString("changefreq", "monthly");
            writer.WriteElementString("priority", "0.5");
            writer.WriteEndElement();
            //***************************************
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", "http://www.philinternational.it/Varie/chi-siamo.aspx");
            writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
            writer.WriteEndElement();
            //***************************************
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", "http://www.philinternational.it/Varie/contatti.aspx");
            writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
            writer.WriteEndElement();
            //***************************************
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", "http://www.philinternational.it/Varie/condizioniVendita.aspx");
            writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
            writer.WriteEndElement();
            //***************************************
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", "http://www.philinternational.it/Varie/dovesiamo.aspx");
            writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
            writer.WriteEndElement();
            //***************************************
            String newUrl = "";
            for (int i = 0; i < dr.Count; i++) {
                    String capitolo = dr[i]["capitolo"].ToString();
                    String paragrafo = dr[i]["paragrafo"].ToString();
                    //esempio -->ANTICHI-STATI/2/LOMBARDO-VENETO/lotto/4
                    newUrl = capitolo.Replace(" ","-") + "/" + dr[i]["idargomento"].ToString() + "/" + paragrafo.Replace(" ","-") + "/lotto/" + dr[i]["idlotto"].ToString();
                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", "http://www.philinternational.it/" + newUrl);
                    // data ultima modifica dell’articolo
                    writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
                    writer.WriteElementString("changefreq", "monthly");
                    writer.WriteElementString("priority", "0.5");
                    writer.WriteEndElement();
            }
            dr = Layers.ConnectionGateway.SelectQuery(SqlParagrafo);
            for (int i = 0; i < dr.Count; i++) {
                String capitolo = dr[i]["capitolo"].ToString();
                String paragrafo = dr[i]["paragrafo"].ToString();
                newUrl = capitolo.Replace(" ", "-") + "/" + dr[i]["idargomento"].ToString() + "/" + paragrafo.Replace(" ", "-");
                writer.WriteStartElement("url");
                writer.WriteElementString("loc", "http://www.philinternational.it/" + newUrl);
                // data ultima modifica dell’articolo
                writer.WriteElementString("lastmod", String.Format("{0:yyyy-MM-dd}", DateTime.Now));
                writer.WriteElementString("changefreq", "monthly");
                writer.WriteElementString("priority", "0.5");
                writer.WriteEndElement();
            }

            writer.WriteEndDocument();
            writer.Flush();
}
Response.End();
}
}
}
