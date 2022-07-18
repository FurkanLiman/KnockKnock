using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace v6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            using (var connection0 = new NpgsqlConnection("Server=35.187.90.209;Port=5432;Database=postgres;User Id=testuser;Password=furkan51;"))
            using (var cmd = new NpgsqlDataAdapter())
            using (var insertCommand = new NpgsqlCommand("select * from \"public\".\"Kullanicilar\" where \"KullaniciAdi\" = '" +  txtRegUsername.Text +"'"))
            {
                insertCommand.Connection = connection0;
                cmd.InsertCommand = insertCommand;


                connection0.Open();
                NpgsqlDataReader isbnCheck = insertCommand.ExecuteReader();


                if (isbnCheck.HasRows == false)
                {
                    string query = "insert into \"public\".\"Kullanicilar\"(\"KullaniciAdi\",\"Sifre\",\"CloudIP\") Values('"+txtRegUsername.Text +"','"+ txtRegPassword.Text+"','"+txtWslink.Text+"')";

                    using (var conn1 = new NpgsqlConnection("Server=35.187.90.209;Port=5432;Database=postgres;User Id=testuser;Password=furkan51;"))
                    {
                        conn1.Open();
                        using (var command = new NpgsqlCommand(query, conn1))
                        {

                            using (var dr = command.ExecuteReader())
                            {
                                
                                DisplayAlert("Success!!", "The User Registered Successfully.", "Done");
                                
                            }
                        }
                    }
                }
                else
                {
                    DisplayAlert("Warning", "This Username is already in use.", "OK");
                }
            }
        }
    }
}