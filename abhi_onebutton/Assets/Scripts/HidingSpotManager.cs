using UnityEngine;
using UnityEngine.UI;

public class HidingSpotManager : MonoBehaviour
{
    public RawImage[] hidingSpotImages; // Assign in Inspector
    private int currentIndex = 0;       // Tracks which hiding spot you're in

    private void Start()
    {
        ShowOnlyCurrentSpot();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                ShowOnlyCurrentSpot();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentIndex < hidingSpotImages.Length - 1)
            {
                currentIndex++;
                ShowOnlyCurrentSpot();
            }
        }
    }

    private void ShowOnlyCurrentSpot()
    {
        for (int i = 0; i < hidingSpotImages.Length; i++)
        {
            hidingSpotImages[i].gameObject.SetActive(i == currentIndex);
        }
    }
}
