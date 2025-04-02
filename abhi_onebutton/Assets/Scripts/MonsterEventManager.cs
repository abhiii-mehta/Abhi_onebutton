using UnityEngine;

public class MonsterEventManager : MonoBehaviour
{
    public float minTimeBetweenEvents = 5f;
    public float maxTimeBetweenEvents = 12f;
    public float dangerDuration = 3f;

    private float eventTimer = 0f;
    private float dangerTimer = 0f;
    public bool monsterIsNear = false;

    public delegate void MonsterEvent(bool isNear);
    public static event MonsterEvent OnMonsterStateChanged;

    private void Start()
    {
        ResetEventTimer();
    }

    private void Update()
    {
        if (!monsterIsNear)
        {
            eventTimer -= Time.deltaTime;
            if (eventTimer <= 0f)
            {
                TriggerDanger();
            }
        }
        else
        {
            dangerTimer -= Time.deltaTime;
            if (dangerTimer <= 0f)
            {
                EndDanger();
            }
        }
    }

    void TriggerDanger()
    {
        monsterIsNear = true;
        dangerTimer = dangerDuration;
        OnMonsterStateChanged?.Invoke(true);
        Debug.Log("Monster is NEAR");
    }

    void EndDanger()
    {
        monsterIsNear = false;
        ResetEventTimer();
        OnMonsterStateChanged?.Invoke(false);
        Debug.Log("Monster left");
    }

    void ResetEventTimer()
    {
        eventTimer = Random.Range(minTimeBetweenEvents, maxTimeBetweenEvents);
    }
}
