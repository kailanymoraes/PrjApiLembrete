using Microsoft.AspNetCore.Mvc;

namespace PrjApiLembrete.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public WeatherForecast Get()
        {
            //modificador | tipo retorno | nome do metodo | parametros
           WeatherForecast previsaoTempo = new WeatherForecast();
            previsaoTempo.Date = new DateOnly(2025, 02, 17);
            previsaoTempo.TemperatureC = 32;
            previsaoTempo.Summary = "Escaldante";
            return previsaoTempo;
        }

        [HttpGet("versao")] // nome exposto na rota -- vai pra internet
        public string GetVersao() // nome interno
        {
            return "API Weather Forecast - versão 1.0";
        }

        //Criar uma rota usando o verbo Get que dê uma saudação ao usuário

        [HttpGet("hello/{name}")]
        public string GetSaudacao(string name) 
        {
            return "Olá, " + name;
        }
    }
}