namespace UI.Utils
{
    using Zebble;

    class WaitingAwareBindable : AuthRevertBindable<bool>
    {
        public WaitingAwareBindable(bool value, bool block = true) : base(value)
        {
            Changed += async () =>
              {
                  if (Value)
                      await Waiting.Show(block);
                  else
                      await Waiting.Hide();
              };
        }
    }
}
