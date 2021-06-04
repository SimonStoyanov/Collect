using UnityEngine;
using UnityEngine.UI;

public class ChangeEntitySprite : MonoBehaviour
{
    public Image sprite;

    public void ChangeSprite(Sprite _sprite)
    {
        sprite.sprite = _sprite;
    }
}
