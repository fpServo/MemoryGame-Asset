using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OyunKontrol1 : MonoBehaviour
{
    int IlkSecimDegeri;
    GameObject Sec�lenButton;
    GameObject ButonunKendisi;
    public Sprite DefaultSprite;

    void Start()
    {
        IlkSecimDegeri = 0;
    }

    void Update()
    {
        
    }

    public void ButtonT�klandi(int deger)
    {
        Kontrol(deger, ButonunKendisi);
    }

    public void ObjeVer(GameObject objem)
    {
        ButonunKendisi = objem;
        ButonunKendisi.GetComponent<Image>().sprite = ButonunKendisi.GetComponentInChildren<SpriteRenderer>().sprite; 
    }

    void Kontrol(int gelendeger, GameObject gelenobje)
    {
        if (IlkSecimDegeri == 0)
        {
            IlkSecimDegeri = gelendeger;
            Sec�lenButton = gelenobje;
        }
        else
        {
            if (IlkSecimDegeri == gelendeger)
            {
                IlkSecimDegeri = 0;
            }

            else
            {
                Sec�lenButton.GetComponent<Image>().sprite = DefaultSprite;
                gelenobje.GetComponent<Image>().sprite = DefaultSprite;

                IlkSecimDegeri = 0; 
            }
        }
    }

}
