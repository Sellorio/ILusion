using ILusion.Methods.LogicTrees.Nodes;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Linq;
using System.Reflection;

namespace ILusion.Methods.LogicTrees.Emitters
{
    internal class NewEmitter : EmitterBase<NewNode>
    {
        private static readonly MethodInfo createInstanceMethod =
            typeof(System.Activator).GetMethods()
                .First(x => x.Name == nameof(System.Activator.CreateInstance) && x.ContainsGenericParameters);

        protected override void Emit(EmitterContext<NewNode> emitterContext)
        {
            if (emitterContext.Node.Constructor == null)
            {
                if (emitterContext.Node.Type is ArrayType arrayType)
                {
                    emitterContext.Emit(OpCodes.Newarr, arrayType.ElementType);
                }
                else if (emitterContext.Node.Type is GenericParameter)
                {
                    var createInstance = emitterContext.Target.Module.ImportReference(createInstanceMethod);

                    var methodCall = new GenericInstanceMethod(createInstance);
                    methodCall.GenericArguments.Add(emitterContext.Node.Type);
                    methodCall.ReturnType = new GenericParameter("!!0", methodCall);

                    emitterContext.Emit(OpCodes.Call, methodCall);
                }
                else
                {
                    emitterContext.Emit(OpCodes.Call, emitterContext.Node.Type);
                }
            }
            else
            {
                emitterContext.Emit(OpCodes.Newobj, emitterContext.Node.Constructor);
            }
        }
    }
}
