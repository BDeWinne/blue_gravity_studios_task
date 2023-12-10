using UnityEngine;

public class HairController : BaseController
{
    [SerializeField] private Color hairColor;
    protected override void Start()
    {
        base.Start();
        SetColor();
    }
    public override void SetCloth(int id)
    {
        spriteRenderer.sprite = ClothesManager.Instance.hairList[id].clothList[ClothesManager.Instance.idPos];
    }
    public void SetColor()
    {
        spriteRenderer.color = hairColor;
    }
}
