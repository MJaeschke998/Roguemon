using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] Color highlightedColor;
    
    [SerializeField] Text dialogText;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;
    
    [SerializeField] List<Text> actionText;
    [SerializeField] List<Text> moveTexts;
    

    [SerializeField] Text PPText;
    [SerializeField] Text typeTexts;

    

    public void setDialog(string dialog){
        dialogText.text = dialog;

    }
    
    public IEnumerator TypeDialog(string dialog){
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
    }

    public void EnableDialogText(bool enabled){
        dialogText.enabled=enabled;
    }
    public void EnableActionSelector(bool enabled){
        actionSelector.SetActive(enabled);
    }
    public void EnableMoveSelector(bool enabled){
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction){
        for(int i=0; i<actionText.Count; i++){
            if(i == selectedAction){
                actionText[i].color = highlightedColor;
            }else
                actionText[i].color = Color.black;
            
        }
    }
    public void UpdateMoveSelection(int selectedMove, move move){
        for(int i=0; i<moveTexts.Count; i++){
            if(i == selectedMove){
                moveTexts[i].color = highlightedColor;
            }else
                moveTexts[i].color = Color.black;
        }
        PPText.text = $"PP {move.PP}/{move.Base.PP}";
        typeTexts.text = move.Base.Type.ToString();
    }

    public void SetMoveNames(List<move> moves){
        for(int i=0;i<moveTexts.Count; i++){
            if(i<moves.Count)
            moveTexts[i].text = moves[i].Base.Name;
            else
            moveTexts[i].text = "-";
        }
    }

}
