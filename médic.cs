using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace ExtraRoles
{
    public class Medic : RoleBase
    {
        public override string Nome => "Médico";
        public override TipoFuncao Tipo => TipoFuncao.Tripulante;
        public override string Descricao => "Use o kit médico para reviver corpos";
        
        private bool jaUsou = false;

        [HarmonyPatch(typeof(UseButtonManager), nameof(UseButtonManager.DoClick))]
        public static class MedicReviverPatch
        {
            static bool Prefix(UseButtonManager __instance)
            {
                Jogador jogadorLocal = Jogador.Local;
                Medic medico = jogadorLocal.PegarFuncao<Medic>();
                
                if (medico == null || medico.jaUsou) return true;

                CorpoMorto corpo = __instance.alvo as CorpoMorto;
                if (corpo != null)
                {
                    jogadorLocal.AgendarReviver(corpo.dono);
                    medico.jaUsou = true;
                    __instance.MostrarTexto("Revivido!");
                    return false;
                }
                return true;
            }
        }

        public override void AoUsarHabilidade()
        {
            if (jaUsou) return;
            
            CorpoMorto corpoPerto = EncontrarCorpoMaisProximo();
            if (corpoPerto != null)
            {
                Jogador.Local.ReviverJogador(corpoPerto.dono);
                jaUsou = true;
            }
        }
    }
}
