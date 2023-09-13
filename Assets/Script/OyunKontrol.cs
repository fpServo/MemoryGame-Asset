using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour
{

    // GENEL AYARLAR
    public int hedefbasari;
    int ilkSecimDegeri;
    int anlikbasari;
    //-----------------------
    GameObject secilenButon;
    GameObject butonunKendisi;
    //-----------------------
    public Sprite defaultSprite;
    public AudioSource[] sesler;
    public GameObject[] Butonlar;
    public TextMeshProUGUI Sayac;
    public GameObject[] OyunSonuPaneller;
    public Slider ZamanSlider;
    // SAYAÇ
    public float ToplamZaman;
    float dakika;
    float saniye;
    bool zamanlayici;
    float GecenZaman;
    //-----------------------  

    public GameObject Grid;
    public GameObject Havuz;
    bool OlusturmaDurumu;
    int OlusturmaSayisi;
    int ToplamResimSayisi;


    void Start()
    {
        ilkSecimDegeri = 0;
        zamanlayici = true;

        GecenZaman = 0;
        ZamanSlider.maxValue = ToplamZaman;
        ZamanSlider.value = GecenZaman;
        OlusturmaSayisi = 0;
        OlusturmaDurumu = true;
        ToplamResimSayisi = Havuz.transform.childCount;


        //BONUS; SADECE BİLGİ İÇİN NOT .
        /*
        GameObject obje = Instantiate(EklenecekObje);
        obje.transform.SetParent(Grid.transform);

        RectTransform rt = obje.GetComponent<RectTransform>();
        rt.localScale = new Vector3(.358f, .544f, 1f);
       */

        //Debug.Log(Havuz.transform.GetChild(RastgeleSayi).name);

        StartCoroutine(Olustur());
    } 


    IEnumerator Olustur()
    {
        yield return new WaitForSeconds(.1f);

        while (OlusturmaDurumu)
        {
            int RastgeleSayi = Random.Range(0, Havuz.transform.childCount - 1);

            if (Havuz.transform.GetChild(RastgeleSayi).gameObject != null)
            {
                Havuz.transform.GetChild(RastgeleSayi).transform.SetParent(Grid.transform);
                OlusturmaSayisi++;

                if (OlusturmaSayisi == ToplamResimSayisi)
                {
                    OlusturmaDurumu = false;
                    Destroy(Havuz.gameObject);
                }
            }
            
        }
    }


    private void Update()
    {

        if (zamanlayici && ToplamZaman>1 && GecenZaman!=ToplamZaman)
        {
            GecenZaman += Time.deltaTime;
            ZamanSlider.value = GecenZaman;
            if (ZamanSlider.maxValue == ZamanSlider.value)
            {
                zamanlayici = false;
                GameOver();
            }

            /*
            dakika = Mathf.FloorToInt(ToplamZaman / 60); //  119 / 2 = 1       
            saniye = Mathf.FloorToInt(ToplamZaman % 60); // 119 / 2 = 1 *****  => 59     

            // Sayac.text = Mathf.FloorToInt(ToplamZaman).ToString();
            Sayac.text = string.Format("{0:00}:{1:00}", dakika, saniye);
            */

        }else
        {
            zamanlayici = false;
            GameOver();
        }
       
    }
    public void Oyunudurdur()
    {
        OyunSonuPaneller[2].SetActive(true);
        Time.timeScale = 0;

    }
    public void OyunaDevamEt()
    {
        OyunSonuPaneller[2].SetActive(false);
        Time.timeScale = 1;

    }

    public void OyunDurduruldu()
    {
        OyunSonuPaneller[2].SetActive(true); 
        Time.timeScale = 0;
    } 
    
    public void OyunaDevamEtt()
    {
        OyunSonuPaneller[2].SetActive(false); 
        Time.timeScale = 1;
    }

    void GameOver()
    {
        OyunSonuPaneller[0].SetActive(true);

    }
    void Win()
    {
        OyunSonuPaneller[1].SetActive(true);

    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("AnaMenu");

    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }

    public void ObjeVer(GameObject objem) 
    {
        butonunKendisi = objem;

        butonunKendisi.GetComponent<Image>().sprite = butonunKendisi.GetComponentInChildren<SpriteRenderer>().sprite;
        butonunKendisi.GetComponent<Image>().raycastTarget = false;
        sesler[0].Play();
    }

    void Butonlarindurumu(bool durum)
    {
        foreach (var item in Butonlar)
        {
            if (item!=null)
            {
                item.GetComponent<Image>().raycastTarget = durum;

            }            
        }

    }
    
    public void ButonTikladi(int deger)
    {

        Kontrol(deger);
        
    }   

    void Kontrol(int gelendeger)
    {

        if (ilkSecimDegeri == 0)
        {
            ilkSecimDegeri = gelendeger;
            secilenButon = butonunKendisi;
        }
        else
        {
            StartCoroutine(kontroletbakalim(gelendeger));
        }

    }
    IEnumerator kontroletbakalim(int gelendeger)
    {
        Butonlarindurumu(false);
        yield return new WaitForSeconds(1);

        if (ilkSecimDegeri == gelendeger)
        {
            anlikbasari++;
            secilenButon.GetComponent<Image>().enabled = false;
            butonunKendisi.GetComponent<Image>().enabled = false;
            // secilenButon.GetComponent<Button>().enabled = false;
            // butonunKendisi.GetComponent<Button>().enabled = false;
            ilkSecimDegeri = 0;
            secilenButon = null;
            Butonlarindurumu(true);

            if (hedefbasari == anlikbasari)
            {
                Win();

            }
        }
        else
        {
          
            sesler[1].Play();
            secilenButon.GetComponent<Image>().sprite = defaultSprite;
            butonunKendisi.GetComponent<Image>().sprite = defaultSprite;            
            ilkSecimDegeri = 0;
            secilenButon = null;
            Butonlarindurumu(true);


        }

    }
}
