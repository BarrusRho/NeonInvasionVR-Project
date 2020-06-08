using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField]
    private Transform ship;

    private void LateUpdate()
    {
        Vector3 newPosition = ship.position;

        newPosition.y = transform.position.y;

        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, ship.eulerAngles.y, 0f);
    }
}
