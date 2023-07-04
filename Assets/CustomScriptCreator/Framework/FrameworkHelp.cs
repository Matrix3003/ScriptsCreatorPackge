using UnityEditor; 
using UnityEngine; 

namespace CustomScriptsCreator
{
    #if UNITY_EDITOR
    internal class FrameworkHelp
    { 
        [MenuItem("Help/Custom Scripts/Debug contact email...")]
        static void DebugEmail() => Debug.Log("nicolaspegolo@hotmail.com"); 

    }
    #endif
}