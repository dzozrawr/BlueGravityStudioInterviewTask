using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopItem : MonoBehaviour
{
    public GameObject itemPrefab = null;

    private Button button = null;

    private GameController gameController = null;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        gameController = GameController.Instance;
    }
    private void OnClick()
    {
        gameController.player.AddClothing(itemPrefab);
    }
}
