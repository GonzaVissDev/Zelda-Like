using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CanvasManagement : MonoBehaviour
{
    private Animator Canvas_Anim;
    public string CurrentMap;
    private string GO;
    private Player PlayerScript;
   
    void Start(){
        Canvas_Anim = GetComponent<Animator>();
        Canvas_Anim.Play("P_In");
        StartCoroutine(TextMap(CurrentMap));
        GO = "GameOver";

        PlayerScript = GetComponent<Player>();
        GameObject PlayerObject = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObject != null) PlayerScript = PlayerObject.GetComponent<Player>();

    }

    private void Update()
    {
        if (PlayerScript.HP_Player <=-1 )
        {
            GameOver();
        }
    }
    public void PlayerIn(){
        Canvas_Anim.Play("P_In");
    }

    public void PlayerOut(){
        Canvas_Anim.Play("P_Out");
    }
 
    public IEnumerator TextMap(string Map)
    {
    
        transform.GetChild(0).GetComponent<Text>().text = Map;
        transform.GetChild(1).GetComponent<Text>().text = Map;

        Canvas_Anim.SetBool("Text", true);
      
        yield return new WaitForSeconds(1.5f);
        Canvas_Anim.SetBool("Text", true);
        Canvas_Anim.SetBool("Text", false);
       
      
    }

    void GameOver()
    {
        
        transform.GetChild(0).GetComponent<Text>().text = GO ;
        transform.GetChild(1).GetComponent<Text>().text = GO;
        Canvas_Anim.SetBool("Text", true);

        Invoke("ChangeScene", 3f);
       
    }
     
  public  void WinGame()
    {
        GO = "Gracias Por Jugar";
        transform.GetChild(0).GetComponent<Text>().text = GO;
        transform.GetChild(1).GetComponent<Text>().text = GO;
        Canvas_Anim.SetBool("Text", true);
        StartCoroutine(CloseGame());
    }

    void ChangeScene()
    {
        Canvas_Anim.Play("P_In");
        SceneManager.LoadScene("InnerHouse");
    }

    IEnumerator CloseGame()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}