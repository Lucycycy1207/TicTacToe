using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ButtonManager buttonManager;

    [SerializeField]
    private GameObject Title;

    [SerializeField]
    private GameObject ResetButton;
    public string player = "X";

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Title.GetComponent<TextMeshProUGUI>().text);
        
        Title.GetComponent<TextMeshProUGUI>().text = "Player " + player + " Turn";

    }

    public void UpdateGame(string p)
    {
        //check if strike
        string result = buttonManager.CheckStrike();

        if (result == null)
        //if not strike, update Title
            UpdateTitle(p);
        else if (result == "Full")
        {
            Title.GetComponent<TextMeshProUGUI>().text = "Tied!";
        }
        else
        {
            Title.GetComponent<TextMeshProUGUI>().text = result;
        }
       
        
    }

    public void UpdateTitle(string p)
    {
        player = p;
        Title.GetComponent<TextMeshProUGUI>().text = "Player " + player + " Turn";
    }

    public void ResetPopUp()
    {
        ResetButton.SetActive(true);

    }
    public void ResetGamePanel()
    {
        ResetButton.SetActive(false);
        InitialState();



    }

    public void InitialState()
    {
        Title.GetComponent<TextMeshProUGUI>().text = "Tic Tac Toe";
        buttonManager.ResetButtons();

    }

}
