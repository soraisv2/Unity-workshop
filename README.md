# Unity-workshop

1/ Environnement

Vous devez créer :
- Terrain
- Player
  - Physics
  - Rigidbody
  - Camera
- Cible


2/ Movement

Creer un script C# et mettez le sur votre objet "Player"
Commencez par mettre les variable minimum pour le deplacement :

```c#
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    private float movementMultiplier = 1f;
    private float airMultiplier = 1f;

    [Header("Movement")]
    public float speed = 5f;
    public Transform groundPosition;
    public LayerMask groundMask;
    [SerializeField] Transform orientation;

    Vector3 direction;
    bool isGrounded;
    float horizontal;
    float vertical;
}
```

Attribuer un composant de votre object a votre script :

```c#
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
```

Deplacez la physic `FixedUpdate()` de preference.

```c#
private void FixedUpdate()
{
    // 
}
```
