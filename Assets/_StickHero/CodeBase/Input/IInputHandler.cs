using System;

namespace CodeBase.Input
{
    public interface IInputHandler
    {
        public event Action Pressed;
        public event Action EndPressing;
        public event Action Clicked;
    }
}