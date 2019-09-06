using UnityEngine;
using UnityEditor;

public class CircularOrbitBullet : Bullet {
    Vector3 center;
    float angle;
    float speed;
    float radius;

    // Use this for initialization
    void Start() {

    }

    public void SetCenter(Vector3 center) {
        this.center = center;
    }

    public void SetAngle(float angle) {
        this.angle = angle;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public void SetRadius(float radius) {
        this.radius = radius;
    }

    // Update is called once per frame
    void Update() {
        if (GameState.isGamePaused) {
            GetComponent<Animator>().enabled = false;
            return;
        }

        GetComponent<Animator>().enabled = true;

        angle += speed * Time.deltaTime;

        gameObject.transform.position = center + (new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * radius);

        gameObject.transform.rotation = Quaternion.AngleAxis(angle + Mathf.Sign(speed) * 90, Vector3.forward);
    }
}