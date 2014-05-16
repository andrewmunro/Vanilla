using System.Collections.Generic;
using System.Linq;

using Vanilla.Core.Logging;
using Vanilla.World.Components.Entity;
using Vanilla.World.Components.Weather.Constants;
using Vanilla.World.Components.Weather.Packets.Outgoing;
using Vanilla.World.Database;
using Vanilla.World.Network;

namespace Vanilla.World.Components.Weather
{
    public class WeatherComponent : WorldServerComponent
    {
        public Dictionary<int, WeatherZone> WeatherZones { get; private set; }

        public WeatherComponent(VanillaWorld vanillaWorld)
            : base(vanillaWorld)
        {
            WeatherZones = new Dictionary<int, WeatherZone>();

            var weathers = Core.WorldDatabase.GetRepository<game_weather>().AsQueryable().ToList();
            foreach (var weather in weathers)
            {
                WeatherZones.Add(weather.zone, new WeatherZone(weather));
            }
        }

        //TODO Call this in an update loop when weather is to be recalculated.
        public override void Update()
        {
            base.Update();
            if (WeatherZones != null) WeatherZones.Values.ToList().ForEach(this.UpdateWeatherZone);
        }

        
        public void UpdateWeatherZone(WeatherZone weatherZone)
        {
            if(weatherZone.ChangeWeather()) SendWeather(weatherZone);
        }

        public void SetWeather(WorldSession session, WeatherType type, float intensity)
        {
            var weatherZone = GetWeatherZoneForSession(session);

            if (weatherZone == null)
            {
                Log.Print(LogType.Error, session.Player.Name + " attempted to change weather of a mapID that was not setup.");
                return;
            }

            SetWeather(weatherZone, type, intensity);
        }

        public void SetWeather(WeatherZone weatherZone, WeatherType type, float intensity)
        {
            weatherZone.CurrentWeather = type;
            weatherZone.Intensity = intensity;

            this.SendWeather(weatherZone);
        }

        public void SendWeather(WorldSession session)
        {
            session.SendPacket(new PSWeather(GetWeatherZoneForSession(session)));
        }

        public void SendWeather(WeatherZone weatherZone)
        {
            SessionsInWeatherZone(weatherZone).ForEach(s => s.SendPacket(new PSWeather(weatherZone)));
        }

        private List<WorldSession> SessionsInWeatherZone(WeatherZone weatherZone)
        {
            var entityComponent = Core.GetComponent<EntityComponent>();
            return
                (from p in entityComponent.PlayerEntities.Where(pe => pe.Location.MapID == weatherZone.MapId)
                 select p.Session).ToList();
        }

        private WeatherZone GetWeatherZoneForSession(WorldSession session)
        {
            return WeatherZones[(int)session.Player.Character.zone];
        }
    }
}
