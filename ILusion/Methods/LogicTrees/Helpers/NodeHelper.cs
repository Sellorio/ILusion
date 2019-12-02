namespace ILusion.Methods.LogicTrees.Helpers
{
    internal static class NodeHelper
    {
        internal static LogicNode GetFirstRecursively(LogicNode logicNode)
        {
            if (logicNode.Children.Count > 0)
            {
                return GetFirstRecursively(logicNode.Children[0]);
            }

            return logicNode;
        }
    }
}
