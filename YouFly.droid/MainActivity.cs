using Android.App;
using Android.Widget;
using Android.OS;
using RestSharp;

namespace YouFly.droid
{
    [Activity(Label = "YouFly.droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            EditText txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            EditText txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            Button btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            Button btnRegister = FindViewById<Button>(Resource.Id.btnRegister);

            btnLogin.Click += (sender, e) =>
            {
                var client = new RestClient("http://localhost:54412/api/");
                var request = new RestRequest("Users/{id}", Method.GET);
                request.AddUrlSegment("id", txtUsername.ToString());
                string content = null;
                client.ExecuteAsync(request, response =>
                {
                    content = response.Content;
                });
            };

            btnRegister.Click += (sender, e) =>
            {
                StartActivity(typeof(RegisterUserActivity));
            };
            
        }
    }
}

