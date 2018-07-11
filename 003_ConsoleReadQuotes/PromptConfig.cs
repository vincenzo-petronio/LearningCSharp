using System;

namespace _003_ConsoleReadQuotes
{
    internal class PromptConfig
    {
        private Object objLockHandle = new Object();
        public int DelayInMs { get; private set; } = 200;

        private bool done;

        public bool GetDone()
        {
            return done;
        }

        private void SetDone(bool value)
        {
            done = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stepInMs">int less for fast</param>
        public void UpdateDelay(int stepInMs)
        {
            var newDelay = Math.Min(DelayInMs + stepInMs, 1000);
            newDelay = Math.Max(newDelay, 20);
            lock (objLockHandle)
            {
                DelayInMs = newDelay;
            }
        }

    }
}
