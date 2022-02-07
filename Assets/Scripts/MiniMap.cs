using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject Player;

    private void LateUpdate()
    {
        Vector3 pos = Player.transform.position;
        pos.y = transform.position.y;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(90f, Player.transform.eulerAngles.y, 0);
    }
}
