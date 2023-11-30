using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score;
    public int blood = 100;
    public AudioSource death;
    [SerializeField]GameObject panelGameOver;
    [SerializeField]GameObject panelPause;
    [SerializeField]GameObject panelWin;
    public static GameManager inst;
    [SerializeField]Text textScore;
    [SerializeField] Robot robot;
    // [SerializeField] Text textBlood;
    [SerializeField] Slider thanhMau;
    private void Start()
    {
        // textBlood.text = "Blood: " + blood;
        thanhMau.value = blood;
    }

    public void IncrementScore()
    {
        score++;
        textScore.text = "Score: " + score;
        robot.speed += robot.speedIncresePerPonit;
        if (score == 50)
        {
            Time.timeScale = 0;
            panelWin.SetActive(true);
        }
    }

    public void Health()
    {
        if (score >= 2)
        {
            score -= 2;
            textScore.text = "Score: " + score;
        }
        blood -= 20;
        thanhMau.value = blood;
        // textBlood.text = "Blood: " + blood;
        if (blood <= 0)
        {
            death.Play();
            Time.timeScale = 0f;
            panelGameOver.SetActive(true);
        }
    }
    public void Fall()
    {
        
        score = 0;
        textScore.text = "Score: " + score;
        blood = 0;
        // textBlood.text = "Blood: " + blood;
        if (blood <= 0)
        {
            Debug.Log("Fall-gameMana");
            Time.timeScale = 0;
            panelGameOver.SetActive(true);
        }
    }
    
    private void Awake()
    {
        inst = this;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        Debug.Log("Restart()"+Time.timeScale);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }
    
    public void Continue()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }

}
