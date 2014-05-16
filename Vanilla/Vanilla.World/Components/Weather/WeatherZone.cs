using System;
using System.Collections.Generic;

using Vanilla.World.Components.Weather.Constants;
using Vanilla.World.Database;

namespace Vanilla.World.Components.Weather
{
    public class WeatherZone
    {
        public int MapId { get; private set; }

        public Dictionary<WeatherSeason, Season> Seasons { get; private set; }

        public WeatherType CurrentWeather { get; set; }

        public float Intensity { get; set; }

        private int Random { get { return new Random().Next(0,100); } }
        private float RandomThird { get { return (float) new Random().NextDouble() * 0.3333f; } }

        public Season CurrentSeason
        {
            get
            {
                var now = DateTime.Now;
                //'78 days between January 1st and March 20nd; 365/4=91 days by season
                var timeSinceJanFirst = Math.Truncate(now.Subtract(new DateTime(now.Year, 1, 1)).TotalDays);
                var seasonInt = ((timeSinceJanFirst - 78 + 365) / 91) % 4;
                return Seasons[(WeatherSeason)seasonInt];
            }
        }

        public WeatherSound CurrentSound
        {
            get
            {
                var sound = WeatherSound.WEATHER_NOSOUND;
                switch (CurrentWeather)
                {
                    case WeatherType.WEATHER_TYPE_RAIN:
                        if (Intensity < 0.333333343F) sound = WeatherSound.WEATHER_RAINLIGHT;
                        if (this.Intensity < 0.6666667F) sound = WeatherSound.WEATHER_RAINMEDIUM;
                        sound = WeatherSound.WEATHER_RAINHEAVY;
                        break;
                    case WeatherType.WEATHER_TYPE_SNOW:
                        if (Intensity < 0.333333343F) sound = WeatherSound.WEATHER_SNOWLIGHT;
                        if (this.Intensity < 0.6666667F) sound = WeatherSound.WEATHER_SNOWMEDIUM;
                        sound = WeatherSound.WEATHER_SNOWHEAVY;
                        break;
                    case WeatherType.WEATHER_TYPE_STORM:
                        if (Intensity < 0.333333343F) sound = WeatherSound.WEATHER_SANDSTORMLIGHT;
                        if (this.Intensity < 0.6666667F) sound = WeatherSound.WEATHER_SANDSTORMMEDIUM;
                        sound = WeatherSound.WEATHER_SANDSTORMHEAVY;
                        break;
                }
                return sound;
            }
        }

        public WeatherZone(game_weather weather)
        {
            MapId = weather.zone;
            SetupSeasons(weather);

            CurrentWeather = WeatherType.WEATHER_TYPE_FINE;
            Intensity = 0.0f;
        }

        public bool ChangeWeather()
        {
            /*Weather statistics:
            - 30% - no change
            - 30% - weather gets better (if not fine) or change weather type
            - 30% - weather worsens (if not fine)
            - 10% - radical change (if not fine)*/

            var r1 = Random;
            var oldWeather = CurrentWeather;
            var oldIntensity = Intensity;

            //No change in weather
            if (r1 < 30) return false;

            //Reset to fine
            if (r1 < 60 && Intensity < 0.333333343f)
            {
                CurrentWeather = WeatherType.WEATHER_TYPE_FINE;
                Intensity = 0.0F;
            }

            //Weather gets better
            if (r1 < 60 && CurrentWeather == WeatherType.WEATHER_TYPE_FINE)
            {
                Intensity -= 0.333333343f;
                return true;
            }

            //Weather gets worse
            if (r1 < 90 && CurrentWeather == WeatherType.WEATHER_TYPE_FINE)
            {
                Intensity += 0.333333343f;
                return true;
            }

            /*Radical change:
            - if light -> heavy
            - if medium -> change weather type
            - if heavy -> 50% light, 50% change weather type*/
            if (CurrentWeather == WeatherType.WEATHER_TYPE_FINE)
            {
                if (Intensity < 0.333333343f)
                {
                    Intensity = 0.9999f;
                    return true;
                }

                if (this.Intensity > 0.6666667f && this.Random < 50)
                {
                    this.Intensity -= 0.6666667f;
                    return true;
                }
                this.CurrentWeather = WeatherType.WEATHER_TYPE_FINE;
                this.Intensity = 0.0f;
            }

            var rainChance = CurrentSeason.RainChance;
            var snowChance = CurrentSeason.SnowChance;
            var stormChance = CurrentSeason.StormChance;

            r1 = Random;

            if (r1 < rainChance)
            {
                CurrentWeather = WeatherType.WEATHER_TYPE_RAIN;
            }
            else if (r1 < snowChance)
            {
                CurrentWeather = WeatherType.WEATHER_TYPE_SNOW;
            }
            else if (r1 < stormChance)
            {
                CurrentWeather = WeatherType.WEATHER_TYPE_STORM;
            }
            else
            {
                CurrentWeather = WeatherType.WEATHER_TYPE_FINE;
            }

            /*New weather statistics (if not fine):
            - 85% light
            - 7% medium
            - 7% heavy
            If fine 100% sun (no fog)*/

            if (CurrentWeather == WeatherType.WEATHER_TYPE_FINE)
            {
                Intensity = 0.0f;
            }
            else if (r1 < 90)
            {
                Intensity = RandomThird;
            }
            else
            {
                //Severe change, but how severe?
                if (Random < 50)
                {
                    Intensity = RandomThird + 0.3334f;
                }
                else
                {
                    Intensity = RandomThird + 0.6667f;
                }
            }

            return ((CurrentWeather != oldWeather) || (Intensity.Equals(oldIntensity)));
        }

        private void SetupSeasons(game_weather weather)
        {
            var summer = new Season()
                             {
                                 RainChance = weather.summer_rain_chance,
                                 SnowChance = weather.summer_snow_chance,
                                 StormChance = weather.summer_storm_chance
                             };

            var fall = new Season()
            {
                RainChance = weather.fall_rain_chance,
                SnowChance = weather.fall_snow_chance,
                StormChance = weather.fall_storm_chance
            };

            var winter = new Season()
            {
                RainChance = weather.winter_rain_chance,
                SnowChance = weather.winter_snow_chance,
                StormChance = weather.winter_storm_chance
            };

            var spring = new Season()
            {
                RainChance = weather.spring_rain_chance,
                SnowChance = weather.spring_snow_chance,
                StormChance = weather.spring_storm_chance
            };

            Seasons = new Dictionary<WeatherSeason, Season>();

            Seasons[WeatherSeason.Summer] = summer;
            Seasons[WeatherSeason.Winter] = winter;
            Seasons[WeatherSeason.Spring] = spring;
            Seasons[WeatherSeason.Fall] = fall;
        }
    }
}
