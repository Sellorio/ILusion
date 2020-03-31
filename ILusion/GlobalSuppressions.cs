// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Major Code Smell",
    "S1871:Two branches in a conditional structure should not have exactly the same implementation",
    Justification = "Sometimes this is desired to increase readability by making different conditional blocks more explicit.")]
