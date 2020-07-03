using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM.FirebaseTool
{
    public class Test_DocGetter : DocGetter
    {

        void Start()
        {
            string url = PathUtils.CombineURL(FSSecretLoader.Instance.secret.baseUrl, "Spots/dStHHiysjV2trrxWDQcM/Messages");

            GetAllDocsInCollection(url);
        }

        void Update()
        {

        }

        protected override void OnReqFinished(bool _success, string _text)
        {
            if (_success)
            {
                Debug.Log("DocGetter successfully gets doc");
            }
            else
            {
                Debug.Log("DocGetter fails to get doc");
            }
        }
    }
}
