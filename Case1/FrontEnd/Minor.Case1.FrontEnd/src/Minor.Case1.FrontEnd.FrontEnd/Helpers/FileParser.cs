using Microsoft.AspNetCore.Http;
using Minor.Case1.FrontEnd.FrontEnd.Agents.Models;
using Minor.Case1.FrontEnd.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.FrontEnd.FrontEnd.Helpers
{
    public static class FileParser
    {
        public static FileParserViewModel Parse(IFormFile file)
        {
            var cursusInstanties = new List<CursusInstantie>();
            string errorMessage = "";
            if (file != null && file.Length > 0)
            {
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    int regelnummer = 1;
                    //Zolang de streamreader nog kan peeken, de file blijven lezen
                    while (streamReader.Peek() != -1)
                    {
                        var titelLine = streamReader.ReadLine().Split(':');
                        var cursusCodeLine = streamReader.ReadLine().Split(':');
                        var duurLine = streamReader.ReadLine().Replace(" ", "").Split(':');
                        var startdatumLine = streamReader.ReadLine().Split(':');
                        var legeLine = streamReader.ReadLine();
                        string[] startdatum = null;  
                                  
                        //Check of regel 1 een Titel veld is            
                        if (titelLine[0] != "Titel")
                        {
                            errorMessage = string.Format("Er is een fout gevonden op regel {0}", regelnummer);
                            break;
                        }
                        regelnummer++;
                        //Check of regel 2 een Cursuscode veld is
                        if (cursusCodeLine[0] != "Cursuscode")
                        {
                            errorMessage = string.Format("Er is een fout gevonden op regel {0}", regelnummer);
                            break;
                        }
                        regelnummer++;
                        //Check of regel 3 een Duur veld is
                        //of regel 3 langer dan 2 chars is zodat kan worden bepaald of dagen achter het getal staat
                        if (duurLine[0] != "Duur" || duurLine[1].Length <= 2)
                        {
                            errorMessage = string.Format("Er is een fout gevonden op regel {0}", regelnummer);
                            break;
                        }                        
                        regelnummer++;
                        //Check of startdatum een datum bevat
                        if (startdatumLine.Count() == 2)
                        {
                            startdatum = startdatumLine[1].Replace(" ", "").Split('/');
                        }
                        else
                        {
                            errorMessage = string.Format("Er is een fout gevonden op regel {0}", regelnummer);
                            break;
                        }
                        //Check of het eerste getal van startdatum kleiner dan 2 is om te bepalen of hij goed gesplitst is
                        //Check of regel 4 een startdatum veld is
                        if ( startdatum[0].Length > 2
                            || startdatumLine[0] != "Startdatum")
                        {
                            errorMessage = string.Format("Er is een fout gevonden op regel {0}", regelnummer);
                            break;
                        }                  
                        regelnummer++;
                        //Check of er een lege lijn is
                        if (legeLine.Any())
                        {
                            errorMessage = string.Format("Er is een fout gevonden op regel {0}", regelnummer);
                            break;
                        }                                            
                       
                        cursusInstanties.Add(new CursusInstantie()
                        {
                            CursusId = cursusCodeLine[1],
                            StartDatum = new DateTime(int.Parse(startdatum[2]), int.Parse(startdatum[1]), int.Parse(startdatum[0])),
                            Cursus = new Cursus()
                            {
                                Code = cursusCodeLine[1],
                                Dagen = int.Parse(duurLine[1].ElementAt(0).ToString()),
                                Titel = titelLine[1],
                            }
                        });
                        
                    }
                }
                return new FileParserViewModel()
                {
                    ErrorMesage = errorMessage,
                    Instanties = cursusInstanties,
                };
            }
            return new FileParserViewModel()
            {
                ErrorMesage = "De file bevat geen inhoud",
            }; ;
        }
    }
}
