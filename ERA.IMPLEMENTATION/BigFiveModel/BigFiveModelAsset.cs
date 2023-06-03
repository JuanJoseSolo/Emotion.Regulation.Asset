using FLS;
using FLS.MembershipFunctions;
using ScottPlot;
using System.Drawing;

//TODO: Add comments and documentation; add plotting method.
namespace BigFiveModel
{
    /// <summary>
    /// @public class: this class is used to assign or calculate the dominant personality of an agent.
    /// </summary>
    public class BigFiveModelAsset
    {
        /// Globals
        float[] personality_level;
        List<string> traits;
        LinguisticVariable personality;
        LinguisticVariable _strategy;
        List<LinguisticVariable> personalities;
        IMembershipFunction high, strong;
        IMembershipFunction middle, slight;
        IMembershipFunction low, weak;
        /// <summary>
        /// 
        /// </summary>
        public (string personality, float level) Dominant { get => GetDominantPersonality(); }
        
        public List<string> StrategiesToApply { get=> GetStrategiesToApply(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="openness"></param>
        /// <param name="conscientiousness"></param>
        /// <param name="extraversion"></param>
        /// <param name="agreeableness"></param>
        /// <param name="neuroticism"></param>
        public BigFiveModelAsset(float openness, float conscientiousness,float extraversion, float agreeableness, float neuroticism)
        {
            traits = new List<string>() { "Openness","Conscientiousness","Extraversion","Agreeableness","Neuroticism" };
            personality_level = new float[5] { openness, conscientiousness, extraversion, agreeableness, neuroticism };
            personality = new LinguisticVariable("personality");
            _strategy = new LinguisticVariable("NONE");
            personalities = new List<LinguisticVariable>();
            low = personality.MembershipFunctions.AddZShaped("low", 30, 10, 0, 100);
            middle = personality.MembershipFunctions.AddGaussian("middle", 50, 10, 0, 100);
            high = personality.MembershipFunctions.AddSShaped("high", 70, 10, 0, 100);
            strong = _strategy.MembershipFunctions.AddRectangle("NONE", 1, 1);
            slight = _strategy.MembershipFunctions.AddRectangle("NONE", 1, 1);
            weak = _strategy.MembershipFunctions.AddRectangle("NONE", 1, 1);
            GenerateLinguisticValues();
            foreach(var trait in traits)
            {
                personalities.Add(new LinguisticVariable(trait));
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private (string trait, float membership) GetDominantPersonality()
        {
            // Setting the values for each strategy.
            float[,] results = new float[traits.Count, 3];
            for (int i = 0; i < traits.Count; i++)
            {
                results[i,0] = (float)low.Fuzzify(personality_level[i]);
                results[i,1] = (float)middle.Fuzzify(personality_level[i]);
                results[i,2] = (float)high.Fuzzify(personality_level[i]);
            }
            float temp_value = 0;
            (string trait, float membership) dominant_personality=new();
            // Finding the grater value for all strategies.
            for (int i = 0; i < traits.Count; i++)
            {
                if (temp_value < results[i,2])
                {
                    temp_value = results[i,2];
                    float value = (float)Math.Round(temp_value * 100, 2);
                    dominant_personality = new (traits[i], value);
                }
            }
            return dominant_personality;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strategy"></param>
        private void GenerateLinguisticValues(string strategy="NONE")
        {
            _strategy = new LinguisticVariable(strategy);
            weak = _strategy.MembershipFunctions.AddZShaped("weak", 3, 1, 0, 10);
            slight = _strategy.MembershipFunctions.AddGaussian("slight", 5, 1, 0, 10);
            strong = _strategy.MembershipFunctions.AddSShaped("strong", 7, 1, 0, 10);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetPertenency(IFuzzyEngine fuzzyEngine)
        {
            var defuzzy_result = fuzzyEngine.Defuzzify(new
            {
                Openness = (double)personality_level[0],
                Conscientiousness = (double)personality_level[1],
                Extraversion = (double)personality_level[2],
                Agreeableness = (double)personality_level[3],
                Neuroticism = (double)personality_level[4],
            });

            Dictionary<string, double> pre_result = new Dictionary<string, double>()
            {
                { "Weak", weak.Fuzzify(defuzzy_result) },
                { "Slight", slight.Fuzzify(defuzzy_result)},
                { "Strong", strong.Fuzzify(defuzzy_result)}
            };
            return pre_result.Aggregate((force, numerical) => force.Value > numerical.Value ? force : numerical).Key;;
        }
        #region Strategies implementation 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string SituationSelection()
        {
            // rule1 -> IF Conscientiousness is HIGH and Neuroticism is HIGH then SS is Strong applied.
            // rule2 -> IF Conscientiousness is MIDDLE and Neuroticism is MIDDLE then SS is Slight applied.
            // rule3 -> IF Conscientiousness is LOW and Neuroticism is LOW then SS is Weak applied.
            // rule4 -> IF Extraversion is HIGH and Openness is HIGH and Agreeableness is HIGH then SS is Weak applied.
            // rule5 -> IF Extraversion is MIDDLE and Openness is MIDDLE and Agreeableness is MIDDLE then SS is Slight applied.
            // rule6 -> IF Extraversion is LOW and Openness is LOW and Agreeableness is LOW then SS is Strong applies.

            // Openness          -> personalities[0]
            // Conscientiousness -> personalities[1]
            // Extraversion      -> personalities[2]
            // Agreeableness     -> personalities[3]
            // Neuroticism       -> personalities[4]

            GenerateLinguisticValues("Situation.Selection");
            var fuzzyEngine = new FuzzyEngineFactory().Default();
            var rule1 = fuzzyEngine.Rules.If(personalities[1].Is(high).And(personalities[4].Is(high))).Then(_strategy.Is(strong));
            var rule2 = fuzzyEngine.Rules.If(personalities[1].Is(middle).And(personalities[4].Is(middle))).Then(_strategy.Is(slight));
            var rule3 = fuzzyEngine.Rules.If(personalities[1].Is(low).And(personalities[4].Is(low))).Then(_strategy.Is(weak));
            var rule4 = fuzzyEngine.Rules.If(personalities[2].Is(high).And(personalities[0].Is(high)).And(personalities[3].Is(high))).Then(_strategy.Is(weak));
            var rule5 = fuzzyEngine.Rules.If(personalities[2].Is(middle).And(personalities[0].Is(middle)).And(personalities[3].Is(middle))).Then(_strategy.Is(slight));
            var rule6 = fuzzyEngine.Rules.If(personalities[2].Is(low).And(personalities[0].Is(low)).And(personalities[3].Is(low))).Then(_strategy.Is(strong));
            fuzzyEngine.Rules.Add(rule1,rule2,rule3,rule4,rule5,rule6);
            
            return "Situation.Selection -> " + GetPertenency(fuzzyEngine);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string SituationModification()
        {
            // rule1 -> IF Neuroticism is HIGH and Agreeableness is HIGH then SM is Weak applied.
            // rule2 -> IF Neuroticism is MIDDLE and Agreeableness is MIDDLE then SM is Slight applied.
            // rule3 -> IF Neuroticism is LOW and Agreeableness is LOW then SM is Strong applies.
            // rule4 -> IF Conscientiousness is HIGH and Extraversion is HIGH and Openness is HIGH then SM is Strong applied.
            // rule5 -> IF Conscientiousness is MIDDLE and Extraversion is MIDDLE Openness is MIDDLE then SM is Slight applied.
            // rule6 -> IF Conscientiousness is LOW and Extraversion is LOW and Openness is LOW then SM is Weak applied.

            // Openness          -> personalities[0]
            // Conscientiousness -> personalities[1]
            // Extraversion      -> personalities[2]
            // Agreeableness     -> personalities[3]
            // Neuroticism       -> personalities[4]

            GenerateLinguisticValues("Situation.Modification");
            var fuzzyEngine = new FuzzyEngineFactory().Default();
            var rule1 = fuzzyEngine.Rules.If(personalities[4].Is(high).And(personalities[3].Is(high))).Then(_strategy.Is(weak));
            var rule2 = fuzzyEngine.Rules.If(personalities[4].Is(middle).And(personalities[3].Is(middle))).Then(_strategy.Is(slight));
            var rule3 = fuzzyEngine.Rules.If(personalities[4].Is(low).And(personalities[3].Is(low))).Then(_strategy.Is(strong));
            var rule4 = fuzzyEngine.Rules.If(personalities[1].Is(high).And(personalities[2].Is(high)).And(personalities[0].Is(high))).Then(_strategy.Is(strong));
            var rule5 = fuzzyEngine.Rules.If(personalities[1].Is(middle).And(personalities[2].Is(middle)).And(personalities[0].Is(middle))).Then(_strategy.Is(slight));
            var rule6 = fuzzyEngine.Rules.If(personalities[1].Is(low).And(personalities[2].Is(low)).And(personalities[0].Is(low))).Then(_strategy.Is(slight));
            fuzzyEngine.Rules.Add(rule1,rule2,rule3,rule4,rule5,rule6);
            
            return "Situation.Modification -> " + GetPertenency(fuzzyEngine);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string AttentionalDeployment()
        {
            // rule1 -> IF Openness is HIGH and Conscientiousness is HIGH and Agreeableness is HIGH and Extraversion is HIGH then AD is Strong applied.
            // rule2 -> IF Openness is MIDDLE and Conscientiousness is MIDDLE and Agreeableness is MIDDLE and Extraversion is MIDDLE then AD is Slight applied.
            // rule3 -> IF Openness is LOW and Conscientiousness is LOW and Agreeableness is LoW and Extraversion is LOW then AD is Weak applied.
            // rule4 -> IF Neuroticism is HIGH then AD is Weak applied.
            // rule5 -> IF Neuroticism is MIDDLE then AD is Slight applied.
            // rule6 -> IF Neuroticism is LOW then AD is Strong applied.

            // Openness          -> personalities[0]
            // Conscientiousness -> personalities[1]
            // Extraversion      -> personalities[2]
            // Agreeableness     -> personalities[3]
            // Neuroticism       -> personalities[4]

            GenerateLinguisticValues("Attentional.Deployment");
            var fuzzyEngine = new FuzzyEngineFactory().Default();
            var rule1 = fuzzyEngine.Rules.If(personalities[0].Is(high).And(personalities[1].Is(high)).And(personalities[3].Is(high)).And(personalities[2].Is(high))).Then(_strategy.Is(strong));
            var rule2 = fuzzyEngine.Rules.If(personalities[0].Is(slight).And(personalities[1].Is(slight)).And(personalities[3].Is(slight)).And(personalities[2].Is(slight))).Then(_strategy.Is(slight));
            var rule3 = fuzzyEngine.Rules.If(personalities[0].Is(low).And(personalities[1].Is(low)).And(personalities[3].Is(low)).And(personalities[2].Is(low))).Then(_strategy.Is(weak));
            var rule4 = fuzzyEngine.Rules.If(personalities[4].Is(high)).Then(_strategy.Is(weak));
            var rule5 = fuzzyEngine.Rules.If(personalities[4].Is(middle)).Then(_strategy.Is(slight));
            var rule6 = fuzzyEngine.Rules.If(personalities[4].Is(low)).Then(_strategy.Is(strong));
            fuzzyEngine.Rules.Add(rule1,rule2,rule3,rule4,rule5,rule6);
            
            return "Attentional.Deployment -> " + GetPertenency(fuzzyEngine);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string CongnitiveChange()
        {
            // rule1 -> IF Openness is HIGH and Conscientiousness is HIGH and Agreeableness is HIGH and Extraversion is HIGH then AD is Strong applied.
            // rule2 -> IF Openness is MIDDLE and Conscientiousness is MIDDLE and Agreeableness is MIDDLE and Extraversion is MIDDLE then AD is Slight applied.
            // rule3 -> IF Openness is LOW and Conscientiousness is LOW and Agreeableness is LoW and Extraversion is LOW then AD is Weak applied.
            // rule4 -> IF Neuroticism is HIGH then AD is Weak applied.
            // rule5 -> IF Neuroticism is MIDDLE then AD is Slight applied.
            // rule6 -> IF Neuroticism is LOW then AD is Strong applied.

            // Openness          -> personalities[0]
            // Conscientiousness -> personalities[1]
            // Extraversion      -> personalities[2]
            // Agreeableness     -> personalities[3]
            // Neuroticism       -> personalities[4]

            GenerateLinguisticValues("Attentional.Deployment");
            var fuzzyEngine = new FuzzyEngineFactory().Default();
            var rule1 = fuzzyEngine.Rules.If(personalities[0].Is(high).And(personalities[1].Is(high)).And(personalities[3].Is(high)).And(personalities[2].Is(high))).Then(_strategy.Is(strong));
            var rule2 = fuzzyEngine.Rules.If(personalities[0].Is(slight).And(personalities[1].Is(slight)).And(personalities[3].Is(slight)).And(personalities[2].Is(slight))).Then(_strategy.Is(slight));
            var rule3 = fuzzyEngine.Rules.If(personalities[0].Is(low).And(personalities[1].Is(low)).And(personalities[3].Is(low)).And(personalities[2].Is(low))).Then(_strategy.Is(weak));
            var rule4 = fuzzyEngine.Rules.If(personalities[4].Is(high)).Then(_strategy.Is(weak));
            var rule5 = fuzzyEngine.Rules.If(personalities[4].Is(middle)).Then(_strategy.Is(slight));
            var rule6 = fuzzyEngine.Rules.If(personalities[4].Is(low)).Then(_strategy.Is(strong));
            fuzzyEngine.Rules.Add(rule1,rule2,rule3,rule4,rule5,rule6);
            
            return "Attentional.Deployment -> " + GetPertenency(fuzzyEngine);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string ResponseModulation()
        {
            // rule1 -> IF Openness is HIGH and Conscientiousness is HIGH and Agreeableness is HIGH and Extraversion is HIGH then AD is Strong applied.
            // rule2 -> IF Openness is MIDDLE and Conscientiousness is MIDDLE and Agreeableness is MIDDLE and Extraversion is MIDDLE then AD is Slight applied.
            // rule3 -> IF Openness is LOW and Conscientiousness is LOW and Agreeableness is LoW and Extraversion is LOW then AD is Weak applied.
            // rule4 -> IF Neuroticism is HIGH then AD is Weak applied.
            // rule5 -> IF Neuroticism is MIDDLE then AD is Slight applied.
            // rule6 -> IF Neuroticism is LOW then AD is Strong applied.

            // Openness          -> personalities[0]
            // Conscientiousness -> personalities[1]
            // Extraversion      -> personalities[2]
            // Agreeableness     -> personalities[3]
            // Neuroticism       -> personalities[4]

            GenerateLinguisticValues("Response.Modulation");
            var fuzzyEngine = new FuzzyEngineFactory().Default();
            var rule1 = fuzzyEngine.Rules.If(personalities[0].Is(high).And(personalities[1].Is(high)).And(personalities[2].Is(high)).And(personalities[3].Is(high)).And(personalities[4].Is(high))).Then(_strategy.Is(weak));
            var rule2 = fuzzyEngine.Rules.If(personalities[0].Is(middle).And(personalities[1].Is(middle)).And(personalities[2].Is(middle)).And(personalities[3].Is(middle)).And(personalities[4].Is(middle))).Then(_strategy.Is(slight));
            var rule3 = fuzzyEngine.Rules.If(personalities[0].Is(low).And(personalities[1].Is(low)).And(personalities[2].Is(low)).And(personalities[3].Is(low)).And(personalities[4].Is(low))).Then(_strategy.Is(strong));
            fuzzyEngine.Rules.Add(rule1,rule2,rule3);
            
            return "Response.Modulation -> " + GetPertenency(fuzzyEngine);
        }
        #endregion
        private List<string> GetStrategiesForce()
        {
            return new List<string>()
            {
                this.SituationSelection(),
                this.SituationModification(),
                this.AttentionalDeployment(),
                this.CongnitiveChange(),
                this.ResponseModulation()
            };
        }
        private List<string> GetStrategiesToApply()
        {
            var strategies = GetStrategiesForce();
            var apply = new List<string>();
            string temp_strategy = "";
            foreach (var strategy in strategies)
            { 
                if (strategy.Contains("Strong"))
                {
                    if(strategy != temp_strategy)
                    {
                        var str = strategy.Split("->")[0];
                        var _str = str.Replace('.', ' ');
                        apply.Add(_str);
                        temp_strategy = strategy;
                    }
                }
            }
            return apply;
        }

        public void Plot()
        {
            var plots = new Dictionary<string, List<IMembershipFunction>>()
            {
                {"Strategies", new List<IMembershipFunction>() { weak, slight, strong } },
                {"Personality", new List<IMembershipFunction>() { low, middle, high } }
            };
            var level_names = new List<string>() { "low", "middle", "high" };
            string[] customColors = { "#0099ff", "#64b15f", "#e83225" }; //colors : http://medialab.github.io/iwanthue/
            var n = 0;
            int limits = 0;
            foreach(var list in plots)
            {
                if (plots.Keys.ToList()[n] == "Strategies") { limits = 10; } else { limits = 100; };
                var plot = new Plot(1200, 900) { Palette=Palette.FromHtmlColors(customColors)};
    
                var levelList = new List<List<double>>() { new List<double>(),new List<double>(), new List<double>()};
                var x_axis = DataGen.Range(0, limits+1, 1);
                int j = 0;
                foreach (var function in list.Value)
                {
                    for (int i = 0; i < limits+1; i++)
                    {
                        levelList[j].Add(function.Fuzzify(i));
                    }
                    j ++;
                }
                plot.Title("Personality", size: 30);
                plot.SetAxisLimitsY(0, 1.15);
                plot.SetAxisLimitsX(0, limits);
                plot.YLabel("Membership");
                plot.XLabel("Personality level");
                plot.YAxis.LabelStyle(fontSize: 25);
                plot.YAxis.TickLabelStyle(fontSize: 17);
                plot.XAxis.LabelStyle(fontSize: 25);
                plot.XAxis.TickLabelStyle(fontSize: 17);
                plot.Legend(true, location: Alignment.UpperLeft).FontSize = 15;
                j = 0; 
                foreach(var level in levelList)
                {
                    plot.AddFill(x_axis.ToArray(), level.ToArray()).Label = level_names[j];
                    j++;
                }
                plot.SaveFig($"../../../../{plots.Keys.ToList()[n]}.png");
                n++;
            }
        }
    }
}