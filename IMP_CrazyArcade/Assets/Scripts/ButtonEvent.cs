/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private Sprite _normal = null;
    [SerializeField] private Sprite _hover = null;
    [SerializeField] private Sprite _pressed = null;
    [SerializeField] private GameObject[] _butText = null;
    public bool butPressed = false;

    private bool gripChk = false;
    private GameObject collidingObject;
    private GameObject objectInHand;
    private GameObject objectChild;
    private float scaleX, scaleY, scaleZ;
    //private bool pressed = false;
    void Start()
    {
        scaleX = this.transform.localScale.x;
        scaleY = this.transform.localScale.y;
        scaleZ = this.transform.localScale.z;
    }
    private void Update()
    {
        //tirgger 버튼을 놓을 때
        if (grabAction.GetLastStateUp(handType))
        {
            if (gripChk)
                RelaseObject();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //SetCollidingObject(other);
        if (!butPressed)
        {
            this.GetComponent<Image>().sprite = _hover;
            this.transform.localScale = new Vector3(scaleX + (scaleX * 0.01f),
                                                    scaleY + (scaleY * 0.01f),
                                                    scaleZ + (scaleZ * 0.01f));

            if (grabAction.GetLastStateDown(handType))
            {
                GrabObject();
                if (other != null)
                {
                    // Debug.Log("other is not null");
                    gripChk = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!butPressed)
        {
            this.GetComponent<Image>().sprite = _normal;
            this.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
    }
    private void GrabObject()
    {
        for (int i = 0; i < _butText.Length; i++)
        {
            _butText[i].GetComponent<Text>().color = new Color(0.9150f, 0.9150f, 0.9150f, 1.0f);
        }
        this.GetComponent<Image>().sprite = _pressed;
        this.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);

        butPressed = true;
        if (this.GetComponent<Button>().interactable)
            this.GetComponent<Button>().onClick.Invoke();
    }
    //충돌 중인 개체로 체크
    private void SetCollidingObject(Collider col)
    {
        //이미 충돌 중이거나 rigidbody를 가지고 있지 않은 경우 예외처리
        if (collidingObject || !col.GetComponent<Rigidbody>())
            return;
        collidingObject = col.gameObject;
    }
    //joint 추가
    private FixedJoint AddFixedJoint()
    {
        FixedJoint joint = gameObject.AddComponent<FixedJoint>();
        joint.breakForce = 20000;
        joint.breakTorque = 20000;
        return joint;
    }
}*/