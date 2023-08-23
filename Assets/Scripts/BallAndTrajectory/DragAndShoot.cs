using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseRealisePos;
    
    private bool isShoot;
    private bool _flag;
    
    private Rigidbody _rigidbody;
    public Rigidbody rigidbody;
    
    [SerializeField] float forceMultiplier = 3f;
    
    public bool canShoot = false;
    public GameObject joystick;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void OnMouseDown()
    {
        if(_flag==false) 
            ZoomInWeapon.instance.ZoomIn();
            mousePressDownPos = Input.mousePosition;
        _flag = true;
    }
    public void OnMouseDrag()
    {
        Debug.Log(333);
        Vector3 forceInIt = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = new Vector3(forceInIt.x, forceInIt.y, forceInIt.y) * forceMultiplier;
        forceV = new Vector3(forceV.x, Mathf.Clamp(forceV.y, 0, 333), forceV.z);
        
        if (!isShoot)
        {
            DrawTrajectory.Instance.UpdateTrajectory(forceV, _rigidbody, transform.position);
        }
    }
    public void OnMouseUp()
    {
        DrawTrajectory.Instance.HideLine();
        mouseRealisePos = Input.mousePosition;
        Shoot(mouseRealisePos - mousePressDownPos);
        joystick.SetActive(false);
        _flag = false;
        isShoot = false;
        ZoomInWeapon.instance.ZoomOut();
    }
    private void Shoot(Vector3 force)
    {
        rigidbody.isKinematic = false;
        if (!canShoot) return;

        if (isShoot)
        {
            return;
        }
        _rigidbody.AddForce(new Vector3(force.x * 1.4f, force.y, force.y * 2.8f) * forceMultiplier);
        transform.LookAt(transform.position + new Vector3(force.x * 1.4f, force.y, force.y * 2.8f) * forceMultiplier);
        isShoot = true;
        Spawner.Instance.NewSpownRequest();
    }
}