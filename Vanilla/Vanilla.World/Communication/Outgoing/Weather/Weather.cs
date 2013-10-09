namespace Vanilla.World.Communication.Outgoing.Weather
{
    #region

    using System.IO;

    #endregion

    public enum WeatherState : uint
    {
        WEATHER_STATE_FINE = 0, 

        WEATHER_STATE_LIGHT_RAIN = 3, 

        WEATHER_STATE_MEDIUM_RAIN = 4, 

        WEATHER_STATE_HEAVY_RAIN = 5, 

        WEATHER_STATE_LIGHT_SNOW = 6, 

        WEATHER_STATE_MEDIUM_SNOW = 7, 

        WEATHER_STATE_HEAVY_SNOW = 8, 

        WEATHER_STATE_LIGHT_SANDSTORM = 22, 

        WEATHER_STATE_MEDIUM_SANDSTORM = 41, 

        WEATHER_STATE_HEAVY_SANDSTORM = 42, 

        WEATHER_STATE_THUNDERS = 86, 

        WEATHER_STATE_BLACKRAIN = 90
    };

    public enum WeatherSounds : uint
    {
        WEATHER_NOSOUND = 0, 

        WEATHER_RAINLIGHT = 8533, 

        WEATHER_RAINMEDIUM = 8534, 

        WEATHER_RAINHEAVY = 8535, 

        WEATHER_SNOWLIGHT = 8536, 

        WEATHER_SNOWMEDIUM = 8537, 

        WEATHER_SNOWHEAVY = 8538, 

        WEATHER_SANDSTORMLIGHT = 8556, 

        WEATHER_SANDSTORMMEDIUM = 8557, 

        WEATHER_SANDSTORMHEAVY = 8558
    };

    public class Weather : BinaryWriter
    {
        #region Constructors and Destructors

        public Weather(WeatherState state, float grad, WeatherSounds sound)
            : base(new MemoryStream())
        {
            this.Write((uint)state);
            Write(grad);
            this.Write((uint)sound);
        }

        #endregion

        #region Public Properties

        public byte[] Packet
        {
            get
            {
                return (this.BaseStream as MemoryStream).ToArray();
            }
        }

        #endregion
    }
}