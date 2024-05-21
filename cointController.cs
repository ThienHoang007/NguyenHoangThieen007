using UnityEngine;
using UnityEngine.UI;

public class cointController : MonoBehaviour
{
    public Text txtCoint;

    private void addCoint()
    {
        GameManager.Instance.updateCoint();
    }
    private void endAnimation() => Destroy(this.gameObject);
}
