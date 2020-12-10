using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace GM.FirebaseTool
{
    public class DocGetter : MonoBehaviour
    {

        bool isRoutineRunning;

        void Start()
        {

        }

        void Update()
        {

        }

        // Get a particular Document
        public void GetDoc(string _documentUrl)
        {
            StartCoroutine(E_GetDocOrAllDocsInCollection(_documentUrl));
        }

        // Get all documents in a collection
        public void GetAllDocsInCollection(string _collectionUrl)
        {
            StartCoroutine(E_GetDocOrAllDocsInCollection(_collectionUrl));
        }

        IEnumerator E_GetDocOrAllDocsInCollection(string _url)
        {
            if (isRoutineRunning)
            {
                Debug.LogWarning("Rountine is still running.");
                yield break;
            }

            isRoutineRunning = true;

            using (UnityWebRequest req = new UnityWebRequest(_url, "GET"))
            {
                req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

                yield return req.SendWebRequest();

                if (req.isNetworkError || req.isHttpError)
                {
                    Debug.LogError($"Error occurs when getting doc: {req.error}");
                    OnReqFinished(false, req.downloadHandler.text);
                }
                else
                {
                    Debug.Log($"Get doc successfully: {req.downloadHandler.text}");
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