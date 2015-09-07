﻿using UnityEngine;
using System.Collections;

//inheritance
public class Boss : Attacker {
		public float shield;

		/*//if i dont do this Start() in the base class will run by itself 
		public override void Start(){
			base.Start ();
		}*/

		public override void Update(){
			base.Update ();

			//if our attacker is targeting something isAttacking = true
			isAttacking = (currentTarget != null);
			if(!isAttacking) anim.ResetTrigger ("Attacking");
		}
	
	public override void OnTriggerEnter2D(Collider2D collider){
		print ("sub");
		Defender defender = collider.gameObject.GetComponent<Defender> ();
		//must check if colliding with a defender first before tag or get null reference exception
		if (defender) {
			if(defender.tag == "DefenderWall"){
			print ("boss attacking wall");
			}
		}

		Projectiles projectile = collider.gameObject.GetComponent<Projectiles> ();
		
		if (projectile) {
			if(shield > 0){
				print ("shielded");
				shield -= projectile.getDamage();
			} else {
				health -= projectile.getDamage();
			}
		}

		//equivalent of "super" in java
		base.OnTriggerEnter2D (collider);


		
	}

}
