using UnityEngine;

namespace CustomScriptsCreator
{
    internal class CSharpFileContents
    {
        private const string FILES_HEADER = "using System.Collections;\nusing System.Collections.Generic;\nusing UnityEngine;\n\n";
        private readonly static string DEFAULT_NAMESPACE_NAME = "Default"; 
        
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
