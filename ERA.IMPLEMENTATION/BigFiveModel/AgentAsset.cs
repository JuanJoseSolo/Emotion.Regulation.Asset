using RolePlayCharacter;
using ERA.Utilities;

namespace BigFiveModel
{
    public class AgentAsset:BigFiveModelAsset
    {
        // The agent is the interface that combined the Emotional Regulation Asset and FAtiMA architecture. Here we need to have all FAtiMA depencies.|
        public string Name { get => name; set => name = value; }
        string name = string.Empty;
        public RolePlayCharacterAsset FatimaCharacter { get => fatimaCharacter; set => fatimaCharacter = value; }
        RolePlayCharacterAsset fatimaCharacter = new();
        public AgentAsset(float openness, float conscientiousness, float extraversion, float agreeableness, float neuroticism) :
            base(openness, conscientiousness, extraversion, agreeableness, neuroticism){}
        private void Regulate()
        {
        }
    }
}
