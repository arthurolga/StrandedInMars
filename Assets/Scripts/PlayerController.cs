using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed=0.1f;
    public float gravityModifier=1f;
    public float jumpPower = 10f;
    public CharacterController charCon;
    public int jumpQuantity = 2;
    public int health = 100;
    public Text LifeBarText;

    private Vector3 moveInput;
    private int jumpsAvaliable;
    
    public GameObject Shotgun;
    public GameObject ShotgunBullet;
    public float ShotgunDelay;
    public GameObject Minigun;
    public GameObject MinigunBullet;
    public float MinigunDelay;


    public float mouseSensitivity;
    public bool invertX;
    public bool invertY;

    public string activeWeapon="shotgun";
    public bool gotMinigun=false;

    public Transform camTrans;
    private float activeWeaponFireDelay;

    
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        jumpsAvaliable = jumpQuantity;
        activeWeaponFireDelay = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //moveInput.x = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        //moveInput.z = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;

        

        // if(Input.GetKeyDown(KeyCode.E)){
        //     Cursor.visible = false;
        // }
        float yStore = moveInput.y;

        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");

        moveInput = horiMove + vertMove;
        moveInput.Normalize();
        moveInput = moveInput * moveSpeed;

        moveInput.y = yStore;

        // Gravity
        moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

        if(charCon.isGrounded){
            jumpsAvaliable = jumpQuantity;
            moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        // Jump
        if(Input.GetKeyDown(KeyCode.Space) && (jumpsAvaliable > 0)){
            moveInput.y = jumpPower;
            jumpsAvaliable -= 1;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            activeWeapon="shotgun";
            Shotgun.SetActive(true);
            Minigun.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && gotMinigun){
            activeWeapon="minigun";
            Minigun.SetActive(true);
            Shotgun.SetActive(false);
        }

        charCon.Move(moveInput * Time.deltaTime);

        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"))*mouseSensitivity;

        if(invertX){
            mouseInput.x = -mouseInput.x;
        }
        if(invertY){
            mouseInput.y = -mouseInput.y;
        }



        // Camera Controlls
        //Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y + mouseInput.x,transform.rotation.eulerAngles.z);

        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y,0f,0f));
    
        // SHooting
        if(Input.GetMouseButton(0) && activeWeaponFireDelay <= 0)
        {
            if(activeWeapon=="shotgun"){
                SFXManagerScript.PlaySound("shotgunSound");
                Instantiate(ShotgunBullet,firePoint.position,firePoint.rotation);
                activeWeaponFireDelay = ShotgunDelay;
            }
            else if(activeWeapon=="minigun" ){
                SFXManagerScript.PlaySound("MinigunSound");
                Instantiate(MinigunBullet,firePoint.position,firePoint.rotation);
                activeWeaponFireDelay = MinigunDelay;
            }
            
        }
        activeWeaponFireDelay -= Time.deltaTime;
    }
    public void TakeDamage(int dmg){
        health -= dmg;
        LifeBarText.text = string.Format("HEALTH: {0}%", health);
        if(health <= 0){
            Die();
        }
    }

    private void Die(){
        SceneManager.LoadScene("LoseGame");
        Destroy(gameObject);
    }

    public void ActivateMinigun(){
        gotMinigun=true;
        activeWeapon="minigun";
        Minigun.SetActive(true);
        Shotgun.SetActive(false);
    }

   
}
