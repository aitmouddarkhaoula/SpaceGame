using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public static TouchPad instance;
    public RectTransform analogBackground;
    public RectTransform analogCenter;

    private PointerEventData _lastPointerData;

    public System.Action onTouchDown;
    public System.Action onTouchUp;



    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        _activeAnalog = false;
    }

    public void Reset()
    {
        analogBackground.localPosition = analogCenter.localPosition = Vector3.zero;
    }

    public void StopDrag()
    {
        if (_lastPointerData != null)
            _lastPointerData.pointerDrag = null;
        Reset();
        gameObject.SetActive(false);
    }

    public void StartDrag()
    {
        if (_lastPointerData != null)
            _lastPointerData.pointerDrag = null;
        Reset();
        gameObject.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onTouchDown?.Invoke();
        _activeAnalog = true;
        SetAnalogPosition(eventData, true);
    }
    public void OnDrag(PointerEventData eventData)
    {
        _lastPointerData = eventData;
        SetAnalogPosition(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        onTouchUp?.Invoke();
        _activeAnalog = false;
        SetAnalogPosition(eventData, true);
    }
    private void SetAnalogPosition(PointerEventData eventData, bool defaultPosition = false)
    {
        if (defaultPosition)
        {
            analogBackground.position = eventData.position;
            analogCenter.position = eventData.position;
            return;
        }

        analogCenter.position = eventData.position;
        Vector3 distance = analogBackground.position - analogCenter.position;
        if (distance.magnitude > _analogRadius)
        {
            analogBackground.position = analogCenter.position + distance.normalized * _analogRadius;
        }
    }

    public Vector2 velocityDirection
    {
        get
        {
            Vector2 tempVect = (analogCenter.position - analogBackground.position) / _analogRadius;
            return new Vector2(tempVect.x, tempVect.y);
        }
    }

    private float _analogRadius => analogBackground.rect.width / 2;
    private bool _activeAnalog
    {
        set
        {
            analogBackground.gameObject.SetActive(value);
            analogCenter.gameObject.SetActive(value);
        }
    }
}
