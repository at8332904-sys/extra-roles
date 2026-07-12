using BepInEx;
using HarmonyLib;
using AmongUs.GameOptions;

namespace ExtraFuncoes.Servidor
{
    [BepInPlugin("com.extrafuncoes.servidor", "Extra Funções - Lado Servidor", "1.0.0")]
    public class ServerMod : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("com.extrafuncoes.servidor");

        void Awake()
        {
            harmony.PatchAll();
            Logger.LogInfo("[✅] Servidor Extra Funções carregado!");
        }

        [HarmonyPatch(typeof(GameOptionsManager), nameof(GameOptionsManager.ValidateOptions))]
        public static class RegrasServidor
        {
            static void Postfix(GameOptions options)
            {
                options.MaxPlayers = 15;
                options.TutorialDisabled = true;
            }
        }
    }
}
