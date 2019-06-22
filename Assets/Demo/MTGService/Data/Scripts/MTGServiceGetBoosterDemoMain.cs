using System;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MTGServiceGetBoosterDemoMain : MonoBehaviour
{
    [SerializeField] private RawImage[] _images;

    void Start()
    {
        GetBooster(Sets.XLN);
    }

    private async void GetBooster(Sets set)
    {
        Debug.Log("Start get booster");
        var result = await Services.MTGService.GetBooster(set);

        for (var i = 0; i < result.cards.Length; i++)
        {
            Debug.Log(result.cards[i].imageUrl);
            
            _images[i].texture = await GetWebTexture2D(result.cards[i].imageUrl);
        }

        Debug.Log("End get booster");
    }

    private Task<Texture2D> GetWebTexture2D(string uri)
    {
        var tcs = new TaskCompletionSource<Texture2D>();

        var request = UnityWebRequestTexture.GetTexture(uri);

        var asyncReq = request.SendWebRequest();

        asyncReq.completed += (e) =>
        {
            if (string.IsNullOrEmpty(request.error))
            {
                var tex = new Texture2D(10, 10);
                tex.LoadImage(request.downloadHandler.data);
                tcs.SetResult(tex);
            }
            else
            {
                tcs.SetException(new Exception(request.error));
            }
        };

        return tcs.Task;
    }
}
