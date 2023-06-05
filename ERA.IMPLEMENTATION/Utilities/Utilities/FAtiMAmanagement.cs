using System;
using System.IO;
using IntegratedAuthoringTool;
using GAIPS.Rage;

namespace ERA.Utilities
{
    public class FAtiMAmanagement
    {
        
        public IntegratedAuthoringToolAsset IAT { get => iat; }
        string pathFiles = string.Empty;
        IntegratedAuthoringToolAsset iat;
        public FAtiMAmanagement(string pathFiles) 
        {
            iat = new IntegratedAuthoringToolAsset();
            this.pathFiles = pathFiles;
            this.GetFAtiMAFromJSON();
        }
        private void GetFAtiMAFromJSON()
        {
            /// To use a GAIPS.Rage library, you need to compaile the FAtiMA-AuthoringTools project. 
            Directory.SetCurrentDirectory(pathFiles);
            var files = Directory.GetFiles(pathFiles);
            string scenario_path = files[0];
            string storage_path = files[1];
            var storage = AssetStorage.FromJson(File.ReadAllText(storage_path));
            iat = IntegratedAuthoringToolAsset.FromJson(File.ReadAllText(scenario_path),storage);
        }
    }
}