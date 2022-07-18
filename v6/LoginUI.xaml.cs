using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Npgsql;
namespace v6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        public static string baglantilink;
        public LoginUI()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            using (var connection0 = new NpgsqlConnection("Server=35.187.90.209;Port=5432;Database=postgres;User Id=testuser;Password=furkan51;"))
            using (var cmd = new NpgsqlDataAdapter())
            using (var insertCommand = new NpgsqlCommand("select * from \"public\".\"Kullanicilar\""))
            {
                insertCommand.Connection = connection0;
                cmd.InsertCommand = insertCommand;


                connection0.Open();
                NpgsqlDataReader isbnCheck = insertCommand.ExecuteReader();


                if (isbnCheck.HasRows == true)
                {
                    bool kontrol = false;
                    while (isbnCheck.Read())
                    {
                        
                        if (txtUsername.Text == isbnCheck.GetString(1) && txtPassword.Text == isbnCheck.GetString(3))
                        {
                            DisplayAlert("Success!!", "You have been connected to ws:{" + isbnCheck.GetString(3) + "}", "OK...");
                            baglantilink = isbnCheck.GetString(3);
                            Navigation.PushAsync(new Images(isbnCheck.GetString(3)));
                            kontrol = true;
                        }


                    }
                    if (kontrol == false)
                    {
                        DisplayAlert("Warning!!", "Invalid Password or Username", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Warning!!", "There is no account with this username", "Ok");
                }

              
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}