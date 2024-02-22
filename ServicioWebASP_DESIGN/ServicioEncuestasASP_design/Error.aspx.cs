﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServicioEncuestas_design
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Request["Exception"] != null)
                {
                    lbError.Text = HttpUtility.UrlDecode( Request["Exception"] );
                }
            }
        }
    }
}