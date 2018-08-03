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
using System.Net;
using RestSharp;

namespace YouFly.droid
{
    [Activity(Label = "RegisterUserActivity")]
    public class RegisterUserActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateUser);
            string url = "http://147.174.187.131:3000/";
            EditText txtUsername = FindViewById<EditText>(Resource.Id.txtNewUsername);
            EditText txtPassword = FindViewById<EditText>(Resource.Id.txtNewPassword);
            EditText txtConfirmPassword = FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            EditText txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            Button btnCreateUser = FindViewById<Button>(Resource.Id.btnCreateUser);
            Button btnTestGet = FindViewById<Button>(Resource.Id.btnTest);
            btnCreateUser.Click += (object sender, EventArgs e) =>
            {

                //ToString(),txtConfirmPassword.ToString();
                //checks to see if username is null
                if (txtUsername.Text.ToString().Equals(""))
                {
                    Toast toast = Toast.MakeText(this, "Please Enter Username", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    //checks length of username
                    //will also have to check against duplicate usernames in DB
                    if (txtUsername.Text.ToString().Length < 6)
                    {
                        Toast toast = Toast.MakeText(this, "Username must be at least 6 characters.", ToastLength.Short);
                        toast.Show();
                    }
                    else
                    {
                        //checks password length
                        if (txtPassword.Text.ToString().Length < 8)
                        {
                            Toast toast = Toast.MakeText(this, "Password must be at least 8 characters.", ToastLength.Short);
                            toast.Show();
                        }
                        else
                        {
                            //checks if password and confirm password match
                            if (txtPassword.Text.ToString().Equals(txtConfirmPassword.Text.ToString()))
                            {
                                //checks if email is present
                                if (txtEmail.Text.ToString().Equals(""))
                                {
                                    Toast toast = Toast.MakeText(this, "Please enter in Email.", ToastLength.Short);
                                    toast.Show();
                                }
                                else
                                {
                                    //do register here
                                    User MyNewUser = new User();
                                    MyNewUser = CreateUser(txtUsername.Text.ToString(), txtPassword.Text.ToString(), txtEmail.Text.ToString());
                                    var client = new RestClient(url);
                                    var request = new RestRequest("api/Users/", Method.POST);
                                    request.RequestFormat = DataFormat.Json;
                                    request.AddBody(MyNewUser);
                                    client.ExecuteAsync(request, response => {
                                        Console.WriteLine(response.Content);
                                    });
                                    Toast toast = Toast.MakeText(this, "Registering...", ToastLength.Short);
                                    toast.Show();
                                    //StartActivity(typeof(MainActivity));
                                }
                            }

                            else
                            {
                                Toast toast = Toast.MakeText(this, "Passwords do not match.", ToastLength.Short);
                                toast.Show();
                            }
                        }

                    }

                }

            };
            btnTestGet.Click += async (object sender, EventArgs e) =>
            {
                //User MyNewUser = new User();
                //MyNewUser = CreateUser(txtUsername.Text.ToString(), txtPassword.Text.ToString(), txtEmail.Text.ToString());
                var client = new RestClient(url);
                var request = new RestRequest("api/Users/");
                request.RequestFormat = DataFormat.Json;
                //request.AddBody(MyNewUser);
                //var response = client.Execute(request);
                var content = await client.ExecuteTaskAsync(request);
                Console.WriteLine("this is content.content:");
                Console.WriteLine(content.Content);
                Console.WriteLine("this is content:");
                Console.WriteLine(content);
                Console.WriteLine("this is error:");
                Console.WriteLine(content.ErrorMessage);
                Console.WriteLine("this is response status:");
                Console.WriteLine(content.ResponseStatus);
                Console.WriteLine("this is status code:");
                Console.WriteLine(content.StatusCode);
            };
        }


        public class User
        {
            public int ID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }
        
        public User CreateUser(string UN, string password, string email)
        {
            User NewUser = new User();
            NewUser.UserName = UN;
            NewUser.Password = password;
            NewUser.Email = email;
            return NewUser;
        }
    }
}
