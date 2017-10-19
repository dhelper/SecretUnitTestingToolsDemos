namespace BrainSample
{
    public class Brain
    {
        private readonly IHand _hand;
        private readonly IMouth _mouth;

        /// <summary>
        ///     Creates the brain using Dependency Pattern, that is needed for most mocking frameworks to work.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="mouth"></param>
        public Brain(IHand hand, IMouth mouth)
        {
            _hand = hand;
            _mouth = mouth;
        }

       public void TouchIron(Iron iron)
        {
            try
            {
                _hand.TouchIron(iron);
            }
            catch (BurnException)
            {
                _mouth.Yell();
            }
        }
    }
}