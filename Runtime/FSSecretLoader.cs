using UnityEngine;

namespace GM.FirebaseTool
{
    public class FSSecretLoader : MonoBehaviour
    {
        public FSSecret secret { get; private set; }

        // Singleton
        public static FSSecretLoader Instance { get; private set; }

        void Awake()
        {
            LoadFSSecret();

            // Singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // TODO Make it harder to access
        // TODO Use Newtonsoft Json
        void LoadFSSecret()
        {
            TextAsset jsonTextFile = Resources.Load<TextAsset>("Secret/FSSecret");
            string jsonText = jsonTextFile.text;
            secret = JsonUtility.FromJson<FSSecret>(jsonText);
        }
    }

}
