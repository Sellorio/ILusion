using Mono.Cecil;

namespace ILusion.Methods.LogicTrees.Helpers
{
    internal static class TypeHelper
    {
        internal static bool IsClass(TypeReference type)
        {
            if (type is GenericParameter genericParameter)
            {
                return genericParameter.HasReferenceTypeConstraint;
            }

            return !type.IsValueType;
        }

        internal static bool IsValueType(TypeReference type)
        {
            if (type is GenericParameter genericParameter)
            {
                return genericParameter.HasNotNullableValueTypeConstraint;
            }

            return type.IsValueType;
        }
    }
}
