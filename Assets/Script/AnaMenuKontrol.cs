using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AnaMenuKontrol : MonoBehaviour
{
    public GameObject CikisPanel;

    public void Start()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void OyundanCik()
    {
        CikisPanel.SetActive(true);
    }

    public void Cevap(string cevap)
    {
        if (cevap == "evet")
        {
            Application.Quit();
        }
        else
        {
            CikisPanel.SetActive(false);

        }
    }


    //Coklu level varsa oyuncunun en son kaldýðý yerden baþlamasý için playerpref ile set yapabiliriz. Kayýt sisteminden
    public void OyunaBasla()
    {
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(PlayerPrefs.GetInt("KaldigiYerdenDevamEt"));
    }
}
