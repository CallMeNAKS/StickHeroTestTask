using System;

namespace CodeBase.Input
{
    public interface IInputHandler
    {
        public event Action StartPressing;
        public event Action EndPressing;
    }
}