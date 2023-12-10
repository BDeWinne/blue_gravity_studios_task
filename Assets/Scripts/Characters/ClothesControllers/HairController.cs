using UnityEngine;

public class HairController : MonoBehaviour
{
    [Range(0, 1)][SerializeField] private int clothId;
    SpriteRenderer spriteRenderer;
    [SerializeField] Color hairColor;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (transform.parent.tag == "Player")
        {
            ClothesManager.Instance.idPosUpdated.AddListener(() => { SetCloth(clothId); });
        }
        SetCloth(clothId);
        SetColor();
    }
    public void SetCloth(int id)
    {
        spriteRenderer.sprite = ClothesManager.Instance.hairList[id].clothList[ClothesManager.Instance.idPos];
    }
    public void SetColor()
    {
        spriteRenderer.color = hairColor;
    }
    public void SetClothId(int id)
    {
        if (id > 0 && id <= 1)
        {
            clothId = id;
        }
    }
}
