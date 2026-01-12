

using Unity.VisualScripting;
using UnityEngine;

namespace my3dtest
{


    public class my3DController : MonoBehaviour
    {

        public static my3DController _inst;
        void Awake()
        {
            _inst = this;
        }



        [Header("Movement")]
        public float moveSpeed = 5f;
        public float gravity = -9.81f;

        [Header("Mouse Look")]
        public float mouseSensitivity = 100f;
        Transform cameraTransform;

        float xRotation = 0f;
        Vector3 velocity;
        //CharacterController controller;
        Rigidbody rb;

        void Start()
        {
            cameraTransform = Camera.main.transform;
            //controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;



            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            HandleMouseLook();
            //HandleMovement();
            lookUpdate();
            pressUpdate();
        }
        void FixedUpdate()
        {
            HandleMovement();
        }

        void HandleMouseLook()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        void HandleMovement()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            move.y = -2;//! LACKING

            // if (controller.isGrounded && velocity.y < 0) //+ velocity
            //     velocity.y = -2f;

            //velocity.y += gravity * Time.deltaTime;

            //controller.Move((move * moveSpeed + velocity) * Time.deltaTime);
            //controller.Move((move * moveSpeed + velocity) * Time.deltaTime);
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }



        [Space(15)]
        public float distance = 3f;
        public LayerMask interactableMask;
        public bool debugRays;
        public Transform lookTransformOrigin;
        public bool useRayStartOffset;
        public Vector3 rayStartOffset;

        [Space(10)]
        [SerializeField] string _pointingAtName;
        [SerializeReference] my3DInteractableBase highlightedItem;//my3DPressMe
        void lookUpdate()
        {
            Vector3 origin = lookTransformOrigin.position;
            if (useRayStartOffset)
            {
                Vector3 offsetAdd = lookTransformOrigin.forward;

                offsetAdd.x *= rayStartOffset.x;
                offsetAdd.y *= rayStartOffset.y;
                offsetAdd.z *= rayStartOffset.z;

                origin += offsetAdd;

            }
            Ray ray = new Ray(origin, lookTransformOrigin.forward);
            RaycastHit hit;
            bool targetFound = Physics.Raycast(ray, out hit, distance, interactableMask);

            if (highlightedItem != null)
            {
                highlightedItem.lookAway();
                highlightedItem = null;
            }

            if (targetFound)
            {
                if (debugRays)
                {
                    Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green);
                }

                _pointingAtName = hit.collider.gameObject.name;

                if (hit.collider.TryGetComponent<my3DInteractableBase>(out var interactable))
                {
                    interactable.lookAt();
                    highlightedItem = interactable;
                }


                //hit.collider.gameObject.name;

                //Debug.Log("Looking at: " + hit.collider.name);
            }
            else
            {
                if (debugRays) Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
            }


        }




        void pressUpdate()
        {

            if (highlightedItem == null) return;


            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) highlightedItem.press();
            else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) highlightedItem.hold();

            //Debug.LogError(highlightedItem.name);
            //.pressMe();


        }


    }


}