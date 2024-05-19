using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : TogaMonoBehaviour
{
    [SerializeField] protected Transform startPos;
    [SerializeField] protected GameObject player;

    void Start()
    {
        this.PlayerPos(); 
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPos();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayerPos()
    {
        if (this.startPos != null) return;
        this.startPos = transform.Find("PlayerPos");
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        player = GameObject.Find("Player");
    }

    public void PlayerPos()
    {
        player.transform.position = startPos.position;    
    }
}
