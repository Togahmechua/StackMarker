using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected float onFiring;
    public float OnFiring => onFiring;

    [SerializeField] protected Camera mainCamera;
    [SerializeField] private LayerMask layerMask;


    protected virtual void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("There are 2 InputManager exist");
        InputManager.instance = this;
    }

    void Update()
    {
        this.GetMouseDown();
    }

    void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit,float.MaxValue,layerMask))
        {
            transform.position = raycastHit.point;
        }
        
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxisRaw("Fire1");
    }
}
