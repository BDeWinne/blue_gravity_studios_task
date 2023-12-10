using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;
    [Header("UI Elements")]
    [SerializeField] private GameObject hud;
    [SerializeField] private TextMeshProUGUI[] coinTexts;
    [SerializeField] private TextMeshProUGUI inventoryText;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject tradePanel;
    [SerializeField] private TextMeshProUGUI overText;
    [Header("Others")]
    [SerializeField] private PlayerInventory playerInventory;
    public bool PanelOpen { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdateCoinsUI();
    }
    void Update()
    {
        MoveOverText();
    }
    public void SwitchInventory(bool state)
    {
        if (PanelOpen && state)
        {
            return;
        }
        PanelOpen = state;
        inventoryPanel.SetActive(state);
        SwitchHUD(!state);
    }
    public void SwitchTradeScreen(bool state)
    {
        if (PanelOpen && state)
        {
            return;
        }
        PanelOpen = state;
        tradePanel.SetActive(state);
        SwitchHUD(!state);
    }
    void SwitchHUD(bool state)
    {
        hud.SetActive(state);
    }
    public void SwitchDialogue(bool state)
    {
        if (PanelOpen && state)
        {
            return;
        }
        PanelOpen = state;
        dialogPanel.SetActive(state);
    }
    public void UpdateCoinsUI()
    {
        for (int i = 0; i < coinTexts.Length; i++)
        {
            coinTexts[i].text = playerInventory.coins.ToString();
        }
    }
    public void UpdateInventoryCapacityUI()
    {
        inventoryText.text = string.Concat(playerInventory.Items.Count, "/", playerInventory.maxInventorySpace);
    }
    public void SwitchOverText(string text, bool state)
    {
        overText.gameObject.SetActive(state);
        overText.text = text;
    }
    void MoveOverText()
    {
        if (overText.gameObject.activeSelf)
        {
            overText.transform.position = Input.mousePosition;
        }
    }
}
