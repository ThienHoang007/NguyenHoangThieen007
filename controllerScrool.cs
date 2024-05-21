using UnityEngine;
using UnityEngine.UI;

public class controllerScrool : MonoBehaviour
{
    public Text txt;
    
    public GameObject GameWin;
    public Text txtGameWin;

    private float ScrollGameWin;
    private float ScrollGame = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScrollGameWin = GameManager.Instance.ScrolStart;
        updateUI();
    }
    public void addScrool(int scrol)
    {
        ScrollGame += scrol * scrol;
        gameWin();
        updateUI();
    }
    private void updateUI() => txt.text = $"{ScrollGame}/{ScrollGameWin}";
    private void gameWin()
    {
        if (ScrollGame >= ScrollGameWin)
        {
            GameWin.SetActive(true);
            txtGameWin.text = "You Win";
            Time.timeScale = 0f;
            PlayerPrefs.SetInt("vel", PlayerPrefs.GetInt("vel") + 1);
        }
    }
}
