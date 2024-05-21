using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private GridLayoutGroup layout;
    [SerializeField] private List<GameObject> items = new List<GameObject>();   
    private List<GameObject> gameObjects = new List<GameObject>();
    private List<Vector3> vector3s = new List<Vector3>();

    [SerializeField] private GameObject coint;
    public GameObject Coint => coint;

    [SerializeField] private Canvas canvas;
    public Canvas Canvas => canvas;

    [SerializeField] private GameObject Scrol;
    public GameObject scrol => Scrol;

    [SerializeField] private Text txtCoint;
    private int CointValue = 0;
    private string stringCoint = "coint";

    public int time;
    public int ScrolStart;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (this.GetInstanceID() != instance.GetInstanceID()) Destroy(this);
        SetTimeAndScrol();
        Time.timeScale = 1f;
    }
    private void Start()
    {
        CointValue = PlayerPrefs.GetInt(stringCoint);
        updateUI();
        StartVectro3s();    }
    private bool ChildCount()
    {
        Collider2D[] box = Physics2D.OverlapBoxAll(this.transform.position, boxCollider.bounds.size, 0, Physics2D.AllLayers);
        print(box.Length);
        if (box.Length == 1) return true;
        else return false;
    }
    public void InstanceItem()
    {
        if(ChildCount())
        {
            for(int i = 0; i < 10; i++)
            {
                InstanceObject(i);
            }
        }
    }
    public void addGame(GameObject g)
    {
        gameObjects.Add(g);
    }
    private GameObject GetGameObjetc()
    {
        var id = Random.Range(0, 5);
        switch(id)
        {
            case 0: return items[0];
            case 1: return items[1];
            case 2: return items[2];
            case 3: return items[3];
            case 4: return items[4];
            default: return null;
        }
    }
    private void StartVectro3s()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            vector3s.Add(this.transform.GetChild(i).position);
        }
    }
    private void InstanceObject(int i)
    {
        GameObject g = GetGameObjetc();
        foreach (GameObject item in gameObjects)
        {
            if (item.CompareTag(g.tag) && !item.gameObject.activeSelf)
            {
                item.SetActive(true);
                item.transform.position = vector3s[i];
                return;
            }
        }
        Instantiate(g, vector3s[i], Quaternion.identity, this.transform);
    }
    public void updateCoint()
    {
        CointValue++;
        updateUI();
        saveCoint();
    }
    private void updateUI()
    {
        txtCoint.text = CointValue.ToString();
    }
    private void saveCoint() => PlayerPrefs.SetInt(stringCoint, CointValue);
    private void SetTimeAndScrol()
    {
        switch(PlayerPrefs.GetInt("value"))
        {
            case 0:
                time = 120;
                ScrolStart = 20;
                break;
            case 1:
                time = 80;
                ScrolStart = 35;
                break;
            case 2:
                time = 60;
                ScrolStart = 45;
                break;
            case 3:
                time = 45;
                ScrolStart = 55;
                break;
            case 4:
                time = 30;
                ScrolStart = 60;
                break;
            case 5:
                time = 20;
                ScrolStart = 100;
                break;
            default: return;
        }
    }
    public void goToHome() => SceneManager.LoadScene("MenuLevels", LoadSceneMode.Single);
    public void repay() => SceneManager.LoadScene("Play", LoadSceneMode.Single);
}
