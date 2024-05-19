using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;



public class PlayerMovement : PlayerCtrl
{
    [SerializeField] protected List<GameObject> prefabs;
    [SerializeField] protected GameObject brick;
    [SerializeField] protected GameObject test;
    [SerializeField] private int count = 0;
    [SerializeField] protected float speed;
    [SerializeField] protected float raycastDistance;
    [SerializeField] protected LayerMask obstacleLayer;

    [SerializeField] private bool isMoving = false;
    [SerializeField] private bool isWinning = false;
    [SerializeField] private GameObject movementObject; // Tham chiếu đến game object Movement
    private Vector3 moveDirection; // Hướng di chuyển của nhân vật

    [Header("Swipe")]
    public Swipe swipeControls;
    private Vector3 desiredPosition;
    private Vector2 startTouch, swipeDelta;

    [Header("UI")]
    [SerializeField] protected TextMeshProUGUI pointText;
    private int plus;



    void Start()
    {
        // childOfModel.position += new Vector3(0f, 0.15f, 0f);
        // movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
    }

    void Update()
    {
        this.CheckInput();
        this.Move();
        this.SwipeCtrl();
        pointText.text = "" + plus;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected void SwipeCtrl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Lưu vị trí bắt đầu khi click chuột
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Tính toán hướng di chuyển khi thả chuột
            swipeDelta = (Vector2)Input.mousePosition - startTouch;

            // Xác định hướng di chuyển và thay đổi quay của nhân vật
            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
            {
                if (swipeDelta.x < 0 && isMoving == false)
                    movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
                else if (swipeDelta.x > 0 && isMoving == false)
                    movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
            }
            else
            {
                if (swipeDelta.y < 0 && isMoving == false)
                    movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
                else if (swipeDelta.y > 0 && isMoving == false)
                    movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }
        }
    }



    protected void CheckInput()
    {
        // this.Rotate();
        Vector3 direction = movementObject.transform.forward;

        // Kiểm tra va chạm trước mặt
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, raycastDistance, obstacleLayer))
        {
            // Nếu raycast chạm vào đối tượng có tag "Yellow", tiếp tục di chuyển
            if (hit.collider.CompareTag("Yellow"))
            {

                isMoving = true;
                moveDirection = direction;

            }
            // Nếu raycast chạm vào đối tượng có tag "White", dừng di chuyển
            else if (hit.collider.CompareTag("White"))
            {
                isMoving = false;
            }
        }
    }

    protected virtual void Move()
    {
        // Nếu đang di chuyển, di chuyển nhân vật cha theo hướng của movementObject
        if (isMoving && !isWinning)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
        else if (isWinning)
        {
            transform.Translate(moveDirection * speed * 0 * Time.deltaTime);
        }
    }

    protected virtual void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.D) && isMoving == false)
        {
            movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        }
        else if (Input.GetKeyDown(KeyCode.W) && isMoving == false)
        {
            movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
        else if (Input.GetKeyDown(KeyCode.S) && isMoving == false)
        {
            movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else if (Input.GetKeyDown(KeyCode.A) && isMoving == false)
        {
            movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
        }
    }

    protected virtual void WinPos()
    {
        for (int i = prefabs.Count - 1; i >= 0; i--)
        {
            GameObject prefab = prefabs[i];
            Destroy(prefab);
            prefabs.RemoveAt(i);
        }
        isWinning = true;
        model.position = new Vector3(transform.position.x, 8.53f, transform.position.z);
        winPos.openChest.gameObject.SetActive(true);
        winPos.closeChest.gameObject.SetActive(false);
        winPos.playerPrefab.gameObject.SetActive(true);
        model.gameObject.SetActive(false);
    }

    protected virtual void Check()
    {
        Invoke(nameof(Inv), 0.05f);
    }



    protected virtual void Inv()
    {
        model.position += new Vector3(0f, 0.3f, 0f);
        GameObject newBrick = Instantiate(brick, transform.position, brick.transform.rotation);

        newBrick.transform.position += new Vector3(0f, 0.3f, 0f);
        newBrick.transform.SetParent(model);
        this.prefabs.Add(newBrick);
    }

    protected virtual void Delete()
    {
        childOfModel.position -= new Vector3(0f, 0.3f, 0f);
        child2OfModel.position -= new Vector3(0f, 0.3f, 0f);
        if (prefabs.Count > 0)
        {
            GameObject firstPrefab = prefabs[0];
            Destroy(firstPrefab); // Hủy game object khỏi hierarchy
            prefabs.RemoveAt(0);  // Xóa game object khỏi danh sách
        }
    }

    public void RotatePlayer()
    {
        movementObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
    }

    public void ResetPlayerPos()
    {
        childOfModel.localPosition = Vector3.zero;
        child2OfModel.localPosition = Vector3.zero;
        model.localPosition = Vector3.zero;
    }

    public void Loadwp()
    {
        LoadWinPos();
        model.gameObject.SetActive(true);
        isWinning = false;
        plus = 0;
        winPos = GameObject.FindObjectOfType<WinPos>();
    }

    protected virtual void Wait()
    {
        if (LevelManager.Ins.CurLevel != 4)
        {
            UIManager.Instance.Win(LevelManager.Ins.curMap.gameObject);
        }
        else
        {
            UIManager.Instance.Win2();
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spawn"))
        {
            this.Check();
            plus += 1;
        }
        else if (other.gameObject.CompareTag("Bridge"))
        {
            this.Delete();
        }
        else if (other.gameObject.CompareTag("Win"))
        {
            count++;
            this.WinPos();
            Invoke(nameof(Wait), 1.5f);
            LevelManager.Ins.CurLevel++;
            PlayerPrefs.SetInt("CurrentLevel" , LevelManager.Ins.CurLevel);
            this.RotatePlayer();
            // Invoke(nameof(Loadwp),1.5f);
        }
    }




    // protected void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawRay(transform.position, movementObject.transform.forward * raycastDistance);
    // }
}
