using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alapaca_tour_Winform_dotNet.Models;
using System.Reflection.Emit;

namespace Alapaca_tour_Winform_dotNet.Models
{
     class TimeCalc
    {
        private Planner planner;

        public TimeCalc(Planner planner)
        {
            this.planner = planner;
        }


        public string MeasureTimeForOneDayTravel(Tuple<List<Node>, float> path)
        {
            float workAndTravelTime = 0.0f;
            int sumAlpaca = 0;
            float sumDistance = 0.0f;
            float packingTime = 30.0f;
            int i = 0;

            var result = new System.Text.StringBuilder();

            while (i < path.Item1.Count)
            {
                workAndTravelTime += (path.Item1[i].Weight * 2.0f) + packingTime + (path.Item1[i].AlpacaNr * 25.0f);
                sumAlpaca += path.Item1[i].AlpacaNr;
                sumDistance += path.Item1[i].Weight * 2.0f;

                result.AppendLine(i +". "+path.Item1[i].Name + ":\t\t\t" + path.Item1[i].Weight + "\tkm\talpakák:" + path.Item1[i].AlpacaNr + "\t\t\tszállás: " + path.Item1[i].Hotel);
                //result.AppendLine($"{path.Item1[i].Name,-20}táv: {path.Item1[i].Weight,-5}km        alpakaszám: {path.Item1[i].AlpacaNr,3}       szallas: {path.Item1[i].Hotel,15}");
                //result.AppendLine($"{path.Item1[i].Name,-20} : {path.Item1[i].Weight,-8}km       alpakak:{path.Item1[i].AlpacaNr}");


                if (path.Item1[i].AlpacaNr > 18)
                {
                    result.AppendLine();
                    result.AppendLine("A települesen az alpakak nyirása több nap alatt oldható meg.");
                    break;
                }

                if (workAndTravelTime > 774.0f || sumAlpaca > 18)
                {     
                    result.AppendLine("A napi utazási és munkaidő/alpakaszám elérte a felső határt.");
                    //Ellenőrizd, hogy az aktuális elem az utolsó-e
                    if (i != path.Item1.Count - 1) //ha az adott elem ahol átlépi az 1 napos munkaidőt nem az utolsó elem írja ki hol tart egyébként ne, mert nem kell hogy duplán kiíírja
                    {
                        result.AppendLine();
                        result.AppendLine("Össz alpakaszám:                                       " + sumAlpaca);
                        result.AppendLine("Egész úton(oda-vissza) megtett távolság: " + sumDistance);
                    }
                    break;
                }
               
                i++;
            }

            result.AppendLine();

            result.AppendLine("Össz alpakaszám:                                       " + sumAlpaca);
            result.AppendLine("Egész uton(oda-vissza) megtett távolság: " + sumDistance);
            return result.ToString();
        }

