using System;
using BigFiveModel;
using EmotionRegulation;
using RolePlayCharacter;
using IntegratedAuthoringTool;
using GAIPS.Rage;
using System.IO;
using System.Diagnostics;
using System.Xml.Schema;

namespace BigFiveModel
{
    public class AgentAsset:BigFiveModelAsset
    {
        // The agent is the interface that combined the Emotional Regulation Asset and FAtiMA architecture. Here we need to have all FAtiMA depencies.|
        //public string PathFAtiMAFiles { set { this.GetCharacterFromJSON(value); } }

        public AgentAsset(float openness, float conscientiousness,float extraversion, float agreeableness, float neuroticism):
            base(openness,conscientiousness,extraversion,agreeableness,neuroticism)
        {
        }
        public void GetCharacterFromJSON(string path)
        {
            /// To use a GAIPS.Rage library, you need to compaile the FAtiMA-AuthoringTools project. 
            Directory.SetCurrentDirectory(path);
            var files = Directory.GetFiles(path);
            string scenario_path = files[0];
            string storage_path = files[1];
            try 
            {
                // TODO: Make sure why is the reason because the .FromJson method is not working as expected.
                var storage = AssetStorage.FromJson(File.ReadAllText(@scenario_path));
                var iat = IntegratedAuthoringToolAsset.FromJson(File.ReadAllText(@storage_path),storage);
            }
            catch(Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        private void Regulate()
        {


        }
    }
}
