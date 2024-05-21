using UnityEngine;
using UnityEngine.EventSystems;

public class controllerElementMatrix : MonoBehaviour, IDropHandler
{
    private RectTransform m_RectTransform;
    private void Start()
    {
        m_RectTransform = this.GetComponent<RectTransform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().position = m_RectTransform.position;
        eventData.pointerDrag.GetComponent<ControllerElement>().checkItem();
        GameManager.Instance.InstanceItem();
    }

}
