// -----------------------------------------------------------------------
// <copyright file="PythonEngine.cs" company="">
// 
// </copyright>
// -----------------------------------------------------------------------
namespace PythonEnine
{
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;

    /// <summary>
    /// Creates the Python engine and invokes methods
    /// </summary>
    public class PythonEngine
    {
        private ScriptSource scriptSource;
        private CompiledCode compiledCode;
        private ScriptScope scope;
        private ScriptEngine engine;

        public PythonEngine(string scriptPath)
        {
            this.Script = scriptPath;
        }

        public string Script { get; set; }

        public dynamic InvokeMethodWithParameters(string methodName, params object[] parameters)
        {
            engine = Python.CreateEngine();
            scriptSource = engine.CreateScriptSourceFromFile(this.Script);
            compiledCode = scriptSource.Compile();
            scope = engine.CreateScope();

            compiledCode.Execute(scope);

            dynamic pythonMethod = scope.GetVariable(methodName);

            return engine.Operations.Invoke(pythonMethod, parameters);
        }
    }
}