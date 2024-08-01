using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour{
    //public GameObject homeScreen;
    //AudioController a;
    //public AudioClip bgClip;
    //bool isStart ;
    void Start(){

      //isStart = State();
    }

    //bool State (){
    //    var isState = false;
    //    var switchGame = new GameLanguage();
    //    string state1 = switchGame.AppLanguage();
    //    //string lavel = switchGame.GetIPAddress();
    //    //string state2 = switchGame.GetLocationFromIP(lavel);
    //    print(state1 );
    //    if(state1 == "VN"){
    //        isState = true;
    //    }else{isState = false;}
    //    return isState;
    //}
   
    public void QuitButton(){
        AudioController.Instance.TapSound();
        Application.Quit();
    }
    public void HomeButton(){
         AudioController.Instance.TapSound();
        SceneManager.LoadScene("MenuScene");
    }
    public void PlayAgainButton(){
        //if(isStart){
        //    SceneManager.LoadScene("LoadingScene");
        //}else if(!isStart){
            SceneManager.LoadScene("BingoGame");
        //}
    }
    
   
    

}