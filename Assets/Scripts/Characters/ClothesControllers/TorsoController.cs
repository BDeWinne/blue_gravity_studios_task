using UnityEngine;

public class TorsoController : BaseController
{
    public override void SetCloth(int id)
    {
        spriteRenderer.sprite = ClothesManager.Instance.torsoList[id].clothList[ClothesManager.Instance.idPos];
    }
}
