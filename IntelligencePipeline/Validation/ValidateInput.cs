using System;
using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Validation
{
    public class ValidateInput
    {
        public DateTime ValidDate()
            
        {   
            bool isInvalidDate = true;
            DateTime result = default;
            while(isInvalidDate)
            {               
                string userInput = Console.ReadLine();
                if(!DateTime.TryParse(userInput, out result))
                {
                    System.Console.WriteLine("Invalid DateTime input");
                }
                else{isInvalidDate = false;} 
            }
            return result;
            
        }

        public double ValidDouble()
        {
            bool isInvalidDouble = true;
            double result = 0;
            while(isInvalidDouble)
            {
                string userInput = Console.ReadLine();
                if(!double.TryParse(userInput, out result))
                {
                    System.Console.WriteLine("Invalid input");
                }
                else{isInvalidDouble = false;} 
            }
            return result;
        }

        public int ValidInt()
        {
            bool isInvalidInt = true;
            int result = 0;
            while(isInvalidInt)
            {
                string userInput = Console.ReadLine();
                if(!int.TryParse(userInput, out result))
                {
                    System.Console.WriteLine("Invalid input");
                }
                else{isInvalidInt = false;} 
            }
            return result;
        }

        public Language ValidLanguageEnum()
        {
            bool isInvalidEnum = true;
            Language result = Language.Hebrew;
            while (isInvalidEnum)
            {
                string userInput = Console.ReadLine();
                if(!Enum.TryParse(userInput, true, out result))
                {
                     System.Console.WriteLine("Invalid input");
                }
                else{isInvalidEnum = false;}               
            }
            return result;
        }
    }
}