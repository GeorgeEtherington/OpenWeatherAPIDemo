using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace WeatherGameApp
{
   public class GameManager
    {
        public int GuessesMade = 0;
        public City CorrectAnswer = new City();
        public City CurrentGuess = new City();
        public string Guess;
        public bool AnswerGuessed = false;
        public class CityArray
        {
            public string CityName { get; set; }
        }

       public CityArray [] Cities;
        public void Init()
        {
            CreateCityArray();
            CorrectAnswer.SetData(GenerateAnswer());

        }

        public void CreateCityArray()
        {
            var Root = Path.GetPathRoot(Path.GetFullPath("."));
            StreamReader SR = new StreamReader("../../../../WeatherGameApp/Cities.json");
            string json = SR.ReadToEnd();
            this.Cities = JsonConvert.DeserializeObject<CityArray[]>(json);
        }
        public string GenerateAnswer()
        {
            Random random = new Random();
            return Cities[random.Next(0, Cities.Length-1)].CityName;
        }

      public void GetGuess()
        {
            Console.WriteLine("Please Enter Your Guess.");
            Guess = Console.ReadLine();
        }

        public void CheckGuess()
        {

          
            {
               
                bool bValidInput = CheckGuessIsValid(Guess);
                if (!bValidInput)    
                {
                    Console.WriteLine("Please Enter a Valid Answer");
                    return;
                }
            }
            if (CheckGuessIsCorrect())
            {
                AnswerGuessed = true;
                Console.WriteLine("You Win!");
            }
            else
            {
                CompareAnswerAndGuess();
            }
           

        }

        public bool CheckGuessIsValid(string TempGuess)
        {
            for(int i = 0; i <=Cities.Length-1; i++)
            {
                if  (string.Equals(TempGuess, Cities[i].CityName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckGuessIsCorrect()
        {
            return string.Equals(Guess, CorrectAnswer.CityData.name, StringComparison.OrdinalIgnoreCase);
        }

        public void CompareAnswerAndGuess()
        {
            CurrentGuess.SetData(Guess);
            if(CompareDouble(CurrentGuess.CityData.coord.lat, CorrectAnswer.CityData.coord.lat))
            {
                Console.WriteLine("The City is Further North");
            }
            else
            {
                Console.WriteLine("The City is Further South");
            }

            if (CompareDouble(CurrentGuess.CityData.coord.lon, CorrectAnswer.CityData.coord.lon))
            {
                Console.WriteLine("The City is Further East");
            }
            else
            {
                Console.WriteLine("The City is Further West");
            }


        }
        public bool CompareDouble(Double i, Double j)
        {
            bool comaprison;
            if (i < j)
            {
                comaprison = true;
            }
            else
            {
                comaprison = false;
            }
            return comaprison;
        } 
    }
}
