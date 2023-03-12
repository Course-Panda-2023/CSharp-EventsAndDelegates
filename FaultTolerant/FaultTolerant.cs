using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FaultTolerant
{
    public delegate void MaybefaultyFunction();
    public static void TryFunctionUntilGiveUp(MaybefaultyFunction func, int numTries)
    {
        for (int i = 0; i < numTries; i++)
        {
            try
            {
                func();
                break;
            }
            catch (Exception)
            {

            }
        }

    }
}