        public string MeasureTimeForHotelTravel(Tuple<List<Node>, float> mainPath)
        {
            float workAndTravelTimePerDay = 0.0f;
            float distanceTemp = 0.0f;
            float allDistance = 0.0f;
            float PackingTime = 30.0f;
            const float shiftTime = 774.0f;
            int alpacaCounter = 0;
            int alpacaPerDay = 0;

            //string hotel;
            //float lastWorkTime;

            var result = new System.Text.StringBuilder();

            DateTime currentTime = DateTime.Now;
            result.AppendLine("Aktuális dátum: " + currentTime.ToString("yyyy-MM-dd"));
           
            int i = 0;

            //int shiftCounter = 1;
            while (i < mainPath.Item1.Count)
            {
                distanceTemp += mainPath.Item1[i].Weight;
                int alpacaNr = mainPath.Item1[i].AlpacaNr;
                string hotelIt = mainPath.Item1[i].Hotel;
                allDistance += mainPath.Item1[i].Weight;

                workAndTravelTimePerDay += distanceTemp + PackingTime + alpacaNr * 25.0f;
                alpacaPerDay += alpacaNr;
                alpacaCounter += alpacaNr;

                if (workAndTravelTimePerDay < shiftTime)
                {
                    if (i == 0)
                    {
                        result.AppendLine(i + ". " + mainPath.Item1[i].Name + "\tinduló állomás");
                    }
                    else
                    {
                        result.AppendLine(i + ". " + mainPath.Item1[i].Name + ": " + mainPath.Item1[i].Weight + " km\tnapi utazott távolság: " + distanceTemp + " km\talpakák: " + alpacaNr + "\tnapi alpakaszám: " + alpacaPerDay + "\tszállás: " + hotelIt);

                        if (alpacaPerDay > 18)
                        {
                            result.AppendLine(i + ". " + mainPath.Item1[i].Name + ": " + mainPath.Item1[i].Weight + " km\tnapi utazott távolság: " + distanceTemp + " km\talpakák: " + alpacaNr + "\tnapi alpakaszám: " + alpacaPerDay + "\tszállás: " + hotelIt);
                            while (alpacaPerDay > 18)
                            {
                                result.AppendLine();
                                currentTime = currentTime.AddDays(1);
                                result.AppendLine(currentTime.ToString("yyyy-MM-dd") + ":");
                                alpacaPerDay -= 18;
                                result.AppendLine(i + ". " + mainPath.Item1[i].Name + ": " + mainPath.Item1[i].Weight + " km\tnapi utazott távolság: " + distanceTemp + " km\talpakák: " + alpacaNr + "\tnapi alpakaszám: " + alpacaPerDay + "\tszállás: " + hotelIt);
                                distanceTemp = 0.0f;
                                alpacaPerDay = Math.Abs(alpacaPerDay);
                            }
                        }
                    }
                }
                else
                {
                    if (alpacaPerDay > 18)
                    {
                        result.AppendLine(i + ". " + mainPath.Item1[i].Name + ": " + mainPath.Item1[i].Weight + " km\tnapi utazott távolság: " + distanceTemp + " km\talpakák: " + alpacaNr + "\tnapi alpakaszám: " + alpacaPerDay + "\tszállás: " + hotelIt);

                        while (alpacaPerDay > 18)
                        {
                            result.AppendLine();
                            currentTime = currentTime.AddDays(1);
                            result.AppendLine(currentTime.ToString("yyyy-MM-dd") + ":");
                            alpacaPerDay -= 18;
                            alpacaPerDay = Math.Abs(alpacaPerDay);
                            result.AppendLine(i + ". " + mainPath.Item1[i].Name + ": " + mainPath.Item1[i].Weight + " km\tnapi utazott távolság: " + distanceTemp + " km\talpakák: " + alpacaNr + "\tnapi alpakaszám: " + alpacaPerDay + "\tszállás: " + hotelIt);
                            distanceTemp = 0.0f;
                        }
                    }
                    else
                    {
                        result.AppendLine(i + ". " + mainPath.Item1[i].Name + ": " + mainPath.Item1[i].Weight + " km\tnapi utazott távolság: " + distanceTemp + " km\talpakák: " + alpacaNr + "\tnapi alpakaszám: " + alpacaPerDay + "\tszállás: " + hotelIt);
                        result.AppendLine();
                        currentTime = currentTime.AddDays(1);
                        result.AppendLine(currentTime.ToString("yyyy-MM-dd") + ":");
                        distanceTemp = 0.0f;
                        result.AppendLine(i + ". " + mainPath.Item1[i].Name + ": " + mainPath.Item1[i].Weight + " km\tnapi utazott távolság: " + distanceTemp + " km\talpakák: " + alpacaNr + "\tnapi alpakaszam: " + alpacaPerDay + "\tszállás: " + hotelIt);
                        workAndTravelTimePerDay = 0.0f;
                        alpacaPerDay = 0;
                    }
                }
                i++;
            }

            result.AppendLine();
            result.AppendLine("Össz alpaka szám: " + alpacaCounter);
            result.AppendLine("Egész úton megtett távolság: " + allDistance);


            return result.ToString();
        }
    }
}
