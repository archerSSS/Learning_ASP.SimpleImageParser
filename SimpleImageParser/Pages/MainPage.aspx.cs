using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleImageParser.Pages
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        private void ParseImages()
        {
            string url = TextUrl.Text;

            try
            {
                using (HttpClientHandler handler = new HttpClientHandler() { AllowAutoRedirect = false, AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.None })
                {
                    using (var client = new HttpClient(handler))
                    {
                        using (HttpResponseMessage response = client.GetAsync(url).Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var html = response.Content.ReadAsStringAsync().Result;
                                if (!string.IsNullOrEmpty(html))
                                {
                                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                                    doc.LoadHtml(html);

                                    var imgs_url = doc.DocumentNode.Descendants("img");

                                    aspElements.Controls.Add(new TableRow());

                                    // Parsing
                                    if (imgs_url != null)
                                    {
                                        var mm = imgs_url.Select(el => el.GetAttributeValue("src", null));
                                        if (mm == null) return; 
                                        foreach (string s in mm)
                                        {
                                            if (!string.IsNullOrEmpty(s))
                                            {
                                                if (aspElements.Rows[aspElements.Rows.Count - 1].Cells.Count > 4)
                                                {
                                                    aspElements.Controls.Add(new TableRow());
                                                }

                                                TableRow tr = aspElements.Rows[aspElements.Rows.Count - 1];

                                                Image i = new Image();
                                                i.ImageUrl = s;

                                                TableCell tc = new TableCell();
                                                tc.Controls.Add(i);
                                                tr.Controls.Add(tc);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            ParseImages();
        }
    }
}