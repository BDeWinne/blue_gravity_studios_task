using System.Collections.Generic;
using UnityEngine;
public class NPC_Controller : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    public List<Item> items;
    public void TriggerInteraction()
    {
        DialogueManager.Instance.StartDialogue(dialogue, gameObject.name);
        DialogueManager.Instance.RemoveAcceptBtnConfig();
        DialogueManager.Instance.ConfigureAcceptBtn(this);
    }
    public void BuildTraderScreen()
    {
        TradePanelManager.Instance.BuildTradeScreen(this);
        UI_Manager.Instance.SwitchTradeScreen(true);
    }
}
