using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private GameObject _mainUI;
    [SerializeField] private GameObject _leaderboardUI;

    [SerializeField] private TextMeshProUGUI _leaderboardTmp;
    [SerializeField] private Button _goToMainMenu;

    void Start()
    {
        _goToMainMenu.onClick.AddListener(() => GoToMainMenu());
        _leaderboardTmp.text = "";

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetInt($"Score_{i}") != 0)
                _leaderboardTmp.text += $"{PlayerPrefs.GetInt($"Score_{i}")}\n";
        }
        if (_leaderboardTmp.text == "")
        {
            _leaderboardTmp.text = "≈щЄ никто не играл в эту игру.\n”спей стать первым!";
        }
    }

    private void GoToMainMenu()
    {
        _mainUI.SetActive(true);
        _leaderboardUI.SetActive(false);
    }
}
