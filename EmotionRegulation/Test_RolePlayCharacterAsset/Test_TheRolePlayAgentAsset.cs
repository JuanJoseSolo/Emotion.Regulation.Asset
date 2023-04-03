using Microsoft.VisualStudio.TestTools.UnitTesting;
using BigFiveModel;
using WellFormedNames;
using RolePlayCharacter;
using System.Diagnostics;

namespace TestRolePlayAgentAsset
{
    [TestClass]
    public class Test_TheRolePlayAgentAsset
    {
        [TestMethod]
        public void CreateAgent()
        {
            // Arrange
            var character = new RolePlayCharacterAsset() { CharacterName = (Name)"dummy_name" };
            var agent = new RolePlayAgentAsset(FAtiMA_character: character);
            Debug.Print(agent.Dominant);
            agent.StrategiesForce().ForEach(strategy => { Debug.Print(strategy); });
            agent.StrategiesToApply().ForEach(strategy => { Debug.Print(strategy); });
            Debug.Print(agent.Name);
        }
    }
}