using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] int min, max;
    protected SpriteRenderer spriteRenderer;
    [SerializeField] protected int clothId;
    protected int defaultId;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (transform.parent.tag == "Player")
        {
            ClothesManager.Instance.idPosUpdated.AddListener(() => { SetCloth(clothId); });
        }
        defaultId = clothId;
        SetCloth(clothId);
    }
    public virtual void SetCloth(int id)
    {

    }
    public void SetClothId(int id)
    {
        if (id >= min && id <= max)
        {
            clothId = id;
            SetCloth(id);
        }
    }
    public void CheckIfWearing(int targetId)
    {
        if (clothId == targetId)
        {
            Debug.Log(targetId);
            clothId = defaultId;
            SetCloth(clothId);
        }
    }
}
