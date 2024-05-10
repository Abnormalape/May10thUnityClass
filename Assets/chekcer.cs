using UnityEngine;

namespace Game
{
    public class Checker : MonoBehaviour
    {
        // �� ��ü�� ������ �±� ��.

        bool gameClear= false;
        // ���ӿ� ��ġ�� ���� ����.
        [SerializeField]
        private int targetCount = 0;
        [SerializeField]
        private float gameOverTime = 10f;

        [SerializeField]
        private float remainTime = 0f;
        // �÷��̾ �о ���� ����.
        [SerializeField]
        private int pushCount = 0;
        private void Awake()
        {
            targetCount = GameObject.FindGameObjectsWithTag("box").Length;
            remainTime = gameOverTime;
        }

        private void Update()
        {
            if (gameClear)
            {
                return;
            }
            remainTime = remainTime - Time.deltaTime;

            // Ÿ�� ���� Ȯ��.
            if (remainTime < 0f)
            {
                Debug.Log("Ÿ�� ����!");
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            // �±� Ȯ�� (������).
            if (other.CompareTag("box"))
            {
                ++pushCount;

                if (pushCount == targetCount)
                {
                    Debug.Log("���� Ŭ����!");
                }
            }

            Destroy(other.gameObject);
        }
    }
}