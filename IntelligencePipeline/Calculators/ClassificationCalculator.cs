using System;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Models.Enums;

namespace IntelligencePipeline.Calculators
{
   public class ClassificationCalculator
    {
        public Classification Calculate(Report report)
        {
            //Check and set TopSecret classification.
            if(report.Priority == Priority.Critical){return Classification.TopSecret;}
            if(report is SignalReport signalTopSecret 
                &&
                ContainsKeyword(signalTopSecret.Content.ToLower(), "target", "attack", "missile"))
            {
                return Classification.TopSecret;
            }

            //Check and set Secret classification.
            if(report.Priority == Priority.High){return Classification.Secret;}
            if(report is SignalReport){return Classification.Secret;}
            if(ContainsKeyword(report.Description.ToLower(), "border ","weapon")){return Classification.Secret;}

            //Check and set Restricted classification.
            if(report.Priority == Priority.Medium){return Classification.Restricted;}
            if(report is SoldierReport){return Classification.Restricted;}

            return Classification.Unclassified;
        }

        private bool ContainsKeyword(string text, params string[] keywords)
        {
            foreach (string key in keywords)
            {
                if(text.Contains(key)){return true;}
            }
            return false;
        }
    }
}