using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;


    public GameObject[] lives;
    public GameObject[] keys;

    public Text dialogText;
    public Animator dialogPanel;

    void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text){
        CancelInvoke();
        dialogText.text = text;
        dialogPanel.gameObject.SetActive(true);
    }

    public void SetTextOut(){
        Invoke("TextOut", 1f);
    }

    void TextOut(){
        dialogPanel.Play("DialogExit");
        Invoke("DisableDialogPanel", 1f);
    }

    void DisableDialogPanel(){
        dialogPanel.gameObject.SetActive(false);
    }


    public void SetLives(int amount){
        for(int i = 0; i < lives.Length; i++){
            lives[i].SetActive(false);
        }

        for(int i = 0; i<amount; i++){
            lives[i].SetActive(true);
        }
    }

    public void SetKeys(int amount){
        for(int i = 0; i < keys.Length; i++){
            keys[i].SetActive(false);
        }

        for(int i = 0; i<amount; i++){
            keys[i].SetActive(true);
        }
    }


}
