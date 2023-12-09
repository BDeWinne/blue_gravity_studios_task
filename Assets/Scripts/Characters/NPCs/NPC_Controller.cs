using System.Collections.Generic;
using UnityEngine;
public class NPC_Controller : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private List<Item> items;
    public void TriggerInteraction()
    {
        DialogueManager.Instance.StartDialogue(dialogue, gameObject.name);
    }
}
