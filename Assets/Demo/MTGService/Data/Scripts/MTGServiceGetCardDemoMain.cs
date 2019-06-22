using UnityEngine;
using UnityEngine.UI;

public class MTGServiceGetCardDemoMain : MonoBehaviour
{
    [SerializeField] private int id = 3000;
    [SerializeField] private Text _text;

    void Start()
    {
        GetCard(id);
    }

    private async void GetCard(int id)
    {
        var result = await Services.MTGService.GetCard(id);
        
        _text.text = result.card.name + "\r\n" + result.card.type;
    }
}
