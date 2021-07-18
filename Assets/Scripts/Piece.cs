using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Piece : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [SerializeField] private GameSettings.Shapes _shape;
    [SerializeField] private GameSettings.Colors _color;
    private Vector3 startingPosition;
    private bool following = false;

    public bool Following
    {
        get => following;
        set => following = value;
    }
    
    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (following)
        {

            Vector3 newPosition = Input.mousePosition;
            newPosition.z = 100;
            newPosition = Camera.main.ScreenToWorldPoint(newPosition);
            
            if (Vector3.Distance(transform.position, newPosition) > 0.01f)
            {
                transform.position += (newPosition - transform.position) * GameSettings.DRAG_TOWARDS_SPEED * Time.deltaTime;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!following)
            following = true;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        if (following)
        {
            following = false;
            StartCoroutine(GoBackToStart());
        }
    }

    private IEnumerator GoBackToStart()
    {
        float t = 0;
        Vector3 startPos = transform.position;

        while (t < GameSettings.GO_BACK_TIME)
        {
            transform.position = Vector3.Lerp(startPos, startingPosition, t/GameSettings.GO_BACK_TIME);
            t += Time.deltaTime;
            yield return null;
        }

        transform.position = startingPosition;
    }

    private void OnDestroy()
    {
        StopCoroutine(GoBackToStart());
    }
}
