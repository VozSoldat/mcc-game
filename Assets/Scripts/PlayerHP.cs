using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private Player player;
    private float maxWidth;
    private RectTransform rectRemaining;

    void Awake()
    {
        rectRemaining = transform.Find("Remaining").GetComponent<RectTransform>();
        maxWidth = rectRemaining.sizeDelta.x;
    }

    void Start()
    {
        if (player == null)
            Debug.LogError("Player reference is missing in PlayerHP!");

        player.OnHealthChange.AddListener(ChangeHP);
    }

    void ChangeHP(int hp)
    {
        rectRemaining.sizeDelta = new Vector2(
            maxWidth * ((float)hp / player.maxHealth),
            rectRemaining.sizeDelta.y
        );
    }
}

