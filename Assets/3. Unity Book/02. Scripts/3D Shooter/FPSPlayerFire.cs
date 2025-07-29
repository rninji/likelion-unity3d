using System.Collections;
using TMPro;
using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    enum WeaponMode { Normal, Sniper }

    private WeaponMode wMode;
    
    public GameObject firePosition;
    public GameObject bombFactory;
    public float throwPower = 15f;
    public int weaponPower = 5;

    public GameObject bulletEffect;
    public ParticleSystem ps;

    private Animator anim;

    private bool ZoomMode = false;
    public TextMeshProUGUI wModeText;

    public GameObject[] eff_Flash;

    public GameObject weapon01;
    public GameObject weapon02;

    public GameObject crosshair01;
    public GameObject crosshair02;
    
    public GameObject weapon01_R;
    public GameObject weapon02_R;

    public GameObject crosshair02_zoom;

    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();

        wMode = WeaponMode.Normal;
    }
    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run) 
            return;
        #region 마우스 좌클릭 -> 총 발사
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();
            
            anim.SetTrigger("Attack");

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
            
            // 이펙트 실행
            StartCoroutine(ShootEffectOn(0.05f));
        }
        #endregion

        #region 마우스 우클릭 -> 수류탄 투척/스나이퍼 모드
        
        if (Input.GetMouseButtonDown(1))
        {
            switch (wMode)
            {
                case WeaponMode.Normal:
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
                    break;
                case WeaponMode.Sniper:
                    ZoomMode = !ZoomMode;
                    
                    Camera.main.fieldOfView = ZoomMode ? 15f : 60f;
                    
                    crosshair02_zoom.SetActive(ZoomMode);
                    crosshair02.SetActive(!ZoomMode);

                    
                    break;
            }
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;
            wModeText.text = "Normal Mode";
            
            weapon01.SetActive(true);
            weapon02.SetActive(false);
            crosshair01.SetActive(true);
            crosshair02.SetActive(false);
            weapon01_R.SetActive(true);
            weapon02_R.SetActive(false);
            crosshair02_zoom.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.Sniper;
            wModeText.text = "Sniper Mode";
            
            weapon01.SetActive(false);
            weapon02.SetActive(true);
            crosshair01.SetActive(false);
            crosshair02.SetActive(true);
            weapon01_R.SetActive(false);
            weapon02_R.SetActive(true);
        }
    }

    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, eff_Flash.Length);
        eff_Flash[num].SetActive(true);
        yield return new WaitForSeconds(duration);
        eff_Flash[num].SetActive(false);
    }
}
