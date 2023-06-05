using System;
using System.Runtime.CompilerServices;
using BigFiveModel;

namespace BigFiveModel.Tutorial
{
    internal class AgentTutorial
    {
        static void Main(string[] args)
        {
            // Create an Agent using the class Agent.
            // The class 'Agent' inherits from the class 'BigFiveModelAsset, so, you need pass as parameters the value
            // for each trait.
            AgentAsset myAgent = new AgentAsset(openness: 0.0f, conscientiousness: 0.0f, extraversion: 0.0f, agreeableness: 0.0f, neuroticism: 0.0f);
            myAgent.Name = "Pedro";
            // Now, we need to link our agent to the FAtiMA character, to do this we need to indicate where is the .json FAtiMA files.
            myAgent.FAtiMAInfo = new ERA.Utilities.FAtiMAConnection(@"D:\Git\Emotion.Regulation.Asset\Scenarios\");

            // The agent can have: a dominant personality; a value of pertenency of its personality; and, specific Emotional Regulation strategies.
            var dominant = myAgent.Dominant;
            var strategies = myAgent.StrategiesToApply;
            var allStrategies = myAgent.AllStrategies;
            Console.WriteLine($"The dominant personality is: {dominant.personality}");
            Console.WriteLine($"The level of this personality is: {dominant.level}");
            Console.WriteLine("The strategies the agent would be apply:");
            strategies.ForEach(strategy => Console.WriteLine(" - " + strategy.ToString()));
            Console.WriteLine("The level of the all strategies are: ");
            allStrategies.ForEach(strategy => Console.WriteLine(" - " + strategy.ToString()));
            StartScenario(myAgent);
        }
        static void StartScenario(AgentAsset agent)
        {
            var a = agent.FAtiMAInfo.FAtiMA_Assets;
        }
    }
}
