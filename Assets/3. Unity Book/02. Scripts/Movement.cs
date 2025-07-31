using UnityEngine;

public class Movement : MonoBehaviour
{

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h, 0, v) * Time.deltaTime * 5f;
    }
}
