﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using MilsatInternAPI.Models;

namespace MilsatInternAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RealtimeWeatherController : ControllerBase
    {
        private readonly IConfiguration _iconfig;
        private readonly ILogger<RealtimeWeatherController> _logger;

        public RealtimeWeatherController(IConfiguration iconfig, ILogger<RealtimeWeatherController> logger)
        {
            _iconfig = iconfig;
            _logger = logger;
        }

        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> City(string city)
        {
            using (var client = new HttpClient())
            {
                _logger.LogInformation($"Received request to fetch weather data of Request: {city}");
                try
                {
                    var KEY = _iconfig["token:weatherKey"];
                    var baseAddress = _iconfig["token:baseAddress"];
                    client.BaseAddress = new Uri(baseAddress);
                    var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid={KEY}&units=metric");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                    return Ok(new
                    {
                        Temp = rawWeather.Main.Temp,
                        Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
                        City = rawWeather.Name
                    });
                }
                catch (HttpRequestException httpRequestException)
                {
                    _logger.LogError($"Error getting weather data,  Message:{httpRequestException.Message}, Stacktrace:{httpRequestException.StackTrace}");
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }


    }
}