    público estático aula Patch do Fim de Jogo
        public static bool Prefix()
﻿usando  HarmonyLib ;
usando  System.Collections.Generic ;
usando  System.Linq ;
Usando  UnityEngine ;
usando  o mod estático  ExtraRolesMod.ExtraRoles ;

namespace  ExtraRolesMod
{
    [ HarmonyPatch ( typeof ( EndGameManager ) ,  nameof ( EndGameManager . SetEverythingUp ) ) ]
     classe estática  pública EndGamePatch 
    {
        público  estático  bool  Prefixo ( )
        {
            if  ( TempData . vencedores . Contagem  <=  1  ||  ! TempData . DidHumansWin ( TempData . EndReason ) )
                retornar  verdadeiro ;

            TempData.vencedores.Limpar ( ) ;
            var  orderLocalPlayers  =  localPlayers.Where ( player = > player.PlayerId == localPlayer.PlayerId ) .ToList ( ) ;   
            orderLocalPlayers.AddRange ( localPlayers.Where ( player = > player.PlayerId ! = localPlayer.PlayerId ) ) ;   

            foreach  ( var  winner  in  orderLocalPlayers )
                TempData.winners.Add ( new WinningPlayerData ( winner.Data ) ) ; 

            retornar  verdadeiro ;
        }

        public  static  void  Postfix ( EndGameManager  __instance )
        {
            if  ( ! TempData.DidHumansWin ( TempData.EndReason ) )
                retornar ;

            var  flag  =  localPlayers.Count ( player = > player.PlayerId == localPlayer.PlayerId ) == 0 ;     

            se  ( ! flag )
                retornar ;

            __instance.WinText.Text = " Derrota " ;  
            __instance.WinText.Color = Palette.ImpostorRed ;  
            __instance.BackgroundBar.material.color = new Color ( 1 , 0 , 0 ) ;     
        }
    }
}
