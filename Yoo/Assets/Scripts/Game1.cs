using UnityEngine;
using UnityEngine.UI;

public class Game1 : MonoBehaviour {
    public Image img1;
    public Image img2;
    private void Awake() {
        OnInit();
    }
    private void OnInit() {
        img1.sprite = YooAssetTool.LoadAsset<Sprite>("img1");
        img2.sprite = YooAssetTool.LoadAsset<Sprite>("img2");
    }
}
