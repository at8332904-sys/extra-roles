
FunçõesExtrasAmongUs
Navegação do repositório
Código
Solicitações de pull
Agentes
FunçõesExtrasAmongUs/ FunçõesExtras/ FunçõesMédico
/BodyReport.cs
HakuTheWolfSpirit
HakuTheWolfSpirit
há 5 anos
54 linhas (51 locais) · 2,03 KB

Código

Culpa
        public static string ParseBodyReport(BodyReport br)
﻿usando  o sistema ;
usando  System.Collections.Generic ;
usando  o mod estático  ExtraRolesMod.ExtraRoles ;

namespace  ExtraRoles.Roles.Medic
{
    //classe de relatório de corpo para quando o médico reporta um corpo
     classe  pública BodyReport
    {
        público  DeathReason  DeathReason  {  get ;  set ;  }
        público  PlayerControl  Killer  {  obter ;  definir ;  }
        public  PlayerControl  Reporter  {  get ;  set ;  }
        public  float  KillAge  {  get ;  set ;  }

        public  static  string  ParseBodyReport ( BodyReport  br )
        {
            System.Console.WriteLine ( br.KillAge ) ;
            se  ( br.KillAge > Main.Config.medicKillerColorDuration * 1000 )    
            {
                return  $ "Relatório do Corpo: O cadáver é muito antigo para obter informações. (Morto há { Math . Round ( br . KillAge  /  1000 ) } s)" ;
            }
            senão  se  ( br . MotivoDaMorte  ==  ( MotivoDaMorte ) 3 )
            {
                return  $ "Relatório de Corpo (Policial): A causa da morte parece ser suicídio! (Morto há { Math . Round ( br . KillAge  /  1000 ) } s)" ;

            }
            senão  se  ( br.KillAge < Main.Config.medicKillerNameDuration * 1000 )    
            {
                return  $ " Relatório do Corpo : O assassino parece ser { br.Killer.name } ! ( Morreu há { Math.Round ( br.KillAge / 1000 ) } s ) "   ;
            }
            outro
            {
                //TODO (fazer com que o tipo de cor seja escrito no chat)
                var  cores  =  novo  Dicionário < byte ,  string > ( )
                {
                    { 0 ,  "mais escuro" } ,
                    { 1 ,  "mais escuro" } ,
                    { 2 ,  "mais escuro" } ,
                    { 3 ,  "mais leve" } ,
                    { 4 ,  "mais leve" } ,
                    { 5 ,  "mais leve" } ,
                    { 6 ,  "mais escuro" } ,
                    { 7 ,  "mais leve" } ,
                    { 8 ,  "mais escuro" } ,
                    { 9 ,  "mais escuro" } ,
                    { 10 ,  "mais leve" } ,
                    { 11 ,  "mais leve" } ,
                } ;
                var  typeOfColor  =  colors [ br . Killer . Data . ColorId ] ;
                return  $ "Relatório do Corpo: O assassino parece ser da cor { typeOfColor } . (Morreu há { Math . Round ( br . KillAge  /  1000 ) } s)" ;
            }
      }

    }
