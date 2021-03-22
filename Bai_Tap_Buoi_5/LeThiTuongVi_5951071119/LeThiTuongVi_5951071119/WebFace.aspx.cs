using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeThiTuongVi_5951071119
{
    public partial class WebFace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var request = WebRequest.Create("https://graph.facebook.com/utc2hcmc/posts?access_token=EAAAAZAw4FxQIBAKC0z01ZBh8wTDZCwJv8sZCKelqh130hDZA1sfu5ksbBZCGDNe3KMOIEJEFBXNFZBKu1XJ7EZAwnipdOnSL8uAga4P4hM3ZAJQtgCUvkJ2m8HKnR7i0PFU2ZCNfNVgvgL0ired7RqwSXvhU1ANC5rMOOyjaxGLbhZAZBQZDZD");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(responseString);
            var v = new List<Info>();
            foreach (var item in jsonData.data)
            {
                v.Add(new Info
                {
                    ThoiGian = item.created_time,
                    NoiDung = item.message,
                    Link = item.actions[0].link,
                });
            }
            string s = "";
            for (int i = 0; i < 3; i++)
            {
                s += "<b>Bài viết thứ " + (i + 1) + ": </b>" + "</br>";
                s += "<b>Ngày đăng bài: </b>" + v[i].ThoiGian + "</br>";
                s += "<b>Nội dung b: </b>" + v[i].NoiDung + "</br>";
                s += "<b>Link: </b>" + v[i].Link + "</br>";
            }
            value.Text = s;
        }
    }
}