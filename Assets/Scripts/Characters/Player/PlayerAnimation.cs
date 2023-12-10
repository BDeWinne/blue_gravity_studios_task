using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void UpdateAnimation(Vector2 movement, Vector2 lastDirection)
    {
        animator.SetFloat("Horizontal", lastDirection.x);
        animator.SetFloat("Vertical", lastDirection.y);

        bool isRunning = movement.x != 0 || movement.y != 0;
        animator.SetBool("IsRunning", isRunning);
    }

    private void UpdateSpriteIdPosition(AnimationEvent evt)
    {
        if (evt.animatorClipInfo.weight > 0.5f)
        {
            ClothesManager.Instance.SetIdPos(evt.intParameter);
        }
    }
}
