using UnityEngine;

public class SelfScrollBackground : MonoBehaviour
{
    public float ScrollSpeed;

    void Update(){
        transform.position += Vector3.right * ScrollSpeed * Time.deltaTime;
    }
}
