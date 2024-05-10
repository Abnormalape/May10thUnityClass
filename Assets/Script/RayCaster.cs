using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Demo
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [SerializeField]
        private float rayLength = 1f;

        //World. ��� => ��ü�� ����⸦ ����ִٰ� ����⿡ ���� ������ �����ϴ� ��� => �� �ڵ�� world�����̴�
        //Camera. ��� => ī�޶󿡼� ���� ���� ������ �� �ϴ� ���

        //Ray�� ���̹Ƿ�, �⺻������ �񰡽���
        //���� �������̰� ����� ���
        private void OnDrawGizmos() // ���� �����Ҷ� �ʿ��� �̹����� �����ϴ� �Լ�
        {
            Gizmos.color = Color.red;
            //Ray�׸���
            Gizmos.DrawRay(transform.position,transform.forward * rayLength);
        }
        private void Update()
        {
            //Ray�� ����
            //Ray�� ��������
            //Ray�� ����
            //Ray�� ����
            //Ray�� �ε��� ��ü�� ������ �ޱ����� ���� (������)
            //���̾� ����ũ
            // RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayLength))
            {
                Debug.Log($"Ray�� {hit.collider.name}�� �浹��. ");

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(transform.forward * 1f, ForceMode.Impulse);
                }
            }
        }
    }
}
