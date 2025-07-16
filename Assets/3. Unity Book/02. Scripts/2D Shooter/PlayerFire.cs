using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    void Start()
    {
        // bulletFactory = Resources.Load<GameObject>("Bullet");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
            
            // bullet.transform.SetPositionAndRotation((위치, 회전)); // 위치와 회전을 한번에 적용하는 기능
        }
    }
}
