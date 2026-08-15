using UnityEngine;
using TMPro;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _text;

    public void changeHealth(string health)
    {
        _text.text = health;
    }
}
