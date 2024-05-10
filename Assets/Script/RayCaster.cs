using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Demo
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [SerializeField]
        private float rayLength = 1f;

        //World. 방식 => 물체가 막대기를 들고있다가 막대기에 뭐가 닿으면 판정하는 방식 => 이 코드는 world기준이다
        //Camera. 방식 => 카메라에서 빛을 쏴서 맞으면 뭘 하는 방식

        //Ray는 빛이므로, 기본적으로 비가시적
        //따라서 가시적이게 만드는 방법
        private void OnDrawGizmos() // 게임 개발할때 필요한 이미지를 제공하는 함수
        {
            Gizmos.color = Color.red;
            //Ray그리기
            Gizmos.DrawRay(transform.position,transform.forward * rayLength);
        }
        private void Update()
        {
            //Ray를 방출
            //Ray의 시작지점
            //Ray의 방향
            //Ray의 길이
            //Ray의 부딪힌 물체의 정보를 받기위한 변수 (참조형)
            //레이어 마스크
            // RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayLength))
            {
                Debug.Log($"Ray가 {hit.collider.name}와 충돌함. ");

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(transform.forward * 1f, ForceMode.Impulse);
                }
            }
        }
    }
}
