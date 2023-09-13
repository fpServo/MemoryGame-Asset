using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{

    private static GameObject Instance; // Statik obje durmadan devam eder bi nevi update gibisdinden.

    //Projenin sahneler aras�nda kaybolmamas�n�z sa�lar.  Sahneler aras� ge�i�te yok olmas�n� istemedi�imiz objeler i�iin yaz�lacak kod.
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        //Genel kullanilan bir kod blogudur bir kere ogrenmen yeterlidir.
        if (Instance == null)
            Instance = gameObject;
        else
            Destroy(gameObject); 
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
