using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public Vector3 launchDirection;                         //발사 방향

    private void FixedUpdate()
    {
        float moveAmount = 10 * Time.fixedDeltaTime;             //이동 속도 설정
        transform.Translate(launchDirection * moveAmount);      //Translate 로 이동
    }
    private void OnCollisionEnter(Collision collision)          //충돌이 일어났을 경우
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Object")               //Tag 값이 오브젝트 인 경우
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Monster")               //Tag 값이 오브젝트 인 경우
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Monster>().Damaged(1);
        }
    }

    private void OnTriggerEnter(Collider other)                 //트리거 예약 함수
    {
        if (other.CompareTag("Monster"))                        //Tag 를 검사한다.
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Monster>().Damaged(1);
        }
    }
}
