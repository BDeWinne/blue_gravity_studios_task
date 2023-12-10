using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRange = 2f;

    private void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void OpenInventory()
    {
        UI_Manager.Instance.UpdateInventoryCapacityUI();
        UI_Manager.Instance.SwitchInventory(true);
        InventoryManager.Instance.DisplayItemsOnInventory();
    }

    private void TryInteract()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out NPC_Controller targetController))
            {
                if (targetController != null)
                {
                    targetController.TriggerInteraction();
                }
            }
        }
    }
}
