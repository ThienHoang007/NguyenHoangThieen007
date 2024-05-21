using UnityEngine.EventSystems;
using UnityEngine;

public class BackgroundController : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().position = eventData.pointerDrag.GetComponent<ControllerElement>().m_Position;
        GameManager.Instance.InstanceItem();
    }
}
