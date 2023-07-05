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

        private static readonly List<char> _invalidCharacters = new List<char>() 
        {
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=', '[', ']',
            '{', '}', '|', '\\', ':', ';', '\'', '"', '<', '>', ',', '.', '/', '?', ' ',
            'á', 'à', 'ã', 'â', 'ä', 'é', 'è', 'ẽ', 'ê', 'ë', 'í', 'ì', 'ĩ', 'î', 'ï',
            'ó', 'ò', 'õ', 'ô', 'ö', 'ú', 'ù', 'ũ', 'û', 'ü', 'ç'
        };

        private static readonly char _correctionChar = '_'; 
        
        #region summary
        /// <summary>
        /// Create an empty c# class with a default namespace in the user selected folder.
        /// </summary>
        /// <param name="menuCommand"></param>
        #endregion
        [MenuItem("Assets/Create/CustomScript/C# Empty Class", priority = 50)]
        static void CreateCSharpEmptyClassFile(MenuCommand menuCommand)
        {
            string filePath = GetSelectedFolderPath();

            if (!string.IsNullOrEmpty(filePath))
            {
                string className = ShowFileNameDialog(_defaultClassName);

                className = ValidadeChars(className);

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
        
        #region summary
        /// <summary>
        /// Create a Mono c# class with a default namespace in the user selected folder.
        /// </summary>
        /// <param name="menuCommand"></param>
        #endregion
        [MenuItem("Assets/Create/CustomScript/C# MonoBehaviour Class", priority = 50)]
        static void CreateCSharpMonoClassFile(MenuCommand menuCommand)
        {
            string filePath = GetSelectedFolderPath();

            if (!string.IsNullOrEmpty(filePath))
            {
                string className = ShowFileNameDialog(_defaultClassName);

                className = ValidadeChars(className); 

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

        #region summary
        /// <summary>
        /// Create a c# interface with a default namespace in the user selected folder.
        /// </summary>
        /// <param name="menuCommand"></param>
        #endregion
        [MenuItem("Assets/Create/CustomScript/C# Interface Class", priority = 50)]
        static void CreateCSharpInterfaceClassFile(MenuCommand menuCommand)
        {
            string filePath = GetSelectedFolderPath();

            if (!string.IsNullOrEmpty(filePath))
            {
                string className = ShowFileNameDialog(_defaultClassName);

                className = ValidadeChars(className);

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

        #region summary
        /// <summary>
        /// Create a c# class with a default namespace and singleton sitaxe in the user selected folder.
        /// </summary>
        /// <param name="menuCommand"></param>
        #endregion
        [MenuItem("Assets/Create/CustomScript/C# Singleton Class", priority = 50)]
        static void CreateCSharpSigletonClassFile(MenuCommand menuCommand)
        {
            string filePath = GetSelectedFolderPath();

            if (!string.IsNullOrEmpty(filePath))
            {
                string className = ShowFileNameDialog(_defaultClassName);

                className = ValidadeChars(className);

                if (!string.IsNullOrEmpty(className) && CreateFile)
                {
                    string fileName = className + ".cs";
                    string fullPath = Path.Combine(filePath, fileName);
                    File.WriteAllText(fullPath, CSharpFileContents.GetSingletonClassFileContent((className)));

                    AssetDatabase.ImportAsset(fullPath, ImportAssetOptions.Default);
                    AssetDatabase.Refresh();
                }
            }
        }

        
        #region summary
        /// <summary>
        /// Helper method to get the selected folder path
        /// </summary>
        /// <returns></returns>
        #endregion
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

        #region summary
        /// <summary>
        /// Helper method to display a dialog for entering the file name
        /// </summary>
        /// <param name="defaultName"></param>
        /// <returns></returns>
        #endregion
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

        #region summary
        /// <summary>
        /// Checks if there are any invalid characters to write c# files, if hover it changes them to an underscore
        /// </summary>
        /// <param name="className">
        /// The string if will be validated
        /// </param>
        /// <returns>
        /// The new string with also valid chars
        /// </returns>
        #endregion
        private static string ValidadeChars(string className)
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

    // Confirmation window manager
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

