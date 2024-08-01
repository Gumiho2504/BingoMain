using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class BingoGame : MonoBehaviour {

    [SerializeField] private TMP_Text resultText;
    [SerializeField] private Animator playBottonAnimator;
    [SerializeField] private GameObject resultGameObject;
    [SerializeField] private GameObject ballPrepab;
    [SerializeField] private GameObject crossPrefab;
    [SerializeField] private GameObject checkPrefab;
    public Slider loadSlider;
    public Text numberText;
    public Text bingoText;
    public GameObject[] boardSquares;
    public GameObject bingoCard;

    private List<int> numbers = new List<int>();
    private int currentNumber;
    [SerializeField] private Color32 trueColor,normalColor,startColor,unSelect;
    
    void Start() {
        StartCoroutine(Loading());
        //loadSlider.maxValue=2;
        for (int i = 0; i < boardSquares.Length; i++) {
            //int randomIndex = Random.Range(0, numbers.Count);
            boardSquares[i].GetComponentInChildren<Text>().text = "";
            boardSquares[i].GetComponent<Image>().color = startColor;
            //numbers.RemoveAt(randomIndex);
        }
        select = true;
    }

    // Update is called once per frame
    float timeCount = 3;
    float valueSlider = 0;
    bool timeAchive = false;
    [SerializeField] private Text timeText;
    void Update() {
 
        if(timeAchive){
            timeCount -= Time.deltaTime;
            timeText.text = Mathf.Round(timeCount).ToString();
            loadSlider.value += Time.deltaTime;
            
        }
        if(loadSlider.value >= 2.3){
            
        }
        if(timeCount <= 0){
            loadSlider.value=0;
            AudioController.Instance.SpawnBallSoundEfex();
            timeCount = 2;
            select = false;
            GenerateNextNumber();
        }
       

        
    }

    // Generate the next number and check if it appears on the player's Bingo card
    private List<int> resultNumber = new List<int>();
    int counter = 0;
    int result;
    public Color32[] ballColor;
    void GenerateNextNumber() {
        // Display the current number and remove it from the list of available numbers

        GameObject newPrefab = Instantiate(ballPrepab,transform.position, Quaternion.identity); 
        //List<int> ball = new List<int>();
        //for(int i = 0;i<8;i++){ball.Add(i);}
        int colorIndex = Random.Range(0,9);
        //ball.RemoveAt(colorIndex1);
        //int colorIndex = ball[colorIndex1];
        //if(ball.Count == 0){ for(int i = 0;i<8;i++){ball.Add(i);}}
        newPrefab.GetComponent<Image>().color = ballColor[colorIndex];
        newPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("ResultGrild").transform, false);
        

        currentNumber = Random.Range(0, resultNumber.Count);
        //print(currentNumber);
        result = resultNumber[currentNumber];
        newPrefab.GetComponentInChildren<Text>().text = result.ToString();
        numberText.text = currentNumber.ToString();
        resultNumber.RemoveAt(currentNumber);
        counter++;
        if(counter == 25){
            bingoText.text = "LOSE TRY AGIANT !";
            timeAchive = false;
            //bingoText.gameObject.SetActive(true);
            //numberText.gameObject.SetActive(false);
           StartCoroutine(ReSartGame());
            // for (int i = 1; i <= 75; i++) {
            //     numbers.Add(i);
            // }
            //     Shuffle(numbers);
        }

        StartCoroutine(CrossWhenUnselectTrueNumber());
        

        //Check for a winning condition (five in a row)
        if (CheckForWin()) {
            timeAchive = false;
            resultGameObject.SetActive(true);
            resultText.text = "Bingo";
            AudioController.Instance.BingoSound();
            //bingoText.gameObject.SetActive(true);
            //numberText.gameObject.SetActive(false);
            //Invoke("ReSartGame",3f);
        }
    }
   
    IEnumerator CrossWhenUnselectTrueNumber(){
        yield return new WaitForSeconds(1.9f);
        
        if(!select){
            for(int i =0; i<25;i++){
                select = true;
                GameObject t = bingoCard.transform.GetChild(i).gameObject;
                if(t.GetComponentInChildren<Text>().text == result.ToString()){
                    t.GetComponent<Image>().color = unSelect;
                
                        //t.GetComponentInChildren<Text>().text = "✗";
                        //t.GetComponentInChildren<Text>().color = Color.white;  
                        GameObject cross = Instantiate(crossPrefab, transform.position, Quaternion.identity);
                        cross.GetComponent<RectTransform>().SetParent(t.transform, false);
                    
                    
                }
            }
        }
    }

    bool CheckForWin(){
        bool win = false;
        // Row
        if(bingoCard.transform.GetChild(0).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(1).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(2).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(3).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(4).GetComponent<Image>().color == trueColor){
            win = true;
        }
        else if(bingoCard.transform.GetChild(5).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(6).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(7).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(8).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(9).GetComponent<Image>().color == trueColor){
            win = true;
        }
        else if(bingoCard.transform.GetChild(10).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(11).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(12).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(13).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(14).GetComponent<Image>().color == trueColor){
            win = true;
        }
        else if(bingoCard.transform.GetChild(15).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(16).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(17).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(18).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(19).GetComponent<Image>().color == trueColor){
            win = true;
        }
        else if(bingoCard.transform.GetChild(20).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(21).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(22).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(23).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(24).GetComponent<Image>().color == trueColor){
            win = true;
        }

        //Column
        if(bingoCard.transform.GetChild(0).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(5).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(10).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(15).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(20).GetComponent<Image>().color == trueColor){
            win = true;
        }
        else if(bingoCard.transform.GetChild(1).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(6).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(11).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(16).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(21).GetComponent<Image>().color == trueColor){
            win = true;
        }
        else if(bingoCard.transform.GetChild(2).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(7).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(12).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(17).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(22).GetComponent<Image>().color == trueColor){
            win = true;
        }
        else if(bingoCard.transform.GetChild(3).GetComponent<Image>().color ==trueColor &&
            bingoCard.transform.GetChild(8).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(13).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(18).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(23).GetComponent<Image>().color == trueColor){
            win = true;
        }
        else if(bingoCard.transform.GetChild(4).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(9).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(14).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(19).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(24).GetComponent<Image>().color == trueColor){
            win = true;
        }

        //Cross
        if(bingoCard.transform.GetChild(0).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(6).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(12).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(18).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(24).GetComponent<Image>().color == trueColor){
            win = true;
        }
        else if(bingoCard.transform.GetChild(4).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(8).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(12).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(16).GetComponent<Image>().color == trueColor &&
            bingoCard.transform.GetChild(20).GetComponent<Image>().color == trueColor){
            win = true;
        }

        return win;
    }
    // Check if the player has five in a row and return true if they do
    // bool CheckForWin() {
    //     bool win = false;

    //     // Check horizontal rows
    //     for (int i = 0; i < 5; i++) {
    //         win |= (bingoCard.transform.GetChild(i).GetChild(0).GetComponent<Image>().color == Color.gray &&
    //                 bingoCard.transform.GetChild(i).GetChild(1).GetComponent<Image>().color == Color.gray &&
    //                 bingoCard.transform.GetChild(i).GetChild(2).GetComponent<Image>().color == Color.gray &&
    //                 bingoCard.transform.GetChild(i).GetChild(3).GetComponent<Image>().color == Color.gray &&
    //                 bingoCard.transform.GetChild(i).GetChild(4).GetComponent<Image>().color == Color.gray);
    //     }

    //     // Check vertical columns
    //     for (int i = 0; i < 5; i++) {
    //         win |= (bingoCard.transform.GetChild(0).GetChild(i).GetComponent<Image>().color == Color.gray &&
    //                 bingoCard.transform.GetChild(1).GetChild(i).GetComponent<Image>().color == Color.gray &&
    //                 bingoCard.transform.GetChild(2).GetChild(i).GetComponent<Image>().color == Color.gray &&
    //                 bingoCard.transform.GetChild(3).GetChild(i).GetComponent<Image>().color == Color.gray &&
    //                 bingoCard.transform.GetChild(4).GetChild(i).GetComponent<Image>().color == Color.gray);
    //     }

    //     // Check diagonal lines
    //     win |= (bingoCard.transform.GetChild(0).GetChild(0).GetComponent<Image>().color == Color.gray &&
    //             bingoCard.transform.GetChild(1).GetChild(1).GetComponent<Image>().color == Color.gray &&
    //             bingoCard.transform.GetChild(2).GetChild(2).GetComponent<Image>().color == Color.gray &&
    //             bingoCard.transform.GetChild(3).GetChild(3).GetComponent<Image>().color == Color.gray &&
    //             bingoCard.transform.GetChild(4).GetChild(4).GetComponent<Image>().color == Color.gray);

    //     win |= (bingoCard.transform.GetChild(0).GetChild(4).GetComponent<Image>().color == Color.gray &&
    //             bingoCard.transform.GetChild(1).GetChild(3).GetComponent<Image>().color == Color.gray &&
    //             bingoCard.transform.GetChild(2).GetChild(2).GetComponent<Image>().color == Color.gray &&
    //             bingoCard.transform.GetChild(3).GetChild(1).GetComponent<Image>().color == Color.gray &&
    //             bingoCard.transform.GetChild(4).GetChild(0).GetComponent<Image>().color == Color.gray);

    //     return win;
    // }

    // Shuffle a list of integers using the Fisher-Yates algorithm
    void Shuffle(List<int> list) {
        for (int i = 0; i < list.Count; i++) {
        int temp = list[i];
        int randomIndex = Random.Range(i, list.Count);
        list[i] = list[randomIndex];
        list[randomIndex] = temp;
    }
}

