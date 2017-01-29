using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using Android.Util;
using Java.Interop;

namespace XamarinLogin
{
    [Activity(Label = "Aktualnoœci PWSZ W³oc³awek")]
    public class aktualnosciActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Aktualnosci);
            initialize();
        }

        public void initialize()
        {
            WebView webView1 = FindViewById<WebView>(Resource.Id.webView1);
            webView1.SetWebViewClient(new WebViewClient());
            webView1.Settings.JavaScriptEnabled = true;
            string url = "https://www.pwsz.wloclawek.pl/";
            webView1.LoadUrl(url);
        }


    }
}