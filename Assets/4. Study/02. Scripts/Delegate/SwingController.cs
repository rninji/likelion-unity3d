using System;
using System.Collections;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    private Animator anim;
    private bool isSwing;

    public Action onStartSwing;
    public Action onEndSwing;
    void Start()
    {
        anim = GetComponent<Animator>();

        onStartSwing += SwingStart;
        onEndSwing += SwingEnd;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSwing)
                StartCoroutine(SwingRoutine(onStartSwing, onEndSwing));
        }
    }

    IEnumerator SwingRoutine(Action action1, Action action2)
    {
        isSwing = true;
        anim.SetTrigger("Swing");
        action1?.Invoke();
        
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        
        isSwing = false;
        action2?.Invoke();
    }

    void SwingStart()
    {
        Debug.Log("스윙 시작");
    }

    void SwingEnd()
    {
        Debug.Log("스윙 종료");
    }
}
