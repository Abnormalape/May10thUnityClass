using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField] // 마우스 클릭을 통해 얻은 이동하려는 위치
    private Vector3 targetPosition;

    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                // 위치 옮기기.
                //Vector3 position = hit.point;
                //position.y = transform.position.y;

                //transform.position = position;

                // 이동하려는 위치 저장.
                targetPosition = hit.point;
                targetPosition.y = transform.position.y;
            }
        }

        // 이동.
        // 어렵습니다.

        // 예외처리
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            return;
        }

        // 이동 방향 구하기.
        // 벡터 빼기.
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize();

        // 이번에 이동할 양(크기) 구하기.
        float moveSpeed = 3f;
        Vector3 moveAmount = direction * moveSpeed * Time.deltaTime;

        // 위치 업데이트.
        transform.position = transform.position + moveAmount;

        // 회전

        // 예외처리
        if (direction == Vector3.zero)
        {
            return;
        }

        // 이동하는 방향을 바라보는 회전 값 (단위: 4원수).
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // 현재 회전할 양 구하기.
        float rotationSpeed = 540f;
        Quaternion rotationAmount = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        // 회전 값 더해주기.
        //transform.rotation = transform.rotation * rotationAmount;
        transform.rotation = rotationAmount;
    }// 뭔가 이상한데?
}



//Ray ray = cam.ScreenPointToRay(Input.mousePosition);
//if (Physics.Raycast(ray, out RaycastHit hit, 100f))
//{
//Vector3 position = hit.point;
//position.y = transform.position.y;
//transform.position = position;
//}