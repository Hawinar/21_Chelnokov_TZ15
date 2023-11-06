using UnityEngine;

public class ItemController : MonoBehaviour
{
    private GameObject _hook;
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] public int _speed;

    [SerializeField] public int _price;
    void Start()
    {
        if (_rb2d.gameObject.tag == "Bag")
            _price = Random.Range(40, 150);
    }

    // Update is called once per frame
    void Update()
    {
        if (_hook != null)
            _rb2d.MovePosition(new Vector2(_hook.transform.position.x, _hook.transform.position.y - 1.5f));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _hook = collision.gameObject;
        _rb2d.isKinematic = false;
    }
    private void OnDestroy()
    {
        GameManager.Money += _price;
    }
}
