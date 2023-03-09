using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaultTolerant
{
    internal class AttachFunctionToEventAndTriggersit
    {

        public delegate void Notify();

        private event Notify ExecutionSucceded;

        private int Divide(int x, int y)
        {
            return x / y;
        }

        public void CheckFunctionSucceeded()
        {
            try
            {
                WhenFunctionSucceededFunction succeeded = new();
                succeeded.FunctionSucceeded(() => Divide(10, 0), 0, 3);
            }
            catch (Exception) { }
        }

        public void Invoke()
        {
            try
            {
                WhenFunctionSucceededFunction succeeded = new();

                CrazyThrowExceptionFunction crazyFuncionClass = new();

                succeeded.FunctionSucceeded(() => crazyFuncionClass.CrazyFunction(), 0, 3);
                
            }
            catch (Exception) {}
        }
    }
}


