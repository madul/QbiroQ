using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //so can add scene
using UnityEngine;

public class DataController : MonoBehaviour
{
    //public RoundData[] allRoundData;
    private int globalScore;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene ("Scenes/LoginScene");
    }

    public int GetCurrentScore(){
        return globalScore;
    }
    public void updateScore(int scoreNovo){
        globalScore = scoreNovo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
