using System;
namespace Core.Utilities.Results
{
    //Base void Type
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}

