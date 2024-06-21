using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectInteraction : MonoBehaviour, IPointerExitHandler, IPointerClickHandler,IPointerEnterHandler
{
    public Texture2D hoverCursor; 
    public Texture2D defaultCursor;
    public FirstSceneScript firstSceneScript; 
    public ThirdScreenScript thirdScreenScript;
    Transform parent;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(firstSceneScript)
            firstSceneScript.OnPointerClick(gameObject);
        UnityEngine.Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
    {
        UnityEngine.Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UnityEngine.Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    void Start()
    {
        parent = gameObject.transform.parent;
        // Debug.Log(gameObject.name);
        firstSceneScript = parent.GetComponent<FirstSceneScript>();

    }
}
