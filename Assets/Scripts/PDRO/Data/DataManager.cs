using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PDRO.Utils.Singleton;
using PDRO.Data;
using System.IO;
using UnityEngine.Networking;
using Unity.VisualScripting;


public class DataManager : MonoSingleton<DataManager>
{

    private int LastLoadID = -1;
    public AudioClip CurrentClip;
    public string musicName = "";
    public string composerName = "";
    public float ClipLength
    {
        get
        {
            return CurrentClip == null ? -1 : CurrentClip.length;
        }
    }
    public IEnumerator SetAudioClipByPath(string path)
    {
        print(path);
        if (!File.Exists(path)) yield break;
        WWW _www = new WWW("file://" + path);
        string filename = path.Split('.')[^1];
        AudioType type = AudioType.UNKNOWN;
        switch (filename.ToUpper())
        {
            //case "MP3": type=AudioType.; break;
            case "WAV": type = AudioType.WAV; break;
            case "OGG": type = AudioType.OGGVORBIS; break;
            default:
                break;
        }
        yield return _www;
        if (_www.error == null)
        {
            CurrentClip = _www.GetAudioClip(true, true, type);
        }
        else { Debug.Log(_www.error); }
    }
    public MusicData GetNowMusicData()
    {
        return new MusicData(
            EditManager.Instance.BPM,
             musicName, //目前想不到怎么改
             composerName
        );
    }
}
