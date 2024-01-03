using UnityEngine;

public class DioramaCard : MonoBehaviour
{
    public Transform startTransform;

    public Transform middleTransform;
    private Vector3 middleRotation;
    private Vector3 middlePosition;

    private Vector3 targetRotation;
    private Vector3 targetPosition;
    public float moveTime = 1f;

    public bool moveStarted = false;
    public bool moveFinished = false;

    private void Start()
    {
        targetPosition = transform.position;
        targetRotation = transform.rotation.eulerAngles;
        
        middlePosition = middleTransform.transform.position;
        middleRotation = middleTransform.transform.rotation.eulerAngles;

        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;
    }

    public void MoveToTarget()
    {
        moveStarted = true;
        MoveToMiddle();
    }

    private void MoveToMiddle()
    {
        // Use LeanTween to smoothly move to the target position and rotation
        LeanTween.move(gameObject, middlePosition, moveTime).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.rotate(gameObject, middleRotation, moveTime).setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(MoveToFinal);

    }


    private void MoveToFinal()
    {
        // Use LeanTween to smoothly move to the target position and rotation
        LeanTween.rotate(gameObject, targetRotation, moveTime).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.move(gameObject, targetPosition, moveTime).setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() => moveFinished = true);
    }
}
