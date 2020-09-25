using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace SwipeableView
{
public class GameController : MonoBehaviour {

    public Text scoreDisplayText;
    public GameObject roundEndDisplay;
    public GameObject nextLevelPanel;
    public GameObject mesmoNivelPanel;
    public GameObject parabensText;
    public GameObject quaseText;

    public GameObject concordoButton;
    public GameObject naoConcordoButton;

    private int questionIndex;
    private int playerScore;
    private int globalScore;

    private DataController dataController;
   
    private bool[] answers;

    // Use this for initialization
    void Start () 
    {
        playerScore = 0;
        questionIndex = 0;
  
        answers = LoadTextureScene.answers;

        dataController = FindObjectOfType<DataController> ();
        //Debug.Log(dataController.GetCurrentScore());
        globalScore = dataController.GetCurrentScore();

        nextLevelPanel.SetActive(false);
        mesmoNivelPanel.SetActive(false);
        parabensText.SetActive(false);
        quaseText.SetActive(false);
        roundEndDisplay.SetActive(false);
    }

    public void LikeAnswerButtonClicked()
    {
       // Debug.Log(true & false);
        //Debug.Log(false & false);
       // Debug.Log("Index: " + questionIndex + "Answer: " + answers[questionIndex] );//+ "&True: " + answers[questionIndex] & true);
        if (!(answers[questionIndex] ^ true)) 
        {
            playerScore += 10; //currentRoundData.pointsAddedForCorrectAnswer;
        }
        else{
            playerScore -= 10;
        }

        if (9> questionIndex) {
            questionIndex++;
            //ShowQuestion ();
        } else 
        {
            EndRound();
        }

    }

    public string getGlobalScore(){
        return globalScore.ToString();
    }

    public void NopeAnswerButtonClicked()
    {
       if (!(answers[questionIndex] ^ false)) 
        {
            playerScore += 10; //currentRoundData.pointsAddedForCorrectAnswer;
        }
        else{
            playerScore -= 10;
        }
        
        if (9 > questionIndex) {
            questionIndex++;
        } else 
        {
            EndRound();
        }

    }

    public void EndRound()
    {
        if (playerScore >= 80){

            parabensText.SetActive(true);
            nextLevelPanel.SetActive(true);
        }
        else if (playerScore >= 60){
            quaseText.SetActive(true);
            nextLevelPanel.SetActive(true);
        }
        else{
            mesmoNivelPanel.SetActive(true);
        }

        globalScore = playerScore;
        dataController.updateScore(globalScore);
        //Debug.Log("Global: "+ globalScore);
        scoreDisplayText.text = playerScore.ToString();
        roundEndDisplay.SetActive (true);
        concordoButton.SetActive(false);
        naoConcordoButton.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene ("Scenes/Texture/LoadTextureScene");
    }
}
}