using UnityEngine;

public class TorsoController : MonoBehaviour
{
    [Range(0, 3)][SerializeField] private int clothId;
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
        spriteRenderer.sprite = ClothesManager.Instance.torsoList[id].clothList[ClothesManager.Instance.idPos];
    }
    public void SetClothId(int id)
    {
        if (id >= 0 && id <= 3)
        {
            clothId = id;
            SetCloth(id);
        }
    }
}
