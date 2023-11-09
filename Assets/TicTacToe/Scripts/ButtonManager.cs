using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttons;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private TMP_Text txtSign;

    private string player;

    [SerializeField]
    private GameObject CurrentButton;

    [SerializeField]
    private GameObject[] StrikesOuts;





    private int[,] strikeCond =
        {
        {0,1,2}, {3,4,5}, {6,7,8},
        {0,3,6}, {1,4,7}, {2,5,8},
        {0,4,8}, {2,4,6}
        };//HorizontalU,HorizontalM, HorizontalD,
          //VerticalL, verticalM, verticalR
          //Cross2, cross1
    private int[] strikeIndex = { 3, 4, 5, 0, 1, 2, 7, 6 };



    private void ChangeTurn()
    {
        if (player == "X")
        {
            player = "O";
        }
        else
        {
            player = "X";
        }
    }

    public void UpdateButton(TMP_Text txtSign)
    {
        player = gameManager.player;
        txtSign.text = player;
        ChangeTurn();
        gameManager.UpdateGame(player);

    }

    public string CheckStrike()
    {

        string buttonText1;
        string buttonText2;
        string buttonText3;

        
        for (int i = 0; i < strikeCond.GetLength(0); i++)
        {
            buttonText1 = buttons[strikeCond[i, 0]].GetComponentInChildren<TextMeshProUGUI>().text;
            buttonText2 = buttons[strikeCond[i, 1]].GetComponentInChildren<TextMeshProUGUI>().text;
            buttonText3 = buttons[strikeCond[i, 2]].GetComponentInChildren<TextMeshProUGUI>().text;


            if (buttonText1 == buttonText2 &&
                buttonText1 == buttonText3 &&
                buttonText1 != "")
            {
                //Strike!
                string winMessage = buttonText1 + " Wins!";
                
                SetStrikeUI(strikeIndex[i]);
                return winMessage;
               
            }
        }
        //check if game panel is full
        int isFull = 1;
        string value;
        for (int i = 0; i < buttons.Length; i++)
        {
            value = buttons[i].GetComponentInChildren<TextMeshProUGUI>().text;
            if (value == "")
            {
                isFull = 0;
                break;
            }
        }

        if (isFull == 1)
        {

            gameManager.ResetPopUp();
            return "Full";
        }

        return null;

    }
    public void SetStrikeUI(int index){
        StrikesOuts[index].SetActive(true);
        gameManager.ResetPopUp();
    }

    public void ResetButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
            buttons[i].GetComponent<Button>().enabled = true;
        }
        for (int i = 0; i < StrikesOuts.Length; i++)
        {
            StrikesOuts[i].SetActive(false); ;
        }

    }
}
