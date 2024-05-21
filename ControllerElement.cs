using UnityEngine.EventSystems;
using UnityEngine;

public class ControllerElement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public GameObject coint;
    public string nameTag;
    public Vector3 m_Position;
    public Canvas canvas;

    private RaycastHit2D[] hits = new RaycastHit2D[4];
    private CanvasGroup m_CanvasGroup;
    private RectTransform m_RectTransform;
    private bool isDestroy = false;

    private int ScrolInt = 0;
    private void Start()
    {
        m_Position = this.transform.position;
        m_CanvasGroup = this.gameObject.GetComponent<CanvasGroup>();
        m_RectTransform = this.gameObject.GetComponent<RectTransform>();
        coint = GameManager.Instance.Coint;
        canvas = GameManager.Instance.Canvas;
    }
    private void Update()
    {
        Debug.DrawRay(m_RectTransform.position, Vector2.right * 60);
    }
    public void OnDrag(PointerEventData eventData)
    {
        var pos = Input.mousePosition;
        this.GetComponent<RectTransform>().position = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_CanvasGroup.alpha = 1f;
        m_CanvasGroup.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_CanvasGroup.alpha = 0.5f;
        m_CanvasGroup.blocksRaycasts = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().position = eventData.pointerDrag.GetComponent<ControllerElement>().m_Position;
        GameManager.Instance.InstanceItem();
    }
    public void checkItem()
    {
        hits[0] = Physics2D.Raycast(m_RectTransform.position, Vector2.right, 60);
        hits[1] = Physics2D.Raycast(m_RectTransform.position, Vector2.left, 60);
        hits[2] = Physics2D.Raycast(m_RectTransform.position, Vector2.up, 60);
        hits[3] = Physics2D.Raycast(m_RectTransform.position, Vector2.down, 60);
        for (int i = 0; i < 4; i++)
        {
            if(hits[i].collider != null && hits[i].collider.CompareTag(nameTag))
            {
                GameManager.Instance.addGame(hits[i].collider.gameObject);
                m_CanvasGroup.alpha = 1f;
                m_CanvasGroup.blocksRaycasts = true;
                isDestroy = true;
                Instantiate(coint, new Vector3((this.transform.position.x + hits[i].transform.position.x) / 2,
                    (this.transform.position.y + hits[i].transform.position.y) / 2, 0f), Quaternion.identity, canvas.transform);
                ScrolInt++;
                hits[i].collider.gameObject.SetActive(false);
            }
        }
        if(isDestroy)
        {
            isDestroy = false;
            GameManager.Instance.addGame(this.gameObject);
            m_CanvasGroup.alpha = 1f;
            m_CanvasGroup.blocksRaycasts = true;
            GameManager.Instance.scrol.GetComponent<controllerScrool>().addScrool(ScrolInt);
            ScrolInt = 0;
            this.gameObject.SetActive(false);
        }
    }
}
