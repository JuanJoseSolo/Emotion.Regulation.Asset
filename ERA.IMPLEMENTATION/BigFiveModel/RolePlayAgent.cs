using RolePlayCharacter;
using WellFormedNames;
using IntegratedAuthoringTool;
using WorldModel;

namespace BigFiveModel
{
    public class RolePlayAgentAsset:BigFiveModelAsset
    {
        public RolePlayCharacterAsset FAtiMACharacter { get; }
        public string Name { get; }

        public RolePlayAgentAsset(RolePlayCharacterAsset FAtiMA_character)
        {
            Name = FAtiMA_character.CharacterName.ToString();
            FAtiMACharacter = FAtiMA_character;
            CreateAgent();
        }
        private void CreateAgent()
        {
            
        }
    }
}
