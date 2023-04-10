using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallMovement>())
        {
            print("Collision with slow collision");
            other.gameObject.GetComponent<BallMovement>().MoveSpeed = 5f;
            print($"Speed: {other.gameObject.GetComponent<BallMovement>().MoveSpeed}");
        }
    }
}
