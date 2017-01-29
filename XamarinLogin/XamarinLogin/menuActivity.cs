using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Java.Lang;
using Android.Content;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using Org.Json;

namespace XamarinLogin
{
    [Activity(Label = "Menu g³ówne")]
    public class menuActivity : Activity, View.IOnClickListener
    {
        Button news_btn, plan_btn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.menu);
            initialize();
        }
        public void initialize()
        {
            news_btn = (Button)FindViewById(Resource.Id.news_btn);
            plan_btn = (Button)FindViewById(Resource.Id.plan_btn);
 
            news_btn.SetOnClickListener(this);
            plan_btn.SetOnClickListener(this);

        }



        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.news_btn:
                    Intent intent = new Intent(this, typeof(aktualnosciActivity));  
                    this.StartActivity(intent);
                    this.Finish();
                    break;
            }
        }
    }
}