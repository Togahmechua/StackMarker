using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float speed;

    private Vector3 offset;

    void Start()
    {
        // Tính offset giữa vị trí của camera và vị trí của nhân vật
        offset = transform.position - player.position;
    }

    void Update()
    {
        // Tính toán vị trí mới của camera dựa trên vị trí của nhân vật và offset
        Vector3 targetPosition = player.position + offset;

        // Di chuyển camera đến vị trí mới
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
