using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    Player player;
    float maxWidth;
    RectTransform rectRemaining;

    void Start()
    {
        this.player = GameObject.Find("Player").GetComponent<Player>();
        this.player.OnHealthChange.AddListener(this.ChangeHP);
        this.rectRemaining = this.transform.Find("Remaining").GetComponent<RectTransform>();
        this.maxWidth = this.rectRemaining.sizeDelta.x;
    }

    void ChangeHP(int hp)
    {
        this.rectRemaining.sizeDelta = new Vector2(
            this.maxWidth * ((float)hp / (float)this.player.maxHealth),
            this.rectRemaining.sizeDelta.y
        );
    }
}
