using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogruAdetText, yanlisAdetText, toplamPuanText;

    [SerializeField]
    private GameObject birinciYildiz, ikinciYildiz, ucuncuYildiz;   


    public void SonuclariGoster(int dogruAdet, int yanlisAdet, int toplamPuan)
    {
        dogruAdetText.text =  dogruAdet.ToString();
        yanlisAdetText.text =  yanlisAdet.ToString();
        toplamPuanText.text =   toplamPuan.ToString();

        birinciYildiz.SetActive(false);
        ikinciYildiz.SetActive(false);
        ucuncuYildiz.SetActive(false);
        if(dogruAdet==1){
            birinciYildiz.SetActive(true);
        }
        else if(dogruAdet==3){
            birinciYildiz.SetActive(true);
            ikinciYildiz.SetActive(true);
        }
        else {
            birinciYildiz.SetActive(true);
            ikinciYildiz.SetActive(true);
            ucuncuYildiz.SetActive(true);
        }
    }

   public void yenidenOyna()
    {
        SceneManager.LoadScene(1);
    }
    public void home()
    {
        SceneManager.LoadScene(0);
    }
    
}
