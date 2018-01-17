//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using System.Linq;
//public class UI_Manager : Singleton<UI_Manager> {

//    [SerializeField]
//    private GameObject _UI = null;
//    [SerializeField]
//    private GameObject _DamagePopup = null;
//    [SerializeField]
//    private float _Range = 1.0f;
    
//	// Update is called once per frame
//	public void CreateDamagePopUp (string text, Vector2 position, Color RGB)
//    {
//        GameObject instance;
//        //if (_DamagePopup != null)
//        //{
//            instance = Instantiate(_DamagePopup);
//            Vector2 screenPos = Camera.main.WorldToScreenPoint(new Vector2(position.x + Random.Range(-_Range, _Range), position.y + Random.Range(-_Range, _Range)));

//            //if (instance != null)
//            //{
//                instance.GetComponent<Floating_Text>().SetColor(RGB);
//                instance.GetComponent<Floating_Text>().Text = text;

//                instance.transform.SetParent(this.transform, false);
//                instance.transform.position = screenPos;
//            //}
//        //}       
//	}
    
//    public Image GetImage(GameObject parentGameObject, string nameOfImage)
//    {
//        List<Image> images = parentGameObject.GetComponentsInChildren<Image>().ToList();
//        return images.Find(i => i.name == "Health");
//    }
//    public GameObject GetUI()
//    {
//        return _UI;
//    }
//}
