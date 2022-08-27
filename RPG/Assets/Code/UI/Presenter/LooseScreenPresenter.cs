using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.UI.Presenter
{
    public class LooseScreenPresenter:MonoBehaviour
    {
        [SerializeField] private Button _again;
        [SerializeField] private Button _exit;

        private void Awake()
        {
            _again.onClick.AddListener(()=>SceneManager.LoadScene(0));
            _exit.onClick.AddListener(()=>Application.Quit());
        }
    }
}