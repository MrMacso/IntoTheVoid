using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthPanel : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] Image _healthBar;

    Player _player;

    public void Bind(Player player)
    {
        _player = player;
        //_player.ScoreChanged += UpdateScore;
        _player.HealthChanged += UpdateHealth;
        //UpdateScore();
        UpdateHealth();
    }
    private void UpdateHealth()
    {
        _healthBar.fillAmount = _player.GetCurrentHealthNormalised();
        Debug.Log("Hello");
    }
    private void UpdateScore()
    {
        _scoreText.SetText(_player.Score.ToString());
    }
}
