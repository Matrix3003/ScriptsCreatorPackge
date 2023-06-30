using UnityEngine;
using UnityEditor;
using System.IO;

namespace CustomScriptsCreator
{
    #if UNITY_EDITOR
    internal class CustomCreatorTab : EditorWindow
    {
        private static string _defaultClassName = "NewClass";
        public static bool CreateFile;

        
        [MenuItem("Assets/Create/CustomScript/C# Empty Class", priority = 752)]
        static void CreateCSharpEmptyClassFile(MenuCommand menuCommand)
        {
            string filePath = GetSelectedFolderPath();
            if (!string.IsNullOrEmpty(filePath))
            {
                string className = ShowFileNameDialog(_defaultClassName);
                if (!string.IsNullOrEmpty(className) && CreateFile)
                {
                    string fileName = className + ".cs";
                    string fullPath = Path.Combine(filePath, fileName);
                    File.WriteAllText(fullPath, CSharpFileContents.GetEmpyClassFileContent(className));
                    Debug.Log("Created C# empty class file at: " + fullPath);

                    AssetDatabase.ImportAsset(fullPath, ImportAssetOptions.Default);
                    AssetDatabase.Refresh();
                }
            }
        }

        [MenuItem("Assets/Create/CustomScript/C# MonoBehaviour Class", priority = 752)]
        static void CreateCSharpMonoClassFile(MenuCommand menuCommand)
        {
            string filePath = GetSelectedFolderPath();
            if (!string.IsNullOrEmpty(filePath))
            {
                string className = ShowFileNameDialog(_defaultClassName);
                if (!string.IsNullOrEmpty(className) && CreateFile)
                {
                    string fileName = className + ".cs";
                    string fullPath = Path.Combine(filePath, fileName);
                    File.WriteAllText(fullPath, CSharpFileContents.GetMonoClassFileContent(className));
                    Debug.Log("Created C# MonoBehaviour class file at: " + fullPath);

                    AssetDatabase.ImportAsset(fullPath, ImportAssetOptions.Default);
                    AssetDatabase.Refresh();
                }
            }
        }

        [MenuItem("Assets/Create/CustomScript/C# Interface Class", priority = 753)]
        static void CreateCSharpInterfaceClassFile(MenuCommand menuCommand)
        {
            string filePath = GetSelectedFolderPath();
            if (!string.IsNullOrEmpty(filePath))
            {
                string className = ShowFileNameDialog(_defaultClassName);
                if (!string.IsNullOrEmpty(className) && CreateFile)
                {
                    string fileName = className + ".cs";
                    string fullPath = Path.Combine(filePath, fileName);
                    File.WriteAllText(fullPath, CSharpFileContents.GetInterfaceFileContent((className)));
                    Debug.Log("Created C# interface class file at: " + fullPath);

                    AssetDatabase.ImportAsset(fullPath, ImportAssetOptions.Default);
                    AssetDatabase.Refresh();
                }
            }
        }

        // Helper method to get the selected folder path
        private static string GetSelectedFolderPath()
        {
            string folderPath = string.Empty;
            Object obj = Selection.activeObject;
            if (obj != null)
            {
                folderPath = AssetDatabase.GetAssetPath(obj.GetInstanceID());
                if (!string.IsNullOrEmpty(folderPath) && File.Exists(folderPath))
                {
                    folderPath = Path.GetDirectoryName(folderPath);
                }
            }
            return folderPath;
        }

        // Helper method to display a dialog for entering the file name
        private static string ShowFileNameDialog(string defaultName)
        {
            CreateFile = false; 
            
            string className = defaultName;

            CreateFileDialog dialog = CreateFileDialog.CreateInstance<CreateFileDialog>();
            dialog.position = new Rect(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2, 500, 200); 
            dialog.className = className;
            dialog.ShowModalUtility();

            return dialog.className;
        }
    }

    public class CreateFileDialog : EditorWindow
    {
        public string className = "";

        private void OnGUI()
        {
            GUILayout.Label("Enter the file name:", EditorStyles.boldLabel);
            className = EditorGUILayout.TextField(className);

            GUILayout.Space(20);
            
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Create"))
            {
                CustomCreatorTab.CreateFile = true; 
                Close();
            }

            if (GUILayout.Button("Cancel"))
            {
                Close();
            }

            GUILayout.EndHorizontal();
        }
    }
    #endif
}

