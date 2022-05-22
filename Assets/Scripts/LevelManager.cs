using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Button[] levelButtons;

    [SerializeField]    
    private Sprite lockedButtonSprite;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i+1 > levelReached)
            {
                levelButtons[i].enabled = false;
                levelButtons[i].image.sprite = lockedButtonSprite;
            }
        }
    }
}
