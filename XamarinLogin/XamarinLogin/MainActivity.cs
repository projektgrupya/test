using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using Java.Lang;
using Android.Content;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using Org.Json;

namespace XamarinLogin
{
	[Activity(Label = "StudentPWSZ", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, Android.Views.View.IOnClickListener
	{
		
		EditText email, password;
		Button signIn;
		signInAsync sn;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
			initialize();
		}
		public void initialize()
		{
			email = (EditText)FindViewById(Resource.Id.userEmail);
			password = (EditText)FindViewById(Resource.Id.userPass);
			signIn = (Button)FindViewById(Resource.Id.signInBtn);
			signIn.SetOnClickListener(this);
		}

		public void OnClick(View v)
		{
			switch (v.Id)
			{
				case Resource.Id.signInBtn:
					sn = new signInAsync(this);
					sn.Execute();
					break;
			}
		}
        public void home()
        {
            Intent intent = new Intent(this, typeof(menuActivity));  
            this.StartActivity(intent);
            this.Finish();
        }

		public class signInAsync : AsyncTask<Java.Lang.Object, Java.Lang.Object, Java.Lang.Object>
		{
			MainActivity mainActivity;

			public signInAsync(MainActivity mainActivity)
			{
				this.mainActivity = mainActivity;
			}
			string userEmail, userPassword;
			protected override void OnPreExecute()
			{
				base.OnPreExecute();

				userEmail = mainActivity.email.Text;
				userPassword = mainActivity.password.Text;
			}
			protected override Java.Lang.Object RunInBackground(params Java.Lang.Object[] @params)
			{
				
				WebClient client = new WebClient();
				Uri uri = new Uri("http://www.zimm.96.lt/Login/xamarinsignIn.php");
				NameValueCollection parameters = new NameValueCollection();
				parameters.Add("uemail", userEmail);
				parameters.Add("pass", userPassword);
				var response = client.UploadValues(uri, parameters);
				var responseString = Encoding.Default.GetString(response);
				JSONObject ob = new JSONObject(responseString);
                try
                {
                    if (ob.OptString("success").Equals("1"))
                    {
                        try
                        {
                            mainActivity.RunOnUiThread(() =>
                            Toast.MakeText(mainActivity, "Udalo Ci sie zalogowac!", ToastLength.Short).Show());
                            mainActivity.RunOnUiThread(() => mainActivity.home());

                        }
                        catch (System.Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                    else
                    {
                        mainActivity.RunOnUiThread(() =>
                        Toast.MakeText(mainActivity, "Zly numer indeksu lub haslo", ToastLength.Short).Show());
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex);
                }

				return null;
			}
		}

	}
}


