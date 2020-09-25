using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HistoricoController : MonoBehaviour
{
    private DataController dataController;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController> ();
        scoreText.text = dataController.GetCurrentScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
