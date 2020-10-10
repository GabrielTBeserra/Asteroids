using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehaviour : MonoBehaviour, IAmmo
{
    [SerializeField]
    private int amountAmmo;
    public int ammo()
    {
        return amountAmmo;
    }
}
