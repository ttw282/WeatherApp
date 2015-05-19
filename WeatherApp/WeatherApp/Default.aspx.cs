using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeatherApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getweather_Click(object sender, EventArgs e)
        {
            WeatherService.WeatherSoapClient client = new WeatherService.WeatherSoapClient("WeatherSoap");
            WeatherService.WeatherReturn result = client.GetCityWeatherByZIP(zip.Text);
            WeatherService.ForecastReturn result1 = client.GetCityForecastByZIP(zip.Text);
            if (result.Success)
            {
                error.Text = string.Empty;
                success.Text = "Success!";
                city.Text = result.City;
                state.Text = result.State;
                temperaturef.Text = result.Temperature;
                temperaturec.Text = ((int.Parse(result.Temperature) - 30) / 2).ToString();
                wind.Text = result.Wind;
                weatherstationcity.Text = result.WeatherStationCity;
            }
            else
            {
                error.Text = result.ResponseText;
                success.Text = string.Empty;
                city.Text = string.Empty;
                state.Text = string.Empty;
                temperaturef.Text = string.Empty;
                temperaturec.Text = string.Empty;
                wind.Text = string.Empty;
                weatherstationcity.Text = string.Empty;
            }
        }

        protected void getforecast_Click(object sender, EventArgs e)
        {
            WeatherService.WeatherSoapClient client = new WeatherService.WeatherSoapClient("WeatherSoap");
            WeatherService.ForecastReturn result = client.GetCityForecastByZIP(zip.Text);
            WeatherService.WeatherDescription[] weatherinfo = client.GetWeatherInformation();

            if (result.Success)
            {
                error.Text = string.Empty;
                success.Text = "Success!";
                ArrayList forecasts = new ArrayList();
                foreach (var f in result.ForecastResult)
                {
                    if (f != null)
                    {
                        Forecast fo = new Forecast(f.Desciption, ((int.Parse(f.Temperatures.DaytimeHigh) - 30)/2).ToString(), f.Temperatures.DaytimeHigh, f.Date );
                        fo.ID = f.WeatherID;
                        
                        forecasts.Add(fo);
                    }
                }

                foreach (Forecast f in forecasts)
                {
                    foreach (WeatherService.WeatherDescription wd in weatherinfo)
                    {
                        if (f.ID == wd.WeatherID)
                        {
                            f.PictureURL = wd.PictureURL;
                        }
                    }
                }

                forecast.DataSource = forecasts;

                forecast.DataBind();
            }
            else
            {
                error.Text = result.ResponseText;
                success.Text = string.Empty;
                forecast.DataSource = null;
                forecast.DataBind();
            }
        }

    }
}