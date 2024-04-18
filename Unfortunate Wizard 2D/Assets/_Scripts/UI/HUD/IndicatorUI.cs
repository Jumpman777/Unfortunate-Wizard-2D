using System;
using UnityEngine;
using UnityUtils;

public class IndicatorUI : MonoBehaviour
{
    [SerializeField, Tooltip("Empty game object that will be used as the indicator")] 
    private Transform indicatorTransform;
    private BaseSummonObject currentObject;
    
    private Color normalOpaqueColor = new Color(1, 1, 1, 0.5f);
    private Color redOpaqueColor = new Color(1, 0.5f, 0.5f, 0.5f);

    private Camera _mainCamera;


    private void OnEnable()
    {
        EventManager.onCardSelected.Subscribe(EnableIndicator);
        EventManager.onCardDeselected.Subscribe(DisableIndicator);
        EventManager.onIndicatorObjectChangeTriggerCollision.Subscribe(SetIndicatorCollision);
        EventManager.onIndicatorRotate.Subscribe(ChangeIndicatorRotation);
        EventManager.onSpawnObject.Subscribe(ReceiveObjectSpawned);
        
        DisableIndicator();
        _mainCamera = Camera.main;
    }

    private void OnDisable()
    {
        EventManager.onCardSelected.Unsubscribe(EnableIndicator);
        EventManager.onCardDeselected.Unsubscribe(DisableIndicator);
        EventManager.onIndicatorObjectChangeTriggerCollision.Unsubscribe(SetIndicatorCollision);
        EventManager.onIndicatorRotate.Unsubscribe(ChangeIndicatorRotation);
        EventManager.onSpawnObject.Unsubscribe(ReceiveObjectSpawned);
    }
    
    private void EnableIndicator(CardInfo cardInfo)
    {
        //enabled = true;
        indicatorTransform.gameObject.SetActive(true);
        Debug.Log("Indicator enabled");
    }
    private void DisableIndicator()
    {
        //enabled = false;
        if (currentObject != null)
        {
            Destroy(currentObject.gameObject);
        }
        indicatorTransform.gameObject.SetActive(false);
        Debug.Log("Indicator disabled");
    }

    private void ReceiveObjectSpawned(CardInfo cardInfo)
    {
        DisableIndicator();
    }

    public void SetIndicatorObject(BaseSummonObject prefab)
    {
        currentObject = Instantiate(prefab, GetMousePosition().With(z: 0), RotationHelper.RotationToQuaternion(), indicatorTransform);
        currentObject.SetToIndicatorMode();
        currentObject.SetColor(normalOpaqueColor);
    }
    private Vector3 GetMousePosition()
    {
        return _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    
    private void Update()
    {
        indicatorTransform.position = GetMousePosition().With(z: 0);
    }

    private void SetIndicatorCollision(bool isTriggerColliding)
    {
        currentObject.SetColor(isTriggerColliding ? redOpaqueColor : normalOpaqueColor);
    }
    
    private void ChangeIndicatorRotation()
    {
        indicatorTransform.rotation = RotationHelper.RotationToQuaternion();
    }
    
    
}