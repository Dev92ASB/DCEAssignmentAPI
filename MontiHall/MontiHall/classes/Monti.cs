using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontiHall.classes
{
    public class Monti
    {

        public static string RandDor;
        public static int Plays =0;
        public static int Wins = 0;
        public static int Los = 0;

        public static int Switchs = 0;
        public static int keep = 0;

        public static int SwitchWins = 0;
        public static int keepWins = 0;

        public static int SwithLoss = 0;
        public static int keepLoss = 0;

        public static double winspc = 0;
        public static double losspc = 0;
        public static double Keepwinspc = 0;
        public static double SwithWinspc = 0;

       
        public static double KeepLossPc = 0;
        public static double Switchlospc = 0;



        public string[] Dors; 

        public void ResetData()
        {
         RandDor = "";
         Plays = 0;
         Wins = 0;
         Los = 0;
         Switchs = 0;
         SwitchWins = 0;
         keep = 0;
         keepWins = 0;
         winspc = 0;
         Keepwinspc = 0;
         SwithWinspc = 0;
       
         KeepLossPc = 0;
         Switchlospc = 0;
         SwithLoss = 0;
         keepLoss = 0;
            losspc = 0;
            Dors = new string[3] { "A", "B", "C" };
         RandDor = "";

        }

        public void RepaetAction(string Atype, int Count)
        {
            for (int I = 1; I <= Count; I++)
            {
                GetDandomSelect();
                string selected = GetRandomDor();
                string open = Opendor(selected);
                if (Atype == "Keep")
                {
                    Action("Keep", selected);
                }
                else if (Atype == "Switch")
                {
                    string[] DORS = new string[3] { "A", "B", "C" };
                    List<string> myList = new List<string>(DORS);
                    myList.Remove(selected);
                    myList.Remove(open);
                    string[] Switchdoorar = myList.ToArray();
                    string Switchdor = Switchdoorar[0];

                    Action("Switch", Switchdor);

                }
            }
            CalculatePercentage();
        }

        private void Reset()
        {
            Dors = new string[3] { "A", "B", "C" };
            //RandDor = "";
        }
        private string GetRandomDor()
        {

            Reset();
            Random rd = new Random();
            int randomIndex = rd.Next(0, 3);
            //RandDor = 
            return Dors[randomIndex]; 

        }
        public string GetDandomSelect()
        {
            RandDor = GetRandomDor();
            return RandDor;
        }
        public string Opendor(string selected)
        {
           Reset();
           int removeIndex = Array.IndexOf(Dors, selected);
           Dors = Dors.Where((val, indx) => indx != removeIndex).ToArray();
           string NextDor= "";           
           Random rd = new Random();
           int randindex = rd.Next(0, 2);
           NextDor = Dors[randindex];
            
           if(NextDor == RandDor)
            {
                int removeNextDor = Array.IndexOf(Dors, NextDor);
                Dors = Dors.Where((val, indx) => indx != removeNextDor).ToArray();
                NextDor = Dors[0];
            }

            Reset();
            return NextDor;
            

        }

        private void increaseActionsWins(string Atype)
        {
            switch (Atype)
            {
                case "Switch":
                    ++SwitchWins;
                    break;
                case "Keep":
                    ++keepWins;
                    break;
            }
        }

        private void increaseActions(string Atype)
        {
            switch (Atype)
            {
                case "Switch":
                    ++Switchs;
                    break;
                case "Keep":
                    ++keep;
                    break;
            }
        }

        private void increaseActionsLoss(string Atype)
        {
            switch (Atype)
            {
                case "Switch":
                    ++SwithLoss;
                    break;
                case "Keep":
                    ++keepLoss;
                    break;
            }
        }

    
        public string Action(string Atype , string dname)
        {
            string Message;
            ++Plays;
            increaseActions(Atype);

            if (dname == RandDor)
            {
                ++Wins;
                increaseActionsWins(Atype);
                Message = "You Won";
            }
            else
            {
                increaseActionsLoss(Atype);
                ++Los;
                Message = "You Lose";
            }

            return Message;
        }
        private void CalculatePercentage()
        {
            if (Plays >= 0)
            {
                winspc = ((double)Wins / Plays) * 100;
                losspc = ((double)Los / Plays) * 100;
                Keepwinspc = ((double)keepWins / Plays) * 100;
                SwithWinspc = ((double)SwitchWins / Plays) * 100;

                losspc = ((double)Los / Plays) * 100;
                Switchlospc = ((double)SwithLoss / Plays) * 100;
                KeepLossPc = ((double)keepLoss / Plays) * 100;
            }
        }
        public Dictionary<string,double> returnGameData()
        {

            CalculatePercentage();

            var Data = new Dictionary<string, double>
            {
                {"All-win-per" ,winspc },
                {"All-loss-per" ,losspc },
                {"Keep-win-per", Keepwinspc },
                {"Keep-Los-per", KeepLossPc },
                {"Switch-win-per",SwithWinspc },
                {"Switch-Los-per", Switchlospc },
                {"WINS",Wins },
                {"LOSS",Los },
                {"Played",Plays },
                {"Switch" , Switchs},
                {"Keep", keep },
                {"Switch-wins",SwitchWins },
                {"Switch-Loss",SwithLoss },
                {"keep-wins",keepWins },
                {"keep-Loss",keepLoss }



        };

            return Data;
           
        }
    }
}
