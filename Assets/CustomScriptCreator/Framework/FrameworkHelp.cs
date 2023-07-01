using UnityEditor; 
using UnityEngine; 

namespace CustomScriptsCreator
{
    #if UNITY_EDITOR
    internal class FrameworkHelp
    { 
        private const string README_PATH_CONFIG_KEY = "ReadmePath";
        private const string DEFAULT_README_PATH = "CustomScriptsCreator/README.txt";

        
        [MenuItem("Help/Custom Scripts/Open github repos...")]
        static void OpenGitRepos() => Application.OpenURL("https://github.com/Manteiga30/ScriptsCreatorPackge"); 

        [MenuItem("Help/Custom Scripts/Get contact email...")]
        static void DebugEmail() => Debug.Log("nicolaspegolo@hotmail.com"); 

    }
    #endif
}