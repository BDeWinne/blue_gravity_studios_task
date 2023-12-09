using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
    public static ClothesManager Instance;
    [SerializeField] private List<Sprite> torsoClothes;
    [SerializeField] private List<Sprite> hairStyles;
    [SerializeField] private List<Sprite> hats;

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
}
