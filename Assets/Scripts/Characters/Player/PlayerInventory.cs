using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int coins { get; private set; } = 1000;
    public int maxInventorySpace { get; private set; } = 20;
}
