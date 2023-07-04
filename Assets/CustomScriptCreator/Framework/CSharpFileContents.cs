using UnityEngine;

namespace CustomScriptsCreator
{
    // C# files sintaxe manager
    internal class CSharpFileContents
    {
        private const string FILES_HEADER = "using System.Collections;\nusing System.Collections.Generic;\nusing UnityEngine;\n\n";
        private readonly static string DEFAULT_NAMESPACE_NAME = "Default"; 
        
        #region Summary
        /// <summary>
        /// Generate a empy c# class sintax 
        /// </summary>
        /// <param name="className"></param>
        /// <returns>
        /// Empy c# class sintax 
        /// </returns>
        #endregion
        public static string GetEmpyClassFileContent(string className)
        {
            string body = string.Concat($"namespace {DEFAULT_NAMESPACE_NAME}\n",
                                        "{\n",
                                        $"    public class {className}\n",
                                        "    {\n",
                                        "        \n",
                                        "    }\n",
                                        "}"

            );
            
            string content = string.Concat(FILES_HEADER, body); 

            return content; 
        } 

        #region Summary
        /// <summary>
        /// Generate a empy c# interface sintax 
        /// </summary>
        /// <param name="className"></param>
        /// <returns>
        /// Empy c# interface sintax 
        /// </returns>
        #endregion
        public static string GetInterfaceFileContent(string className)
        {   
            string body = string.Concat($"namespace {DEFAULT_NAMESPACE_NAME}\n",
                                        "{\n",
                                        $"    public interface {className}\n",
                                        "    {\n",
                                        "        \n",
                                        "    }\n",
                                        "}"

            );
            
            string content = string.Concat(FILES_HEADER, body); 

            return content; 
        } 

        #region Summary
        /// <summary>
        /// Generate a mono c# class sintax 
        /// </summary>
        /// <param name="className"></param>
        /// <returns>
        /// Empy mono c# class sintax 
        /// </returns>
        #endregion
        public static string GetMonoClassFileContent(string className)
        {   
            string header = $"using System.Collections;\nusing System.Collections.Generic;\nusing UnityEngine;\n\n"; 

            string body = string.Concat($"namespace {DEFAULT_NAMESPACE_NAME}\n",
                                        "{\n",
                                        $"    public class {className} : MonoBehaviour\n",
                                        "    {\n",
                                        "        \n",
                                        "    }\n",
                                        "}"

            );
            
            string content = string.Concat(FILES_HEADER, body); 

            return content; 
        } 
    }
}
