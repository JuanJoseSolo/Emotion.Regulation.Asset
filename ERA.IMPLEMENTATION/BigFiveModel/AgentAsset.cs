using RolePlayCharacter;
using ERA.Utilities;

namespace BigFiveModel
{
    public class AgentAsset:BigFiveModelAsset
    {
        // The agent is the interface that combined the Emotional Regulation Asset and FAtiMA architecture. Here we need to have all FAtiMA depencies.|
        public string Name { set => name = value; }
        public FAtiMAConnection FAtiMAInfo { get => this.FAtiMAInfo; set { } }
        string name = string.Empty;
        public AgentAsset(float openness, float conscientiousness, float extraversion, float agreeableness, float neuroticism) :
            base(openness, conscientiousness, extraversion, agreeableness, neuroticism)
        {

        }
        private void Regulate()
        {


        }
    }
}
