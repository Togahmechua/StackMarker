using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : TogaMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform childOfModel;
    [SerializeField] protected Transform child2OfModel;
    [SerializeField] protected WinPos winPos;

    // [SerializeField] protected Transform holder;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        // this.LoadChildModel();
        // this.LoadChild2Model();
        this.LoadWinPos();
        // this.LoadHolder();
    }

    protected virtual void LoadWinPos()
    {
        if (this.winPos != null) return;
        this.winPos = GameObject.FindObjectOfType<WinPos>();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }

    protected virtual void LoadChildModel()
    {
        if (this.childOfModel != null) return;
        this.childOfModel = transform.Find("jiao");
    }

    protected virtual void LoadChild2Model()
    {
        if (this.child2OfModel != null) return;
        this.child2OfModel = transform.Find("twei1");
    }

    // protected virtual void LoadHolder()
    // {
    //     if (this.holder != null) return;
    //     this.holder = transform.Find("Holder");
    // }
}
