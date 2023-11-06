using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HookController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Animator anim;

    private float _speed;


    WaitForSeconds _sleepTime = new WaitForSeconds(0.5f);

    [SerializeField] private Button _shotBtn;
    [SerializeField] private Vector3 userDirection;
    void Start()
    {
        _speed = 0f;
        _shotBtn.onClick.AddListener(() => Shot());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(userDirection * _speed * Time.deltaTime);
        if (_rigidbody2D.position.y > 2.35f)
        {
            Return();
        }
        Debug.Log(_speed);

    }
    private void Shot()
    {
        _speed = _movementSpeed;
        anim.speed = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _speed *= -1;
        if (collision.gameObject.tag != "Border")
        {
            StartCoroutine(Catch(collision));
        }

    }
    private void Return()
    {
        _speed = 0f;
        anim.speed = 1f;

        _rigidbody2D.MovePosition(new Vector2(0, 2.35f));
    }
    IEnumerator Catch(Collision2D collision)
    {
        _speed = collision.gameObject.GetComponent<ItemController>()._speed;
        yield return _sleepTime;
        Destroy(collision.gameObject);
    }
}
