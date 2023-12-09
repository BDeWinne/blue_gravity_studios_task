using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClothesManager : MonoBehaviour
{
    public static ClothesManager Instance;
    [SerializeField] public List<Cloth> torsoList = new List<Cloth>();
    [SerializeField] public List<Cloth> hairList = new List<Cloth>();
    [SerializeField] public List<Cloth> hatList = new List<Cloth>();
    public int idPos { get; private set; } = 0;
    public UnityEvent idPosUpdated;
    void Awake()
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
    public void SetIdPos(int pos)
    {
        if (idPos != pos)
        {
            idPos = pos;
            idPosUpdated.Invoke();
        }
    }
}
[Serializable]
public class Cloth
{
    public List<Sprite> clothList;
}
