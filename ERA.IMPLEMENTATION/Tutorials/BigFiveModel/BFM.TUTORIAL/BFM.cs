using System;
using BigFiveModel;

namespace BigFiveModel.Tutorial
{
    internal class BFM
    {
        static void Main(string[] args)
        {   
            // The class BigFiveModel Needs five parameters, which are the traits.
            BigFiveModelAsset big_five_model = new BigFiveModelAsset(openness:0.0f,conscientiousness:0.0f,extraversion:99.0f,agreeableness:0.0f,neuroticism:0.0f);
            // The atribute 'Dominant' is a tuple that contains the dominant personality and its value.
            var dominant = big_five_model.Dominant;
            Console.WriteLine($"The dominant personality is: {dominant.personality}");
            Console.WriteLine($"And its pertenency level is: {dominant.level}");
            // The atribute 'StrategiesToApply', is a list that contains all strategies that the Agent could apply.
            var strategies = big_five_model.StrategiesToApply;
            Console.WriteLine("According to the personality, the strategies to apply are the following:");
            strategies.ForEach(strategy => Console.WriteLine(" - "+strategy.ToString()));
            // The method 'Plot()' generates the result plots of the fuzzy logic implemented.
            big_five_model.GetFuzzyPlots();
        }
    }
}