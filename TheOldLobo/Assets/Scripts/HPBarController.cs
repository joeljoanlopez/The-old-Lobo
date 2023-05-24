using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    [SerializeField] private GameObject _Player;

    private Image _HPBar;
    private HealthManager _HealthManager;

    // Start is called before the first frame update
    private void Start()
    {
        _HPBar = GetComponent<Image>();
        _HealthManager = _Player.GetComponent<HealthManager>();
    }

    public void Update()
    {
        _HPBar.fillAmount = _HealthManager.GetHP() / 100f;
    }
}