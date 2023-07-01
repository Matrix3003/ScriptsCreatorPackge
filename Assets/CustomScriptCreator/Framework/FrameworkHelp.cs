using UnityEditor; 
using UnityEngine; 

namespace CustomScriptsCreator
{
    #if UNITY_EDITOR
    internal class FrameworkHelp
    { 
        [MenuItem("Help/Custom Scripts/Open github repos...")]
        static void OpenGitRepos() => Application.OpenURL("https://github.com/Manteiga30/ScriptsCreatorPackge"); 

        [MenuItem("Help/Custom Scripts/Debug contact email...")]
        static void DebugEmail() => Debug.Log("nicolaspegolo@hotmail.com"); 

    }
    #endif
}