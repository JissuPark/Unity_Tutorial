using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 360.0f;
    float maxSpeed = 2.0f;
    float walkForce = 30.0f;
    Vector2 savepose = new Vector2(6.51f,1.56f);
    // Use this for initialization
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();//rigidbody componenet 받아오기
        this.animator = GetComponent<Animator>();//animator component 받아오기
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {//space키가 눌리면
            this.rigid2D.AddForce(transform.up * this.jumpForce);//+y축으로 이동하도록 한다.
        }

        int key = 0;//초기화
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;//<-
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;//->
        float speed = Mathf.Abs(this.rigid2D.velocity.x);//속도

        if (speed < this.maxSpeed)//최대 속도 미만이면
            this.rigid2D.AddForce(transform.right * key * this.walkForce);//이동
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        this.animator.speed = speed / 2.0f;//애니메이션 속도 조정

        if (transform.position.y < -5)
        {//떨어지면 다시 시작
            transform.position = savepose;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)//충돌 이벤트 관리
    {
		if(collision.gameObject.tag == "trap"){//trap과 충돌했을 때
			Rigidbody2D collrigid = collision.gameObject.GetComponent<Rigidbody2D>();//trap의 rigidbody를 가져온다
			collrigid.bodyType = RigidbodyType2D.Dynamic;//rigidbody를 dynamic으로 변경한다.
			Debug.Log("trap");
		}
        if (collision.gameObject.tag == "savepoint")//savepoint와 충돌했을 때
        {
			Debug.Log("savepoint");
            savepose = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y+0.5f);//savepoint의 위치를 저장
        }
    }
    void OnTriggerEnter2D(Collider2D other)//trigger충돌 이벤트 관리
    {
        if (other.tag == "end")//trigger collider를 만나면
            SceneManager.LoadScene("Scene");//씬 변화
    }
}
