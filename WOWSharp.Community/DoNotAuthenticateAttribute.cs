
using System;

namespace WOWSharp.Community
{
    /// <summary>
    ///   Applied to a class that's derived from ApiResponse to prevent applying authentication header
    /// </summary>
    /// <remarks>
    ///   This is a temporary workaround for BattleGroup resource api not working when authenticate
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DoNotAuthenticateAttribute : Attribute
    {
    }
}