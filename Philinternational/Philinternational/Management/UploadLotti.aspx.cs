using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Philinternational.Layers;

namespace Philinternational.Management {
    public partial class UploadLotti : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            TextBox1.Text = @"D:\PROGETTI\DOTNET\philinternational\Philinternational\Philinternational\Documentation\Gestione Lotti.txt";
        }

        protected void Button1_Click(object sender, EventArgs e) {
            String Path = TextBox1.Text;
            Int32 i = 0;
            LottiGateway.TruncateAll();
            StreamReader rd = File.OpenText(@TextBox1.Text);
            while (!rd.EndOfStream) {
                List<String> list = new List<string>();
                String[] line = rd.ReadLine().Split(';');

                list.Add(line[1]);
                list.Add(line[2]);
                list.Add(line[3]);
                list.Add(line[11]);
                list.Add(line[13]);
                list.Add(line[14]);
                list.Add(line[29]);
                list.Add(line[39]);
                list.Add(line[40]);

                if (i != 0) LottiGateway.InsertLotto(list);
                i++;
            }
        }
    }
}