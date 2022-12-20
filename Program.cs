using System.Data.SQLite;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

SQLiteConnection sqlite = new SQLiteConnection("Data Source=BD\\2022 GL3 .NET Framework TP3 - SQLite database.db");
try
{
    sqlite.Open();
}
catch
{
    sqlite.Close();
}
SQLiteCommand cmd = sqlite.CreateCommand();
cmd.CommandText = "SELECT * FROM personal_info";
cmd.ExecuteNonQuery(); 
SQLiteDataReader reader = cmd.ExecuteReader();
using (reader)
{
    while (reader.Read())
    {
        int id = (int)reader["id"];
        string first_name = (string)reader["first_name"];
        string last_name = (string)reader["last_name"];
        string email = (string)reader["email"];
        //String date_birth = (String)reader["date_birth"];
        string image = (string)reader["image"];
        string country = (string)reader["country"];
        Debug.WriteLine("id : {0}  firstname : {1}  lastname : {2}  email : {3}  image : {4}  country : {5}",id,first_name,last_name,email,image,country);
    }
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
