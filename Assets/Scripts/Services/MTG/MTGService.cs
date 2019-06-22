using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class MTGService
{
    public async Task<MTGData> GetCard(int id)
    {
        var result = await GetCardInfo(id);
        return result;
    }

    public async Task<MTGData> GetBooster(Sets set)
    {
        var result = await GetBoosterInfo(set);
        return result;
    }

    private Task<MTGData> GetCardInfo(int id)
    {
        TaskCompletionSource<MTGData> tcs = new TaskCompletionSource<MTGData>();

        var url = MTGURLs.CARD_REQUEST_URL + id;
        var request = UnityWebRequest.Get(url);

        var asyncReq = request.SendWebRequest();

        asyncReq.completed += (e) =>
        {
            if (string.IsNullOrEmpty(request.error))
            {
                tcs.SetResult(JsonUtility.FromJson<MTGData>(request.downloadHandler.text));
            }
            else
            {
                tcs.SetException(new Exception(request.error));
            }
        };

        return tcs.Task;
    }

    private Task<MTGData> GetBoosterInfo(Sets set)
    {
        var tcs = new TaskCompletionSource<MTGData>();

        var url = string.Format(MTGURLs.BOOSTER_REQUEST_URL, set.ToString());

        var request = UnityWebRequest.Get(url);

        var asyncReq = request.SendWebRequest();

        asyncReq.completed += (e) =>
        {
            if (string.IsNullOrEmpty(request.error))
            {
                tcs.SetResult(JsonUtility.FromJson<MTGData>(request.downloadHandler.text));
            }
            else
            {
                tcs.SetException(new Exception(request.error));
            }
        };

        return tcs.Task;
    }
}
