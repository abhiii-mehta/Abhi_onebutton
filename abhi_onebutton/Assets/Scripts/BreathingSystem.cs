using UnityEngine;
using UnityEngine.UI;

public class BreathingSystem : MonoBehaviour
{
    [Header("Breathing Settings")]
    public float maxStress = 10f;
    private float currentStress = 0f;

    [Header("Breathing Key")]
    public KeyCode holdBreathKey = KeyCode.LeftShift;

    [Header("Stress Bar")]
    public Image stressFillImage;

    private bool isHoldingBreath = false;
    private bool monsterNearby = false;

    private void OnEnable()
    {
        MonsterEventManager.OnMonsterStateChanged += SetMonsterState;
    }

    private void OnDisable()
    {
        MonsterEventManager.OnMonsterStateChanged -= SetMonsterState;
    }

    private void SetMonsterState(bool isNear)
    {
        monsterNearby = isNear;
    }

    private void Update()
    {
        isHoldingBreath = Input.GetKey(holdBreathKey);

        if (isHoldingBreath)
        {
            currentStress += Time.deltaTime;
        }
        else
        {
            currentStress -= Time.deltaTime * 1.5f;
        }

        currentStress = Mathf.Clamp(currentStress, 0f, maxStress);

        if (stressFillImage != null)
        {
            stressFillImage.fillAmount = currentStress / maxStress;
        }

        if (currentStress >= maxStress)
        {
            Debug.Log("Player passed out!");
        }

        if (monsterNearby && !isHoldingBreath)
        {
            Debug.Log(" You breathed while the monster was near!");
        }

    }
}
