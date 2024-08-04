#region

using TMPro;
using UnityEngine;

#endregion

namespace PunctualSolutionsTool.CommonLive
{
    public class TestPlatformUI : MonoBehaviour
    {
        [SerializeField] TMP_InputField _inputField;

        [SerializeField] string _cmd;

        TestLiveServer     TestLivePlatform { get; set; }
        public ILiveServer LiveServer       => TestLivePlatform;

        void Awake()
        {
            TestLivePlatform = new TestLiveServerFactory().GetCore();
        }

        public void InputData(string value)
        {
            var split = value.Split(':');
            if (split.Length <= 2) return;
            _inputField.text = string.Empty;
            switch (split[0])
            {
                case "c":
                    TestLivePlatform.SendCommentaries(new(int.Parse(split[1]), split[2]));
                    break;
                case "g":
                    TestLivePlatform.SendGift(new(split[1], int.Parse(split[2]), long.Parse(split[3]), split[4]));
                    break;
                case "l":
                    TestLivePlatform.SendLike(new(int.Parse(split[1]), split[2]));
                    break;
            }
        }

        [ContextMenu("Input Data")]
        public void InputData()
        {
            InputData(_cmd);
        }
    }
}