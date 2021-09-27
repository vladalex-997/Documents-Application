using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registratura
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Login"] == null)
            //{
            //    Response.Redirect("/Login.aspx");
            //}
            menuusercurent.Visible = false;
            if (Session["login"] != null)
            {
                menulogin.Visible = false;
                  string temporole,tempnume;
                  tempnume = Request.Cookies["dateutilizator"].Value;
                  //if (temporole != null) { }
                  GetPrivilage g = new GetPrivilage();
                  temporole = g.GetRights(tempnume);

                  if (temporole == "User")
                  {
                      menuinregistrarirealizate.Visible = false;
                      menucautare.Visible = true;
                      menuinregistraredocumente.Visible = true;
                      menuinregistrarirealizateuser.Visible = true;
                      menuinregistrareutilizatori.Visible = false;
                      menuusercurent.Visible = true;
                      menumodificari.Visible = false;
                      menuuseriprezenti.Visible = false;
                      menuusercurent.InnerText = "Bun venit, " + tempnume;
                  }
                  else
                  {
                      if (temporole == "Admin")
                      {
                          menuinregistrarirealizate.Visible = true;
                          menucautare.Visible = true;
                          menuinregistraredocumente.Visible = true;
                          menuinregistrarirealizateuser.Visible = false;
                          menuinregistrareutilizatori.Visible = true;
                          menuusercurent.Visible = true;
                          menumodificari.Visible = true;
                        menuuseriprezenti.Visible = true;
                          menuusercurent.InnerText = "Bun venit, " + tempnume;
                    }
                      else
                      {
                        menulogout.Visible = false;
                        menucautare.Visible = false;
                        menuinregistraredocumente.Visible = false;
                        menuinregistrarirealizate.Visible = false;
                        menuinregistrarirealizateuser.Visible = false;
                        menulogin.Visible = true;
                        menuinregistrareutilizatori.Visible = false;
                        menumodificari.Visible = false;
                        menuuseriprezenti.Visible = false;
                        menuusercurent.Visible = false;
                    }
                  }
                
              }

                
              else
              {
                  menulogout.Visible = false;
                  menucautare.Visible = false;
                  menuinregistraredocumente.Visible = false;
                  menuinregistrarirealizate.Visible = false;
                  menuinregistrarirealizateuser.Visible = false;
                  menulogin.Visible = true;
                  menuinregistrareutilizatori.Visible = false;
                  menumodificari.Visible = false;
                menuuseriprezenti.Visible = false;
                  menuusercurent.Visible = false;

            }

              

            

        }
    }
}