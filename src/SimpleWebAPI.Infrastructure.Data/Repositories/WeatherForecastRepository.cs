using SimpleWebAPI.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SimpleWebAPI.Infrastructure.Repository
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        public void InsertForecastWeek(DateTime date, int temperatureC, int temperatureF, string summary)
        {
            SqlConnection sqlCon = new SqlConnection("Data Source=localhost,1433;Initial Catalog=teste1;User ID=sa;Password=matheusbzadra1994;");

            sqlCon.Open();

            SqlCommand com = new SqlCommand(string.Format("insert into weatherforecast(date, temperatureC, temperatureF, summary ) values({0}, {1}, {2}, {3});",
                    date,
                    temperatureC,
                    temperatureF,
                    summary
                ));

            com.ExecuteReader();



            //SqlCommand com = new SqlCommand("insert into carros(id, carro) values(@TC, @Sum);", sqlCon);
            //SqlCommand com = new SqlCommand("insert into carros (id,carro) values (1,'civic')", sqlCon);	
            /*var yourTextValue = "this is text";
			using (var db = new SqlConnection())
			{
				

				var command =
					new SqlCommand("INSERT INTO dokimastikospinakas (pliroforia) VALUES (@textValue);", db);
				command.Parameters.AddWithValue("@textValue", yourTextValue);
				command.ExecuteNonQuery();
			}
			*/
        }
    }
}
