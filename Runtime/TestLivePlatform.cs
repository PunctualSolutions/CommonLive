using System;

namespace PunctualSolutionsTool.CommonLive
{
    public class TestLivePlatform
    {
        public event Action<Commentaries> OnCommentaries;
        public event Action<Gift> OnGift;

        public void SendCommentaries(Commentaries commentaries)
        {
            OnCommentaries?.Invoke(commentaries);
        }

        public void SendGift(Gift gift)
        {
            OnGift?.Invoke(gift);
        }
    }
}