// using HarmonyLib;
using IPA;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace AudioFix
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        // internal static Harmony harmony;

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            BeatSaberMarkupLanguage.Util.MainMenuAwaiter.MainMenuInitializing += MainMenuInit;
            // harmony = new Harmony("Loloppe.BeatSaber.AudioFix");
        }

        [OnEnable]
        public void OnEnable()
        {
            // harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public void MainMenuInit()
        {
            var configuration = AudioSettings.GetConfiguration();
            configuration.dspBufferSize = 256;
            if (AudioSettings.Reset(configuration))
            {
                Log.Info("dspBufferSize set to " + configuration.dspBufferSize.ToString());
            }
        }

        [OnDisable]
        public void OnDisable()
        {
            // harmony.UnpatchSelf();
        }
    }
}
