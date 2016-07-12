using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0f, 0.5f, 0f);

	public GameObject bulletPrefab;

	public float fireDelay = 0.25f;
	float cooldownTimer = 0f;
	
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if(cooldownTimer <= 0 ) {
			cooldownTimer = fireDelay;

			Vector3 offset = transform.rotation * bulletOffset;

			if(Bonuses.shootingLevel == 0){
				GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
				bullet.transform.parent = transform.parent;
				bullet.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			}else if(Bonuses.shootingLevel == 1){
				GameObject bullet1 = (GameObject)Instantiate(bulletPrefab, transform.position + offset-new Vector3(0.05f, 0f, 0f), transform.rotation);
				bullet1.transform.parent = transform.parent;
				GameObject bullet2 = (GameObject)Instantiate(bulletPrefab, transform.position + offset+new Vector3(0.05f, 0f, 0f), transform.rotation);
				bullet2.transform.parent = transform.parent;
			}else if(Bonuses.shootingLevel == 2){
				GameObject bullet1 = (GameObject)Instantiate(bulletPrefab, transform.position + offset-new Vector3(0.1f, 0f, 0f), Quaternion.Euler(0, 0, 1));
				bullet1.transform.parent = transform.parent;
				GameObject bullet2 = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
				bullet2.transform.parent = transform.parent;
				GameObject bullet3 = (GameObject)Instantiate(bulletPrefab, transform.position + offset+new Vector3(0.1f, 0f, 0f), Quaternion.Euler(0, 0, -1));
				bullet3.transform.parent = transform.parent;
			}else if(Bonuses.shootingLevel > 2){
				GameObject bullet1 = (GameObject)Instantiate(bulletPrefab, transform.position + offset-new Vector3(0.1f, 0f, 0f), Quaternion.Euler(0, 0, 5));
				bullet1.transform.parent = transform.parent;
				GameObject bullet2 = (GameObject)Instantiate(bulletPrefab, transform.position + offset-new Vector3(0.05f, 0f, 0f), transform.rotation);
				bullet2.transform.parent = transform.parent;
				GameObject bullet3 = (GameObject)Instantiate(bulletPrefab, transform.position + offset+new Vector3(0.05f, 0f, 0f), transform.rotation);
				bullet3.transform.parent = transform.parent;
				GameObject bullet4 = (GameObject)Instantiate(bulletPrefab, transform.position + offset+new Vector3(0.1f, 0f, 0f), Quaternion.Euler(0, 0, -5));
				bullet4.transform.parent = transform.parent;
			}
		}
	}
}
