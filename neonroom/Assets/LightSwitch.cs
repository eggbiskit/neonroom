using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeLightButton : MonoBehaviour
{
   public List<Light> Lights;
   private VisualElement frame;
   private Button button;

   void OnEnable()
   {
    var uiDocument = GetComponent<UIDocument>();
    var rootVisualElement = uiDocument.rootVisualElement;
    frame = rootVisualElement.Q<VisualElement>("Frame");
    button = frame.Q<Button>("Button");
    button.RegisterCallback<ClickEvent>(ev => ChangeLight());
   }

   int click = 0;
   private void ChangeLight() 
   {
    EnableLight(click);
    print("clicks: "+click);
    click++;
    if(click > 3)
    {
        print("reset");
        click = 0;
    }
   }

   private void EnableLight(int n)
   {
    Lights.ForEach(light => light.enabled = false);
    Lights[n].enabled = true;
   }
}