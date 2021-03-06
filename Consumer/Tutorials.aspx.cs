﻿using Consumer.ServiceReference1;
using Consumer.ServiceReferenceNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consumer
{
    public partial class Tutorials : System.Web.UI.Page
    {
        public bool isApproved { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //isApproved = Session["User"] != null ? ((Consumer.ServiceReference1.Person)Session["User"]).IsApproved : false;
            //if (Session["User"] == null)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
            //if (!isApproved)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
        }

        public List<ServiceReference1.TutorialItem> GetTutorials()
        {
            List<ServiceReference1.TutorialItem> res = new List<ServiceReference1.TutorialItem> ();
            using (var client = new Service1Client())
            {
                GetPublishTutoItemsResponse response = client.GetPublishTutoItems();
                if (!response.Errored)
                {
                    string script = "tutorials = { \n";
                    res = new List<ServiceReference1.TutorialItem>();
                    ServiceReference1.TutorialItem[] items = response.TutorialItems;
                    foreach (TutorialItem t in items)
                    {
                        res.Add(t);
                        script += "\t'" + t._id + "' : \n";
                        script += "\t{ \n";
                        script += "\t\t'author' : '" + t.Author + "',\n";
                        script += "\t\t'title' : '" + t.Title + "',\n";
                        script += "\t\t'date_published' : '" + t.DatePublished + "',\n";
                        script += "\t\t'date_modified' : '" + t.DateModified + "',\n";
                        script += "\t\t'pages' : [\n";

                        foreach (TutorialPage p in t.Pages)
                        {
                            script += "\t\t\t{\n";
                            script += "\t\t\t\t'page_number' : " + p.PageNumber + ", \n";
                            script += "\t\t\t\t'text' : '" + p.Text + "', \n";
                            script += "\t\t\t\t'video' : '" + p.Video + "', \n";
                            script += "\t\t\t},\n";
                        }

                        script += "\t\t]\n";
                        script += "\t}, \n";
                    }
                    script += "};";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "tutorials", script, true);
                }
            }

            res.Sort(delegate(TutorialItem t1, TutorialItem t2)
            {
                return DateTime.Compare(t2.DateModified, t1.DateModified);
            });
            return res;
        }
    }

}