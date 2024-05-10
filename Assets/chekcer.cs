using UnityEngine;

namespace Game
{
    public class Checker : MonoBehaviour
    {
        // 벽 물체에 설정할 태그 값.

        bool gameClear= false;
        // 게임에 배치된 벽의 개수.
        [SerializeField]
        private int targetCount = 0;
        [SerializeField]
        private float gameOverTime = 10f;

        [SerializeField]
        private float remainTime = 0f;
        // 플레이어가 밀어낸 벽의 개수.
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

            // 타임 오버 확인.
            if (remainTime < 0f)
            {
                Debug.Log("타임 오버!");
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            // 태그 확인 (벽인지).
            if (other.CompareTag("box"))
            {
                ++pushCount;

                if (pushCount == targetCount)
                {
                    Debug.Log("게임 클리어!");
                }
            }

            Destroy(other.gameObject);
        }
    }
}