using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHit : TogaMonoBehaviour
{
    [SerializeField] protected Transform child;
    [SerializeField] protected BoxCollider boxCollider;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadChild();
        this.LoadBoxCollider();
    }

    protected virtual void LoadChild()
    {
        if (this.child != null) return;
        this.child = transform.Find("dimian");
        Debug.Log(transform.name + "LoadChild",gameObject);
    }

    protected virtual void LoadBoxCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        Debug.Log(transform.name + "LoadBoxCollider",gameObject);
    }


    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.child.gameObject.SetActive(false);
            boxCollider.enabled = false;
        }   
    }
}
