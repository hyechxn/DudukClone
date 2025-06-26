using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    Coroutine moveCoroutine;

    public float speed;

    public void OnTouch()
    {
        Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(Move(new Vector3(touchPos.x, touchPos.y)));
    }

    IEnumerator Move(Vector3 touchPos)
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, touchPos, Time.deltaTime * speed);
            yield return null;

            if (Vector3.Distance(transform.position, touchPos) <= 0.0001f)
            {
                StopCoroutine(moveCoroutine);
            }
        }
    }
}
