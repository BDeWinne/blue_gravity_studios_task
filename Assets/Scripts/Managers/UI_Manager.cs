using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;
    [Header("UI Elements")]
    [SerializeField] private GameObject hud;
    [SerializeField] private TextMeshProUGUI[] coinTexts;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject dialogPanel;
    [Header("Others")]
    [SerializeField] private PlayerInventory playerInventory;
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
    public void SwitchInventory(bool state)
    {
        inventoryPanel.SetActive(state);
        SwitchHUD(!state);
    }
    void SwitchHUD(bool state)
    {
        hud.SetActive(state);
    }
    public void SwitchDialogue(bool state)
    {
        dialogPanel.SetActive(state);
    }
    public void UpdateCoinsUI()
    {
        for (int i = 0; i < coinTexts.Length; i++)
        {
            coinTexts[i].text = playerInventory.coins.ToString();
        }
    }
}
