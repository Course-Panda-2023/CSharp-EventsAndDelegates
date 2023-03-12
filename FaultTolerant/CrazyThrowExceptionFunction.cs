namespace FaultTolerant
{
    internal class CrazyThrowExceptionFunction
    {
        public int CrazyFunction()
        {
            Random rand = new Random();
            int result = rand.Next(10);

            if (result < 5)
            {
                throw new Exception("Oops, something went wrong!");
            }

            return result;
        }

    }
}
