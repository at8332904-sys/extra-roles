        static void Postfix(MapBehaviour __instance)
﻿usando  ExtraRoles . Médico ;
usando  ExtraRoles . Oficial ;
usando  ExtraRoles.Rpc ;
usando  ExtraRolesMod ;
usando  HarmonyLib ;
usando  Hazel ;
usando  Reactor ;
usando  o sistema ;
Usando  UnityEngine ;
usando  o mod estático  ExtraRolesMod.ExtraRoles ;

namespace  ExtraRoles.Roles.Engineer
{

    [ HarmonyPatch ( typeof ( MapBehaviour ) ,  nameof ( MapBehaviour . FixedUpdate ) ) ]
    classe  EngineerMapUpdate
    {
        static  void  Postfix ( MapBehaviour  __instance )
        {
            se  ( ! PlayerControl . LocalPlayer . isPlayerRole ( Role . Engineer ) )
                retornar ;
            se  ( ! __instance . IsOpen  ||  ! __instance . infectedOverlay . gameObject . active )
                retornar ;
            __instance.ColorControl.baseColor = 
                ! Principal . Lógica . sabotagemAtiva  ?  Cor . cinza  :  Principal . Paleta . corEngenheiro ;

            var  perc  =  Main.Logic.getRolePlayer ( Role.Engineer ) .UsedAbility ? 1f : 0f ;    

            foreach  ( var  room  in  __instance . infectedOverlay . rooms )
            {
                se  ( quarto.especial == nulo )  
                    continuar ;
                sala . especial . material . SetFloat ( "_Desat" ,  ! Main . Logic . sabotageActive  ?  1f  :  0f ) ;

                quarto.especial.habilitado = verdadeiro ;  
                sala . especial . objetoJogo . DefinirAtivo ( verdadeiro ) ;
                sala.especial.gameObject.ativo = verdadeiro ;  
                sala . especial . material . SetFloat ( "_Percent" ,  ! PlayerControl . LocalPlayer . Data . IsDead  ?  perc  :  1f ) ;
            }
        }
    }

}
