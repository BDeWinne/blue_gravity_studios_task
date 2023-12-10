using System.Collections;
using UnityEngine;
using TMPro;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    [SerializeField] private TextMeshProUGUI dialogueText, nameText;
    [SerializeField] private Button nextBtn;
    [SerializeField] private GameObject optionsBtns;
    [SerializeField] private Button acceptBtn;
    private int currentLine = 0;
    private Dialogue dialogue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public async void StartDialogue(Dialogue dialogue, string name)
    {
        UI_Manager.Instance.SwitchDialogue(true);
        nameText.text = name;
        currentLine = 0;
        this.dialogue = dialogue;
        await TypeDialogue(this.dialogue.lines[currentLine]);
    }

    public async void ExecuteNextLine()
    {
        currentLine += 1;
        if (dialogue.lines[currentLine] != null)
        {
            await TypeDialogue(dialogue.lines[currentLine]);
        }
    }

    private async UniTask TypeDialogue(string line)
    {
        nextBtn.gameObject.SetActive(false);
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            await UniTask.DelayFrame(5);
        }
        if (currentLine + 1 < dialogue.lines.Length)
        {
            nextBtn.gameObject.SetActive(true);
        }
        else
        {
            ActivateOptionsBtns();
        }
    }
    public void EndDialogue()
    {
        dialogueText.text = "";
        UI_Manager.Instance.SwitchDialogue(false);
        optionsBtns.SetActive(false);
        dialogue = null;
    }

    private void ActivateOptionsBtns()
    {
        optionsBtns.SetActive(true);
    }
    public void ConfigureAcceptBtn(NPC_Controller npc)
    {
        acceptBtn.onClick.AddListener(() => { EndDialogue(); npc.BuildTraderScreen(); });
    }
    public void RemoveAcceptBtnConfig()
    {
        acceptBtn.onClick.RemoveAllListeners();
    }
}
[Serializable]
public class Dialogue
{
    [TextArea(1, 5)]
    public string[] lines;
}
