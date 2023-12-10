using UnityEngine;

public class HatController : MonoBehaviour
{
    [Range(0, 2)][SerializeField] private int clothId;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (transform.parent.tag == "Player")
        {
            ClothesManager.Instance.idPosUpdated.AddListener(() => { SetCloth(clothId); });
        }
        SetCloth(clothId);
    }
    public void SetCloth(int id)
    {
        if (id != 2)
        {
            spriteRenderer.sprite = ClothesManager.Instance.hatList[id].clothList[ClothesManager.Instance.idPos];
        }
    }
    public void SetClothId(int id)
    {
        if (id >= 0 && id <= 2)
        {
            clothId = id;
            SetCloth(id);
        }
    }
}
