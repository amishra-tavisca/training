﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace DemoWidget
{
    public partial class Widget1 : System.Web.UI.UserControl,IWidget
    {
        IWidgetHost Host = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void HideSettings()
        {
            //throw new NotImplementedException();
        }

        public new void Init(IWidgetHost host)
        {
            //throw new NotImplementedException();
        }

        public void ShowSettings()
        {
            //throw new NotImplementedException();
        }
    }
}