using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic; 

namespace CustomScriptsCreator
{
    #if UNITY_EDITOR
    internal class CustomCreatorTab : EditorWindow
    {
        private static string _defaultClassName = "NewClass";
        public static bool CreateFile;

        private static readonly List<char> _invalidCharacters = new List<char>() {
            ' ',
            'ç',
            '#',
            '%',
            '&',
            '{',
            '}',
            '/',
            '<',
            '>',
            '*',
            '?',
            '$',
            '!',
            '"',
            ':',
            '@',
            '+',
            '=',
            '|',
            ';'
        }; 

        private static readonly char _correctionChar = '_'; 

        
        [MenuItem("Assets/Create/CustomScript/C# Empty Class", priority = 752)]
        static void CreateCSharpEmptyClassFile(MenuCommand menuCommand)
        {
            string filePath = GetSelectedFolderPath();

            if (!string.IsNullOrEmpty(filePath))
            {
                string className = ShowFileNameDialog(_defaultClassName);

                className = ValidadeClassChars(className);

                if (!string.IsNullOrEmpty(className) && CreateFile)
                {
                    string fileName = className + ".cs";
                    string fullPath = Path.Combine(filePath, fileName);
                    File.WriteAllText(fullPath, CSharpFileContents.GetEmpyClassFileContent(className));

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

                className = ValidadeClassChars(className); 

                if (!string.IsNullOrEmpty(className) && CreateFile)
                {
                    string fileName = className + ".cs";
                    string fullPath = Path.Combine(filePath, fileName);
                    File.WriteAllText(fullPath, CSharpFileContents.GetMonoClassFileContent(className));

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

                className = ValidadeClassChars(className);

                if (!string.IsNullOrEmpty(className) && CreateFile)
                {
                    string fileName = className + ".cs";
                    string fullPath = Path.Combine(filePath, fileName);
                    File.WriteAllText(fullPath, CSharpFileContents.GetInterfaceFileContent((className)));

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

        private static string ValidadeClassChars(string className)
        {
            char[] classChars = className.ToCharArray(); 

            for (int i = 0; i < classChars.Length; i++)
            {
                if(_invalidCharacters.Contains(classChars[i]))
                {
                    classChars[i] = _correctionChar; 
                }
            }

            string corretedName = new string(classChars); 
            
            return corretedName;  
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

            if (Event.current.keyCode == KeyCode.Return)
            {
                CustomCreatorTab.CreateFile = true; 
                Close();
            }

            GUILayout.EndHorizontal();
        }
    }
    #endif
}

