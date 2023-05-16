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

    // Update is called once per frame
    private void Update()
    {
    }

    public void UpdateBar(float _newAmount)
    {
        _HPBar.fillAmount = _newAmount / 100f;
    }
}