using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HidingSpotManager : MonoBehaviour
{
    public CanvasGroup[] hidingSpotGroups; 
    private int currentIndex = 0;
    public float fadeDuration = 0.5f;

    private void Start()
    {
        for (int i = 0; i < hidingSpotGroups.Length; i++)
        {
            hidingSpotGroups[i].alpha = (i == currentIndex) ? 1 : 0;
            hidingSpotGroups[i].interactable = (i == currentIndex);
            hidingSpotGroups[i].blocksRaycasts = (i == currentIndex);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentIndex > 0)
            {
                int nextIndex = currentIndex - 1;
                StartCoroutine(FadeTransition(currentIndex, nextIndex));
                currentIndex = nextIndex;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentIndex < hidingSpotGroups.Length - 1)
            {
                int nextIndex = currentIndex + 1;
                StartCoroutine(FadeTransition(currentIndex, nextIndex));
                currentIndex = nextIndex;
            }
        }
    }

    private IEnumerator FadeTransition(int fromIndex, int toIndex)
    {
        float timer = 0f;

        CanvasGroup from = hidingSpotGroups[fromIndex];
        CanvasGroup to = hidingSpotGroups[toIndex];

        to.gameObject.SetActive(true);

        while (timer < fadeDuration)
        {
            float t = timer / fadeDuration;
            from.alpha = Mathf.Lerp(1, 0, t);
            to.alpha = Mathf.Lerp(0, 1, t);
            timer += Time.deltaTime;
            yield return null;
        }

        from.alpha = 0;
        from.interactable = false;
        from.blocksRaycasts = false;

        to.alpha = 1;
        to.interactable = true;
        to.blocksRaycasts = true;

        from.gameObject.SetActive(false);
    }
}
