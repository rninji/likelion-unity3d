using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;
    public float throwPower = 15f;
    public int weaponPower = 5;

    public GameObject bulletEffect;
    public ParticleSystem ps;

    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run) 
            return;
        
        // 총 발사
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                // 몬스터 공격
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                // 몬스터 아닌 경우
                else
                {
                    bulletEffect.transform.position = hitInfo.point; // 충돌한 위치 좌표
                    bulletEffect.transform.forward = hitInfo.normal; // 이펙트 방향을 부딪힌 지점의 법선 벡터와 일치시킴
                    
                    ps.Play();
                }
            }
        }
        
        // 수류탄 투척
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }
}
