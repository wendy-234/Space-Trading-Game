﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars_Trading_Game
{
    class Galaxy
    {
        public static Planet Alderan => new Planet
        {
            planetName = "Alderaan",
            planetImage = @"  
                ;    . ..%; 8.@8888@8@@@888X @%:.. 
                . . :; @888@88@8@8@8@88@@@@8@X@. .    
                . t 8S@8@@8@@8@8@8@8@@8@888@@@88];..   .
                . ;% 8X8@8@8@8@8@@8@8@8@8@@@@@8@8]'; 
                . 88@8@8@8@8@@8@8@8@8@8@@8@@8@8@8@8@8; .
                % 8@@@8@@8@@8@8@@8@8@8@8@8@8@8@8@8@@8SX.
               S; 8@@8@8@@8@8@@8@8@@8@@8@8@8@@8@8@8@@8
               .8@@8@@8@8@8--------------@8@8@8@@8@8@@S8
                X88@@8@8@8@8@-----------@8@@@8@8@8@@8@@@8.
                88@8@8@8@8@8@8@8@8@8@8@88@8@@8@8@8@8@88
                88@8@@8@8@@8@@8@8@@8@@8@@8@8@8@8@@8@@8@
                X8@@8@8@8@8@@8@8@@8@8@8@8@8@8@@8@8@8@@8:
                % 8@8@8@8@@8@8@8@8@8@8@8@@8@8@8@8@8@8@8SS
                . 8X8@8@8@8@8@8@8@8@@8@8@8@@8@8@8@8@@88
                 t8@8@@8@8@8@8@@8@@8@8@8@@8@8@@8@@8@8SX
                   .8@8@8@8@8@8@8@8@8@8@8@8@8@8@@88.
                    ;:;8@@@8@8@8@8@8@@8@@8@8@88 t.. 
                         ;@@@8@8@8@8@@8@@@@8S: .  "
        };

        public static Planet Naboo => new Planet
        {
            planetName = "Naboo",
            planetImage = @"  
                ;    . ..%; 8.@8888@8@@@888X @%:.. 
                . . :; @888@88@8@8@8@88@@@@8@X@. .    
                . t 8S@8@@8@@8@8@8@8@@8@888@@@88];..   .
                . ;% 8X8@8@8@8@8@@8@8@8@8@@@@@8@8]'; 
                . 88@8@8@8@8@@8@8@8@8@8@@8@@8@8@8@8@8; .
                % 8@@@8@@8@@8@8@@8@8@8@8@8@8@8@8@8@@8SX.
               S; 8@@8@8@@8@8@@8@8@@8@@8@8@8@@8@8@8@@8
               .8@@8@@8@8@8@)888888888888@8@8@8@@8@8@@S8
                X88@@8@8@8@8@8@*@8@8@8@@8@@@8@8@8@@8@@@8.
                88@8@8@8@8@8@8@8@8@8@8@88@8@@8@8@8@8@88
                88@8@@8@8@@8@@8@8@@8@@8@@8@8@8@8@@8@@8@
                X8@@8@8@8@8@@8@8@@8@8@8@8@8@8@@8@8@8@@8:
                % 8@8@8@8@@8@8@8@8@8@8@8@@8@8@8@8@8@8@8SS
                . 8X8@8@8@8@8@8@8@8@@8@8@8@@8@8@8@8@@88
                 t8@8@@8@8@8@8@@8@@8@8@8@@8@8@@8@@8@8SX
                   .8@8@8@8@8@8@8@8@8@8@8@8@8@8@@88.
                    ;:;8@@@8@8@8@8@8@@8@@8@8@88 t.. 
                         ;@@@8@8@8@8@@8@@@@8S: .  "
        };

        public static Planet Tatooine => new Planet
        {
            planetName = "Tatooine",
            planetImage = @"  
                ;    . ..%; 8.@8888@8@@@888X @%:.. 
                . . :; @888@88@8@8@8@88@@@@8@X@. .    
                . t 8S@8@@8@-------------88@@@88];..   .
                . ;% 8X8@8@8@8@8@@8@8@8@8@@@@@8@8]'; 
                . 88@8@8@8@8@@8@8@8@8@8@@8@@8@8@8@8@8; .
                % 8@@@8@@8@@8@8@@8@8@8@8@8@8@8@8@8@@8SX.
               S; 8@@8@8@@8@8@@8@8@@8@@8@8@8@@8@8@8@@8
               .8@@8@@8@8@8@)888888888888@8@8@8@@8@8@@S8
                X88@@8@8@8@8@8@*@8@8@8@@8@@@8@8@8@@8@@@8.
                88@8@8@8@8@8@8@8@8@8@8@88@8@@8@8@8@8@88
                88@8@@8@8@@8@@8@8@@8@@8@@8@8@8@8@@8@@8@
                X8@@8@--------------------@8@8@@8@8@8@@8:
                % 8@8@8@8@@8@8@8@8@8@8@8@@8@8@8@8@8@8@8SS
                . 8X8@8@8@8@8@8@8@8@@8@8@8@@8@8@8@8@@88
                 t8@8@@8@8@8@8@@8@@8@8@8@@8@8@@8@@8@8SX
                   .8@8@8@8@8@8@8@8@8@8@8@8@8@8@@88.
                    ;:;8@@@8@8@8@8@8@@8@@8@8@88 t.. 
                         ;@@@8@8@8@8@@8@@@@8S: .  "
        };

        public static Planet Hoth => new Planet
        {
            planetName = "Hoth",
            planetImage = @"  
                ;    . ..%; 8.@8888@8@@@888X @%:.. 
                . . :; @888@88@8@8@8@88@@@@8@X@. .    
                . t 8S@8@@8@@8@8@8@8@@8@888@@@88];..   .
                . ;% 8X8@8@8@8@8@@8@8---------@@8@8]'; 
                . 88@8@8@8@8@@8@8@8@8-----------8@8@8; .
                % 8@@@8@@8@@8@8@@8--------------@8@@8SX.
               S; 8@@8@8@@8@8@@8@8@@8@@8@8@8@@8@8@8@@8
               .8@@8@@8@8@8@)888888888888@8@8@8@@8@8@@S8
                X88@@8@8@8@8@8@*@8@8@8@@8@@@8@8@8@@8@@@8.
                88@8@8@8@8@8@8@8@8@8@8@88@8@@8@8@8@8@88
                88@8@@8@8@@8@@8@8@@8@@8@@8@8@8@8@@8@@8@
                X8@@8@8@8@8@@8@8@@8@8@8@8@8@8@@8@8@8@@8:
                % 8@8@8@8@@8@8@8@8@8@8@8@@8@8@8@8@8@8@8SS
                . 8X8@8@8@8@8@8@8@8@@8@8@8@@8@8@8@8@@88
                 t8@8@@8@8@8@8@@8@@8@8@8@@8@8@@8@@8@8SX
                   .8@8@8@8@8@8@8@8@8@8@8@8@8@8@@88.
                    ;:;8@@@8@8@8@8@8@@8@@8@8@88 t.. 
                         ;@@@8@8@8@8@@8@@@@8S: .  "
        };

        public static Planet Dagobah => new Planet
        {
            planetName = "Dagobah",
            planetImage = @"  
                ;    . ..%; 8.@8888@8@@@888X @%:.. 
                . . :; @888@88@8@8@8@88@@@@8@X@. .    
                . t 8S@8@@8@@8@8@8@8@@8@888@@@88];..   .
                . ;% 8X8@8@8@8@8@@8@8@8@8@@@@@8@8]'; 
                . 88@8@8@8@8@@8@8@8@8@8@@8@@8@8@8@8@8; .
                % 8@@@8@@8@@8@8@@8@8@8@8@8@8@8@8@8@@8SX.
               S; 8@@8@8@@8@8@@8@8@@8@@8@8@8@@8@8@8@@8
               .8@@8@@8@8@8@)8----------8@8@8@8@@8@8@@S8
                X88@@8@8@8@8@8----------8@@@8@8@8@@8@@@8.
                88@8@8@8@8@8@8@8@8@8@8@88@8@@8@8@8@8@88
                88@8@@8@8@@8@@8@8@@8@@8@@8@8@8@8@@8@@8@
                X8@@8@8@8@8@@8@8@@8@8@8@8@8@8@@8@8@8@@8:
                % 8@8@8@8@@8@8@8@8@8@8@8@@8@8@8@8@8@8@8SS
                . 8X8@8@8@8@8@8@8@8@@8@8@8@@8@8@8@8@@88
                 t8@8@@8@8@8@8@@8@@8@8@8@@8@8@@8@@8@8SX
                   .8@8@8@8@8@8@8@8@8@8@8@8@8@8@@88.
                    ;:;8@@@8@8@8@8@8@@8@@8@8@88 t.. 
                         ;@@@8@8@8@8@@8@@@@8S: .  "
        };
    }
}
