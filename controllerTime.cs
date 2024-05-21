using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class controllerTime : MonoBehaviour
{
    public Text txtTime;
    public float Time;

    public GameObject GameOver;
    public Text txtGameOver;
    private void Start()
    {
        StartCoroutine(WaitTime());
        Time = GameManager.Instance.time;
    }
    private void UpdateTxtUI() => txtTime.text = $"{(int)Time / 60} : " + checkStringTime();
    private string checkStringTime()
    {
        string time = ((int)Time % 60).ToString();
        if (time.Length == 1) return "0" + time;
        else return time;
    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1f);
        Time--;
        UpdateTxtUI();
        checkGameOver();
        StartCoroutine(WaitTime());
    }
    private void checkGameOver()
    {
        if(Time == 0)
        {
            GameOver.SetActive(true);
            txtGameOver.text = "Game Over";
            StopCoroutine(WaitTime());
        }
    }
}
