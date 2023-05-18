using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    private Image _HPBar;

    // Start is called before the first frame update
    private void Start()
    {
        _HPBar = GetComponent<Image>();
    }

    public void UpdateBar(float _newAmount)
    {
        _HPBar.fillAmount = _newAmount / 100f;
    }
}