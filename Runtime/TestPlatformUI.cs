using TMPro;
using UnityEngine;

namespace PunctualSolutionsTool.CommonLive
{
    public class TestPlatformUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;

        public void InputData(string value)
        {
            var split = value.Split(':');
            if (split.Length <= 2) return;
            _inputField.text = string.Empty;
            switch (split[0])
            {
                case "c":
                    TestLivePlatform.SendCommentaries(new Commentaries(int.Parse(split[1]), split[2]));
                    break;
                case "g":
                    TestLivePlatform.SendGift(new Gift(long.Parse(split[1]), split[2], long.Parse(split[3]), split[4], long.Parse(split[5])));
                    break;
            }
        }

        public TestLivePlatform TestLivePlatform { get; set; }
    }
}