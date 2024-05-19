using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPos : TogaMonoBehaviour
{
    public Transform openChest;
    public Transform closeChest;
    public Transform playerPrefab;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCloseChest();
        this.LoadOpenChest();
        this.LoadplayerPrefab();
    }

    protected virtual void LoadOpenChest()
    {
        if (this.openChest != null) return;
        this.openChest = transform.Find("baoxiang_open");
    }

    protected virtual void LoadCloseChest()
    {
        if (this.closeChest != null) return;
        this.closeChest = transform.Find("baoxiang_close");
    }

    protected virtual void LoadplayerPrefab()
    {
        if (this.playerPrefab != null) return;
        this.playerPrefab = transform.Find("People");
    }
}
