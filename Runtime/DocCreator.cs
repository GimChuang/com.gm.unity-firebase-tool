using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace GM.FirebaseTool
{
    public class DocCreator : MonoBehaviour
    {
        bool isRoutineRunning;

        void Start()
        {

        }

        void Update()
        {

        }

        public void CreateDoc(string _url, object _obj)
        {
            StartCoroutine(E_CreateDoc(_url, _obj));
        }

        IEnumerator E_CreateDoc(string _url, object _obj)
        {
            if (isRoutineRunning)
            {
                Debug.LogWarning("Rountine is still running.");
                yield break;
            }

            isRoutineRunning = true;

            string json = FSJsonParser.ObjToJson(_obj);
            Debug.Log(json);

            using (UnityWebRequest req = new UnityWebRequest(_url, "POST"))
            {
                req.SetRequestHeader("Content-Type", "application/json");
                byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
                req.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
                req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

                yield return req.SendWebRequest();

                if (req.isNetworkError || req.isHttpError)
                {
                    Debug.LogError($"Error occurs when creating doc: {req.error}");
                    OnReqFinished(false, req.downloadHandler.text);
                }
                else
                {
                    Debug.Log($"Create doc successfully: {req.downloadHandler.text}");
                    OnReqFinished(true, req.downloadHandler.text);
                }

                //Debug.Log($"DownloadHandler text: {req.downloadHandler.text}");
            }
            
            isRoutineRunning = false;
        }

        // What to do when the request finished
        protected virtual void OnReqFinished(bool _success, string _text)
        {

        }
    }
}
