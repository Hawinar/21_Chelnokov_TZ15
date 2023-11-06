using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyTMP;
    [SerializeField] private TextMeshProUGUI _goalTMP;
    [SerializeField] private TextMeshProUGUI _timeTMP;
    [SerializeField] private TextMeshProUGUI _gameOverTMP;
    private float _timeBetweenSpawn = 1;

    WaitForSeconds _sleepTime = new WaitForSeconds(3f);


    [SerializeField] private Button _pauseBtn;
    private float _time;

    private void Start()
    {
        _gameOverTMP.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        _pauseBtn.onClick.AddListener(() => Pause());
    }

    private void Update()
    {
        if (Time.time > _time)
        {
            _time = Time.time + _timeBetweenSpawn;
            GameManager.Time--;
        }
        _moneyTMP.text = $"Money: {GameManager.Money}";
        _goalTMP.text = $"Goal: {GameManager.CurrentGoal}";
        _timeTMP.text = $"Time: {GameManager.Time}";

        if (GameManager.Time == 0)
        {
            _gameOverTMP.gameObject.SetActive(true);
            StartCoroutine(LeaveGame());
        }
    }
    private void Pause()
    {
        if (Time.timeScale == 1.0f)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }
    IEnumerator LeaveGame()
    {
        SaveResults.SaveResults.Save();
        yield return _sleepTime;
        SceneManager.LoadScene("MainMenu");
    }
}
