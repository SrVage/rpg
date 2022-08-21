using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.View
{
    public class GamePauseMenuView:MonoBehaviour
    {
        [SerializeField] private Button _resumeGameButton;
        [SerializeField] private Button _saveGameButton;
        [SerializeField] private Button _exitGameButton;
        public Button ResumeGameButton => _resumeGameButton;
        public Button SaveGameButton => _saveGameButton;
        public Button ExitGameButton => _exitGameButton;
    }
}