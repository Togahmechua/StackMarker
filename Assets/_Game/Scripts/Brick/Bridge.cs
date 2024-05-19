using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : TogaMonoBehaviour
{
    [SerializeField] protected GameObject bridge;
    [SerializeField] protected BoxCollider boxCollider;
    // public Transform model;
   
    void Start()
    {
        // transform.rotation = Quaternion.Euler(new Vector3(-90f,0f,0f));
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
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
            GameObject newbrick = Instantiate(bridge, transform.position, transform.rotation);
            boxCollider.enabled = false;
            newbrick.transform.SetParent(transform);
        }
    }
}
