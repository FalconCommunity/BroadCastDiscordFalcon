using System.Collections.Generic;
using LabApi.Features;
using LabApi.Features.Wrappers;
using MEC;
using Version = System.Version;

namespace HintDiscordFalcon
{
    public class Plugin : LabApi.Loader.Features.Plugins.Plugin
    {
        public override string Name => "Hints Discord Falcon";
        public override string Description => "Hints Promocion Discord Falcon";
        public override string Author => "AdrianoElAldeano";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredApiVersion => new Version(LabApiProperties.CompiledVersion);

        private CoroutineHandle _hintCoroutine;

        public override void Enable()
        {
            _hintCoroutine = Timing.RunCoroutine(HintLoop());
        }

        public override void Disable()
        {
            Timing.KillCoroutines(_hintCoroutine);
        }

        private IEnumerator<float> HintLoop()
        {
            yield return Timing.WaitForSeconds(5f);

            while (true)
            {
                foreach (Player player in Player.List)
                {
                    player.SendBroadcast("<color=green>Recordamos que os podéis unir al</color> <color=blue>discord</color> <color=green>en server info.</color>", 5);
                }
                
                yield return Timing.WaitForSeconds(300f);
            }
        }
    }
}