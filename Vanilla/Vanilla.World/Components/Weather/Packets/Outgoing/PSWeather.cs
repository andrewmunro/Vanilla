using Vanilla.Core.Network.Packet;
using Vanilla.Core.Opcodes;

namespace Vanilla.World.Components.Weather.Packets.Outgoing
{
    public sealed class PSWeather : WorldPacket
    {
        public PSWeather(WeatherZone weatherZone) : base(WorldOpcodes.SMSG_WEATHER)
        {
            this.Write((int)weatherZone.CurrentWeather);
            this.Write(weatherZone.Intensity);
            this.Write((int)weatherZone.CurrentSound);
        }
    }
}
