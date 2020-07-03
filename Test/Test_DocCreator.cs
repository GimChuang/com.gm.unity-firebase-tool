using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GM.FirebaseTool
{
    public class Test_DocCreator : DocCreator
    {

        void Start()
        {
            Message msg = new Message("Yeah!");

            string url = PathUtils.CombineURL(FSSecretLoader.Instance.secret.baseUrl, "Spots/dStHHiysjV2trrxWDQcM/Messages");

            //Debug.Log(FSJsonParser.ObjToJson(msg));
            Debug.Log(url);
            CreateDoc(url, msg);
        }

        void Update()
        {

        }

        protected override void OnReqFinished(bool _success, string _text)
        {
            if (_success)
            {
                Debug.Log("DocCreator successfully creates doc");
            }
            else
            {
                Debug.Log("DocCreator fails to create doc");
            }
        }
    }

    public class Message
    {
        public string text { get; set; }

        public Message(string _text)
        {
            text = _text;
        }
    }
}
