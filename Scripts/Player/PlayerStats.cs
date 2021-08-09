using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{

    public class PlayerStats : CharacterStats
    {
        public HealthBar healthBar;
        public StaminaBar staminaBar;

        AnimationHandler animationHandler;

        private void Awake()
        {
            healthBar = FindObjectOfType<HealthBar>();
            staminaBar = FindObjectOfType<StaminaBar>();
            animationHandler = GetComponentInChildren<AnimationHandler>();
        }

        void Start()
        {
            maxHealth = SetMAxHealthFromHealthLevel();
            currentHealth = maxHealth;

            healthBar.SetMaxHealth(maxHealth);

            maxStamina = SetMaxStaminaFromStaminaLevel();
            currentStamina = maxStamina;

            staminaBar.SetCurrentStamina(maxStamina);

        }

        private int SetMAxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        private int SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = StaminaLevel * 10;
            return maxStamina;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;
            healthBar.SetCurrentHealth(currentHealth);

            animationHandler.PlayTargetAnimation("Damage_01", true);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animationHandler.PlayTargetAnimation("Dead_01", true);
                //HANDLE PLAYER DEATH
            }
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina = currentStamina - damage;
            staminaBar.SetCurrentStamina(currentStamina);
        } 
 
    }
}
