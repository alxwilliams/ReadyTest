using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Piece : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [SerializeField] private GameSettings.Shapes _shape;
    [SerializeField] private GameSettings.Colors _color;

    private Slot fitSlot;
    private bool inSlot = false;
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
        if (!following && !inSlot)
        {
            following = true;
            transform.SetAsLastSibling();
        }
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        if (fitSlot != null && fitSlot.Color == _color && fitSlot.Shape == _shape)
        {
            //play good audio sound
            inSlot = true;
            following = false;
            StartCoroutine(GoToPlace(fitSlot.transform.position, GameSettings.GO_IN_SLOT_TIME));
        }
        else if (following)
        {
            if (fitSlot != null)
            {
                //play wrong audio sound
            }
                
            following = false;
            StartCoroutine(GoToPlace(startingPosition,GameSettings.GO_BACK_TIME));
        }

    }

    private IEnumerator GoToPlace(Vector3 target, float time)
    {
        float t = 0;
        Vector3 startPos = transform.position;

        while (t < time)
        {
            transform.position = Vector3.Lerp(startPos, target, t/time);
            t += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Slot slot = other.GetComponent<Slot>();
        
        if (slot)
        {
            fitSlot = slot;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Slot slot = other.GetComponent<Slot>();

        if (slot)
        {
            if(slot == fitSlot)
                fitSlot = null;
        }

    }
}
