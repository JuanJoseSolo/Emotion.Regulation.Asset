using System;
using BigFiveModel;

namespace BigFiveModel.Tutorial
{
    internal class BFM
    {
        // The main flow of the script.
        static void Main(string[] args)
        {   // 1. Creation of the object.
            BigFiveModelAsset big_five_model = new BigFiveModelAsset(openness:0.0f,conscientiousness:0.0f,extraversion:99.0f,agreeableness:0.0f,neuroticism:0.0f);
            var dominant = big_five_model.Dominant;
            Console.WriteLine($"The dominant personality is: {dominant.personality}");
            Console.WriteLine($"And its pertenency level is: {dominant.level}");
            var strategies = big_five_model.StrategiesToApply;
            Console.WriteLine("According to the personality, the strategies to apply are the following:");
            strategies.ForEach(strategy => Console.WriteLine(" - "+strategy.ToString()));
            big_five_model.Plot();
        }
    }
}