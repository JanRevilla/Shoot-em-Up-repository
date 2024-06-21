using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float HorizontalMovement;
    public int Health = 3;

    public HUD HUD;

    public KeyCode jumpKey;
    public KeyCode downKey;
    public string floorPlatform = "Plataforma1";

    [Header("Salto")]

    [SerializeField] private LayerMask whatIsFloor;
    [SerializeField] private Transform floorController;
    [SerializeField] private Vector3 boxDimensions;
    [SerializeField] private bool isFloor;
    [SerializeField] private ParticleSystem jumpParticles;
    [SerializeField] private AudioClip jumpSound;
    private HealthComponent healthComponent;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        healthComponent = GetComponent<HealthComponent>();

        healthComponent.OnHitReceived += Hit;
        healthComponent.OnLifeDepleted += PlayerDie;
    }

    private void Update()
    {
        // Movimiento
        HorizontalMovement = Input.GetAxisRaw("Horizontal");

        if (HorizontalMovement < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (HorizontalMovement > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", HorizontalMovement != 0.0f);

        // Detectar Suelo
        // Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);        

        // Salto
        if (Input.GetKeyDown(jumpKey) && !IsOnPlatformWithTag(floorPlatform))
        {
            Jump();
            jumpParticles.Play();
            ControlSound.Instance.ExecuteSound(jumpSound);
        }
        if (Input.GetKeyDown(downKey))
        {
            DesactivarPlataformas();

        }

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(HorizontalMovement * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        // Verificar si el personaje está en la capa de suelo
        Collider2D groundCollider = Physics2D.OverlapBox(floorController.position, boxDimensions, 0f, whatIsFloor);
        if (groundCollider != null)
        {
            // Aplicar fuerza de salto solo si está en la capa de suelo
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
        }
    }

    private bool IsOnPlatformWithTag(string tag)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(floorController.position, 0.2f, whatIsFloor);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(floorController.position, boxDimensions);
    }

    private void DesactivarPlataformas()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(floorController.position, boxDimensions, 0f, whatIsFloor);
        foreach (Collider2D item in objetos)
        {
            PlatformEffector2D platformEffector2D = item.GetComponent<PlatformEffector2D>();
            if (platformEffector2D != null)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), item.GetComponent<Collider2D>(), true);
            }
        }
    }

    private void Hit()
    {

        Animator.SetTrigger("hurt");

        //if (Health > 0)
        //{
        //    int heartIndex = Health;
        //    HUD.DisableHeart(heartIndex);
        //}

    }

    private void PlayerDie()
    {
        PointSystem.points = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        GameStateManager.Instance.ChangeState(GameState.MainMenu);


        healthComponent.OnHitReceived -= Hit;
        healthComponent.OnLifeDepleted -= PlayerDie;

        Destroy(gameObject);
    }
}