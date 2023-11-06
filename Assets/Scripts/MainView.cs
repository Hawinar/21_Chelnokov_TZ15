using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _leaderboardBtn;

    [SerializeField] private GameObject _leaderboardUI;
    void Start()
    {
        _leaderboardUI.SetActive(false);
        _startBtn.onClick.AddListener(() => Play());
        _leaderboardBtn.onClick.AddListener(() => GoToLeaderboard());
    }
    private void Play()
    {
        SceneManager.LoadScene("Level1");
    }
    private void GoToLeaderboard()
    {
        this.gameObject.SetActive(false);
        _leaderboardUI.SetActive(true);
    }
}