// Restart the game by resetting the board and generating new numbers
void RestartGame() {
    // Reset the game board
    for (int i = 0; i < boardSquares.Length; i++) {
        boardSquares[i].GetComponentInChildren<Text>().text = "";
    }

    // Reset the player's Bingo card
    foreach (Transform child in bingoCard.transform) {
        foreach (Transform grandchild in child) {
            grandchild.GetComponent<Image>().color = Color.white;
        }
    }

    // Reset the list of available numbers and shuffle it
    numbers.Clear();
    for (int i = 1; i <= 25; i++) {
        numbers.Add(i);
    }
    Shuffle(numbers);

    // Generate the first number
    bingoText.gameObject.SetActive(false);
    numberText.gameObject.SetActive(true);
    GenerateNextNumber();
}



    void CreateBall(){
        GameObject newPrefab = Instantiate(ballPrepab,transform.position, Quaternion.identity);
        newPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("ResultGrild").transform, false);
    }


    IEnumerator ReSartGame(){
        yield return new WaitForSeconds(2f);
        resultGameObject.SetActive(true);
        if(resultText.text != "Bingo Win"){
        resultText.text = "Try Again!";
        AudioController.Instance.LoseSound();
        }
    }

    bool isGetCard = true;
    public GameObject messageGameObject,handGameObject;
    public void GetBigoCardButton(Button b){
        
        if(isGetCard){
            select = false;
            AudioController.Instance.TapSound();
            b.GetComponent<Image>().color = Color.grey;
            playBottonAnimator.Play("idle");
            isGetCard = !isGetCard;
            messageGameObject.SetActive(isGetCard);
            handGameObject.SetActive(isGetCard);
            GetBigoCard();
            timeAchive = true;
       }
    }
    private void GetBigoCard(){
        for (int i = 1; i <= 25; i++) {
                numbers.Add(i);
                resultNumber.Add(i);
            }
            Shuffle(numbers);
            Shuffle(resultNumber);

            //Set up the game board with random numbers
        for (int i = 0; i < boardSquares.Length; i++) {
            int randomIndex = Random.Range(0, numbers.Count);
            boardSquares[i].GetComponentInChildren<Text>().text = numbers[randomIndex].ToString();
            boardSquares[i].GetComponent<Image>().color = normalColor;
            numbers.RemoveAt(randomIndex);
        }
}
    
    bool select = false;
    public void BoxButton(Button b){
        if(select == false){
            GameObject t = b.transform.GetChild(0).gameObject;
        //    print("result " +result);
            if(t.GetComponentInChildren<Text>().text == result.ToString()){
                select = true;
                b.GetComponent<Image>().color = trueColor;
                AudioController.Instance.TapSound();
                //t.GetComponentInChildren<Text>().text = "✔";
                //t.GetComponentInChildren<Text>().color = Color.green;
                GameObject check = Instantiate(checkPrefab, transform.position, Quaternion.identity);
                check.GetComponent<RectTransform>().SetParent(t.transform, false);            
            }else{
                AudioController.Instance.WrongClickSound();
            }
        }
        //print(t.GetComponentInChildren<Text>().text);
    }

    public void HomeButton(){
        AudioController.Instance.TapSound();
        SceneManager.LoadScene("Loading");
        //StartCoroutine(Loading1());
    }
    public void PlayAgainButton(){
        AudioController.Instance.TapSound();
        SceneManager.LoadScene("BingoGame");
    }

    public GameObject LoadingScene;
    IEnumerator Loading()
    {
        LoadingScene.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        LoadingScene.SetActive(false);
    }


    /*IEnumerator Loading1()
    {

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("MenuScene");
    }*/



}//end of class