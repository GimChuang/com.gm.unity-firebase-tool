# Unity Firebase Tool 🔥

Tools for calling Firebase Firestore REST API with UnityWebRequest.


### Upadtes💥 OK so the official Firebase Unity SDK seems to finally support Firestore (beta). You may want to [check it out](https://github.com/firebase/quickstart-unity/issues/381#issuecomment-595845307).
---

I started this project because I need to use [Firestore](https://firebase.google.com/docs/firestore) as my database but the official Firebase Unity SDK only supports [Realtime Database](https://firebase.google.com/docs/database).
This tool currently provides very basic functions to create a [document](https://firebase.google.com/docs/firestore/data-model#documents) and retrieve a specific document or all documents in a [collection](https://firebase.google.com/docs/firestore/data-model#collections). The functions are just calling Firestore REST API with UnityWebRequest internally.


How to Install with Unity's Package Manager
---
In the `dependencies` section of your 'manifest.json', add
```
"com.gm.unity-firebase-tool": "https://github.com/GimChuang/com.gm.unity-firebase-tool.git"
```
(don't forget to add a comma if you need one)


Note
---
You'll need to add a `Resources` folder, a `Resources/Secret` folder, and a `FSSecret.json` file to run the test scenes.
```
Assets
  ├ Resources
  | ├ Secret
  | | ├ FSSecret.json
```
And the `FSSecret.json` should be like
```
{
	"baseUrl": "https://firestore.googleapis.com/v1/projects/<your-firebase-project-id>/databases/(default)/documents"
}
```
