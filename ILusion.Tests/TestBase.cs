using ILusion.Methods;
using ILusion.Tests.Sample;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;
using Xunit;

namespace ILusion.Tests
{
    public abstract class TestBase
    {
        private static readonly AssemblyDefinition _sampleAssembly = AssemblyDefinition.ReadAssembly(typeof(ActionCallSamples).Assembly.Location);

        protected MethodDefinition GetSampleMethod(string className, string methodName)
        {
            return _sampleAssembly.MainModule.Types.First(x => x.Name == className).Methods.First(x => x.Name == methodName);
        }

        protected void ValidateEmission(MethodDefinition method, MethodBodyIllusion illusion)
        {
            var oldInstructions = method.Body.Instructions.ToArray();
            illusion.AppyTo(method);
            var newInstructions = method.Body.Instructions;

            Assert.Equal(oldInstructions.Length, newInstructions.Count);
            
            for (var i = 0; i < oldInstructions.Length; i++)
            {
                Assert.Equal(oldInstructions[i].OpCode, newInstructions[i].OpCode);
                Assert.Equal(oldInstructions[i].Operand, newInstructions[i].Operand);
            }
        }
    }
}
