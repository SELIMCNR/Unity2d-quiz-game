using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public Soru[] sorular;
    private static List<Soru> cevaplanmamisSorular;
    private Soru gecerliSoru;

    [SerializeField]
    private Text soruText;
    [SerializeField]
    private Text dogruCevapText,yanlisCevapText;

    [SerializeField]
    private GameObject dogruButton, yanlisButton;

    int toplamPuan;

    int dogruAdet, yanlisAdet;

    [SerializeField]
    private GameObject sonucPanel;

    SonucManager sonucManager;

    void Start()
    {
        if(cevaplanmamisSorular == null || cevaplanmamisSorular.Count==0)
        {
            cevaplanmamisSorular = sorular.ToList<Soru>();
        }

        RastgeleSoruSec();

        dogruAdet=0;
        yanlisAdet=0;
        toplamPuan=0;

    }

    void RastgeleSoruSec()
    {

        yanlisButton.GetComponent<RectTransform>().DOLocalMoveX(319f, 0.2f);
        dogruButton.GetComponent<RectTransform>().DOLocalMoveX(-323f, 0.2f);

        int randomSoruIndex = Random.Range(0, cevaplanmamisSorular.Count);
        gecerliSoru = cevaplanmamisSorular[randomSoruIndex];

        soruText.text = gecerliSoru.soru;
      

        if (gecerliSoru.dogrumu == true)
        {
               dogruCevapText.text = "Yanlış  Cevapladınız";
            yanlisCevapText.text = "Doğru Cevapladınız";
        }
        else if (gecerliSoru.dogrumu == false)
        {
             dogruCevapText.text = "Doğru Cevapladınız";
              yanlisCevapText.text = "Yanlış Cevapladınız";
          

        }

    }

    IEnumerator SorularArasiBekleRoutine()
    {
        cevaplanmamisSorular.Remove(gecerliSoru);
        yield return new WaitForSeconds(1f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (cevaplanmamisSorular.Count <= 0)
        {
          
            Debug.Log("Sorular Bitti"+ "Doğru Sayısı: "+dogruAdet+" Yanlış Sayısı: "+yanlisAdet);   
            sonucPanel.SetActive(true);
            sonucManager = Object.FindObjectOfType<SonucManager>();
            sonucManager.SonuclariGoster(dogruAdet, yanlisAdet, toplamPuan);
        }
        else
        {
              RastgeleSoruSec();
        }
   
    }

    public void dogruButonaBasildi()
    {
        if (gecerliSoru.dogrumu)
        {
                dogruAdet++;
                toplamPuan+=100;
        }
        else
        {
            yanlisAdet++;
        }
        yanlisButton.GetComponent<RectTransform>().DOLocalMoveX(1000f, .2f);
        StartCoroutine(SorularArasiBekleRoutine());
    }


    public void yanlisButonaBasildi()
    {
        if (!gecerliSoru.dogrumu)
        {
            dogruAdet++;
            toplamPuan+=100;
        }
        else
        {
            yanlisAdet++;
        }
       
        dogruButton.GetComponent<RectTransform>().DOLocalMoveX(-1000f, .2f);

        StartCoroutine(SorularArasiBekleRoutine());
    }
}
