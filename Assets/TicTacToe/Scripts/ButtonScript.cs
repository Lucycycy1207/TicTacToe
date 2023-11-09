using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class ButtonScript : MonoBehaviour
{

    [SerializeField]
    private TMP_Text txtSign;


    [SerializeField]
    private GameObject CurrentButton;

    [SerializeField]
    private ButtonManager buttonManager;

    [SerializeField]
    private Button button;


    public void UpdateButton()
    {
        TurnOffButton();
        buttonManager.UpdateButton(txtSign);
    }

    public void TurnOffButton()
    {

        //private Button mybutton;
        button = CurrentButton.GetComponent<Button>();
        button.enabled = false;
    }



}
