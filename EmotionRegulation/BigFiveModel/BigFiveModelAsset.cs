using FLS;
using FLS.MembershipFunctions;
//TODO: Add comments and documentation; add plotting method.
namespace BigFiveModel
{
    public class BigFiveModelAsset
    {
        IMembershipFunction low;
        IMembershipFunction middle;
        IMembershipFunction high;
        LinguisticVariable personality;
        float conscientiousness;
        float extraversion;
        float neuroticism;
        float openness;
        float agreeableness;
        float[,] results = new float[5,3];
        public (float value, string personality) Personality { get => GetDominantPersonality(); }

        /// <summary>
        /// 
        /// </summary>
        public BigFiveModelAsset(float conscientiousness, float extraversion, float neuroticism, float openness, float agreeableness)
        {
            this.conscientiousness = conscientiousness;
            this.extraversion = extraversion;
            this.neuroticism = neuroticism;
            this.openness = openness;
            this.agreeableness = agreeableness;
            personality = new LinguisticVariable("personality");
            low = personality.MembershipFunctions.AddZShaped("low", 30, 10, 0, 100);
            middle = personality.MembershipFunctions.AddGaussian("middle", 50, 10, 0, 100);
            high = personality.MembershipFunctions.AddSShaped("high", 70, 10, 0, 100);
        }
        /// <summary>
        /// 
        /// </summary>
        private void Fuzzify() 
        {
            float[] personality_level = new float[5] {conscientiousness, extraversion, neuroticism, openness, agreeableness};
            results = new float[5,3];
            for(int i=0; i<5; i++) 
            {
                results[i,0] = (float)low.Fuzzify(personality_level[i]);
                results[i,1] = (float)middle.Fuzzify(personality_level[i]);
                results[i,2] = (float)high.Fuzzify(personality_level[i]);
            }
        }

        private (float value, string dominant) GetDominantPersonality()
        {
            Fuzzify();
            double temp_value = 0;
            (int personality, float value) inf_personality = new (255,255);
            for(int i=0; i<5; i++)
            {
                if (temp_value < results[i, 2])
                {
                    temp_value = results[i, 2];
                    inf_personality.personality = i;
                }
            }
            float value = (float)Math.Round(temp_value * 100,2);
            (float value, string personality) dominant_personality = new (value,"None");
            if(inf_personality.personality == 0) { dominant_personality.personality = "Conscientiousness"; }
            else if(inf_personality.personality == 1) { dominant_personality.personality = "Extraversion"; }
            else if(inf_personality.personality == 2) { dominant_personality.personality = "Neuroticism"; }
            else if(inf_personality.personality == 3) { dominant_personality.personality = "Openness"; }
            else if(inf_personality.personality == 4) { dominant_personality.personality = "Agreeableness"; }
            else { dominant_personality.personality = "None"; }

            return dominant_personality;
        }
    }
}