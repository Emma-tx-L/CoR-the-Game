using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceButton : MonoBehaviour
{

    public string option;
    DialogueManager dialogueManager;
    GameControl control;
    AffectionManager af;

    void Start()
    {
        dialogueManager = DialogueManager.dialogueManager;
        control = GameControl.control;
        af = AffectionManager.affectionManager;
    }

    //finds text in the button and changes it 
    public void SetText(string newText)
    {
        GetComponentInChildren<Text>().text = newText;
    }

    //gets the option the player chose, will be used to determine next step
    public void SetOption(string newOption)
    {
        option = newOption;
    }
    

    public void ParseOption()
    {
        //option is retrieved from optionCommand in DialogueManager and looks like this:
        //string, int,int 
        //name of character to change affection for, affection change, line number to show next

        //split the option into its components and store it
        string[] parsedOption = option.Split(',');

        //for changing affection
        string partnerName = parsedOption[0];
        int affectionChange = int.Parse(parsedOption[1]);
        af.ChangeAffection(partnerName, affectionChange);


        int goToLineNumber = int.Parse(parsedOption[2]);

        dialogueManager.choosing = false;
        dialogueManager.ClearButtons();

        //pass everything back to DialogueManager so we update the UI
        DialogueManager.lineNum = goToLineNumber;
        dialogueManager.ShowDialogue();


    }

    
}