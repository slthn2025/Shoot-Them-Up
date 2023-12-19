using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI _timeText;
    public TMPro.TextMeshProUGUI _scoreText;
    public Image[] _hpIndicators;
    public GameObject _loseScreen;
    public TMPro.TextMeshProUGUI _loseScreenTxt;
    
    // Update is called once per frame
    void Update()
    {
        _timeText.text ="Times " + Time.time.ToString("0000");
        
    }
    public void SetScore(int newScore){
        _scoreText.text = "Score : " + newScore.ToString();
    }

    public void SetHp(int newHp){
        for(int i = 0; i< _hpIndicators.Length; i++){
            if(newHp >i)
                _hpIndicators[i].gameObject.SetActive(true);
            else
                _hpIndicators[i].gameObject.SetActive(false);
        }
    }
    public void ShowLoseScreen(int score){
        _loseScreen.SetActive(true);
        _loseScreenTxt.text = "Your Score: " + score;
        Time.timeScale = 0;
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
