using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadlockVisualMiniGame : MonoBehaviour
{

    public GameObject upKey, downKey, middleKey;
    public Padlock padlock;

    float originalXPosition;

    public RectTransform keysMovementParent, endPoint;

    

    void Start()
    {
        originalXPosition = keysMovementParent.anchoredPosition.x;

    }

    void FixedUpdate()
    {
        switch (padlock.actualStatus)
        {
            case Padlock.Status.Up:
                upKey.SetActive(true);
                downKey.SetActive(false);
                middleKey.SetActive(false);
                break;
            case Padlock.Status.Push:
                upKey.SetActive(false);
                downKey.SetActive(false);
                middleKey.SetActive(true);
                break;
            case Padlock.Status.Down:
                upKey.SetActive(false);
                downKey.SetActive(true);
                middleKey.SetActive(false);
                break;
            case Padlock.Status.None:
                break;
            default:
                break;
        }




        keysMovementParent.anchoredPosition = new Vector2(Mathf.Lerp(originalXPosition, endPoint.anchoredPosition.x, (1f / padlock.statusSequence.Length) * padlock.statusSequenceIndex), 0f);

       }
}
