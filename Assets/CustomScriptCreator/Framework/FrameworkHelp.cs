using UnityEditor; 
using UnityEngine; 
using System.IO; 

namespace CustomScriptsCreator
{
    #if UNITY_EDITOR
    internal class FrameworkHelp
    { 
        private const string README_PATH_CONFIG_KEY = "ReadmePath";
        private const string DEFAULT_README_PATH = "CustomScriptsCreator/README.txt";

        
        [MenuItem("Help/Custom Scripts/Open Github Repos...")]
        static void OpenGitRepos()
        {
            Application.OpenURL("https://github.com/Manteiga30/ScriptsCreatorPackge"); 
        }
    }
    #endif
}