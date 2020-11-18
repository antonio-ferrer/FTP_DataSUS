﻿using System;
using System.Collections.Generic;
using System.Text;

namespace br.com.teczilla.util
{
    public static class AsciiArt
    {
        public static string TecZillaRex
        {
            get
            {
                return @"
                                                                                                                                                                      
                                                                                                                                        ▒▒▒▒                          
                                                                                                                              ▒▒▒▒░░▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒  ▒▒▒▒▒▒▒▒▒▒      
                                                                                                                          ▒▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓░░▓▓▒▒▓▓██▒▒▓▓██▓▓▒▒▒▒▒▒▒▒▒▒
                                                                                                                      ░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▓▓▓▓▒▒░░▒▒▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒
                                                                                                                      ▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒░░▓▓▒▒░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒
                                                                                                                    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒
                                                                                                                  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒██▒▒░░░░░░░░▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒▒▒▒▒
                                                                                      ░░░░░░░░░░▒▒▒▒░░      ░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓    ▓▓▒▒░░    
                                                                      ░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒██                
                                                              ░░░░░░▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒░░▒▒▒▒██▓▓▓▓▒▒▓▓░░                
                                                          ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒░░░░▒▒▒▒▓▓▓▓██▓▓▒▒░░░░            
                                                      ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒░░░░░░▒▒▒▒▒▒▒▒████▒▒▒▒▒▒          
                                                    ▒▒▒▒░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▓▓▒▒▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒░░▓▓▒▒▓▓██▒▒▒▒        
                                                ▒▒▒▒▒▒░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██████▒▒▒▒▒▒▒▒▓▓▒▒▒▒░░▒▒░░░░▒▒▓▓▒▒▓▓▒▒▒▒        
                                          ▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▓▓██▓▓▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▓▓██▒▒▒▒▒▒▓▓██▒▒▒▒▓▓      
                                    ░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██░░  ▒▒▒▒▒▒▓▓▓▓▒▒▒▒██▒▒▒▒▒▒░░    
                            ░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░▒▒▒▒▒▒▒▒▒▒░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████▓▓▓▓              ▒▒▓▓▒▒▓▓▒▒▒▒░░▒▒    
                        ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██████████                      ██▓▓▓▓▒▒      
                ░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▓▓████████░░                            ░░        
            ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▓▓▓▓                                            
          ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓                                                  
      ░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒██                                                  
      ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▓▓                                                    
    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓████████████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▓▓▒▒▒▒▒▒▒▒▒▒██▒▒▒▒                                                    
  ▒▒▒▒▒▒▓▓▓▓        ▓▓        ▓▓▓▓▓▓▓▓  ▓▓▓▓██████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████████▒▒▒▒▒▒▒▒▒▒  ██▓▓▒▒▒▒    ░░▒▒                                        
  ▒▒▒▒░░                                        ██████████▓▓▓▓▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████████████▒▒▒▒  ░░▒▒▒▒▓▓▒▒  ▒▒▒▒▓▓▒▒██▒▒██                                        
    ▒▒▒▒                                              ████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██████████            ▒▒▒▒░░              ▓▓                                        
    ▓▓▒▒                                                    ▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒                  ░░▒▒                                                        
      ▒▒▒▒░░                                                    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒                                                                                      
      ░░▒▒░░                                                ░░██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒                                                                                      
        ░░▒▒▒▒░░                                          ▓▓████▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░                                                                                      
              ▒▒  ▒▒░░                                ▒▒▒▒▓▓██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒                                                                                        
                        ░░                      ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒                                                                                        
                                            ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒██                                                                                          
                                            ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▓▓░░                                                                                          
                                        ░░██▒▒▒▒▓▓██▓▓    ░░▒▒▒▒▒▒▒▒▒▒                                                                                                
                                        ██████▓▓▒▒        ▒▒▒▒▒▒▒▒▒▒░░                                                                                                
                                        ████▓▓▒▒▓▓        ▒▒▒▒▒▒▒▒▒▒                                                                                                  
                                      ░░██▓▓▒▒▒▒▒▒        ▒▒▒▒▒▒▒▒                                                                                                    
                                      ████▓▓▒▒▒▒▒▒        ░░▒▒▒▒▒▒                                                                                                    
                                    ▒▒████▒▒▒▒▓▓░░        ░░▒▒▒▒▒▒▒▒                                                                                                  
                                      ████▒▒▓▓▒▒▒▒          ▒▒▒▒▒▒▒▒                                                                                                  
                                      ░░██▒▒▓▓▓▓            ░░▒▒▒▒▒▒▒▒                                                                                                
                                        ██▓▓▓▓▓▓▒▒▒▒          ▒▒▒▒▒▒▒▒▒▒                                                                                              
                                        ██▓▓▓▓▒▒██▓▓██        ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░                                                                                      
                                          ██▓▓▓▓▒▒██▓▓░░    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░                                                                                    
                                          ▓▓▒▒▓▓  ▓▓▓▓▒▒    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓██                                                                                  
                                                            ██▒▒▒▒▓▓▓▓▓▓▒▒▒▒▓▓▓▓░░░░                                                                                  
                                                              ▒▒▓▓▓▓░░  ▒▒▒▒▒▒▒▒░░                                                                                    

";
            }
        }
    
        public static string TecZillaSmall
        {
            get
            {
                return @"
               __
              / _)
     _/\/\/\_/ /
   _|         /
 _|  (  | (  |
/__.-'|_|--|_|
";
            }
        }
    }
}
