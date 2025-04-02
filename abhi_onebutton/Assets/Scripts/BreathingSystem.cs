using UnityEngine;
using UnityEngine.UI;

public class BreathingSystem : MonoBehaviour
{
    public Image stressBarFill; // Assign in Inspector (fill image)
    public float holdDuration = 5f; // Time until max stress
    private float stressTimer = 0f;
    private bool isHoldingBreath = false;
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isHoldingBreath = true;
            stressTimer += Time.deltaTime;
        }
        else
        {
            isHoldingBreath = false;
            stressTimer -= Time.deltaTime * 2f; // cooldown faster than buildup
        }

        stressTimer = Mathf.Clamp(stressTimer, 0f, holdDuration);

        // Update UI fill
        if (stressBarFill != null)
        {
            stressBarFill.fillAmount = stressTimer / holdDuration;
        }

        // If over limit, trigger game over (or panic later)
        if (stressTimer >= holdDuration)
        {
            Debug.Log("You panicked!");
            isGameOver = true;
            // Call GameManager.GameOver() here if hooked up
        }
    }
}
