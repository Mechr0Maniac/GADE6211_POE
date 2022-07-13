using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointText;
   public void Setup(int score)
    {
        gameObject.SetActive(true);
        
        pointText.text = "You Died \n \n Score: " + score.ToString();;
        

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton()
    {

         SceneManager.LoadScene("MainMenu");
    }
}
