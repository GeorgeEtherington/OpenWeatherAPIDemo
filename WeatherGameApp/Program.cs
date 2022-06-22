using System;
using System.IO;

namespace WeatherGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.Init();
            while (!gm.AnswerGuessed)
            {
                gm.GetGuess();
                gm.CheckGuess();
            }
        }
    }
}
