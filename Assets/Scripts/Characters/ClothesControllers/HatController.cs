using UnityEngine;

public class HatController : BaseController
{
    public override void SetCloth(int id)
    {
        if (id != 2)
        {
            spriteRenderer.sprite = ClothesManager.Instance.hatList[id].clothList[ClothesManager.Instance.idPos];
        }
        else
        {
            spriteRenderer.sprite = null;
        }
    }
}
