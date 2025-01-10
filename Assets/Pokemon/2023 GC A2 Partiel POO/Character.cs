using System;
using UnityEditor.UI;
using UnityEngine;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;

        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;

        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;

        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;

        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
        }

        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth
        {
            get => _baseHealth;
            private set { _baseHealth = value; }
        }

        public TYPE BaseType
        {
            get => _baseType;
        }

        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                int maxHealth;
                if (CurrentEquipment != null)
                {
                    maxHealth = _baseHealth + CurrentEquipment.BonusHealth;
                }
                else
                {
                    maxHealth = _baseHealth;
                }

                return maxHealth;
            }
        }

        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                int baseAttack;
                if (CurrentEquipment != null)
                {
                    baseAttack = _baseAttack + CurrentEquipment.BonusAttack;
                }
                else
                {
                    baseAttack = _baseAttack;
                }

                return baseAttack;
            }
        }

        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                int baseDefense;
                if (CurrentEquipment != null)
                {
                    baseDefense = _baseDefense + CurrentEquipment.BonusDefense;
                }
                else
                {
                    baseDefense = _baseDefense;
                }

                return baseDefense;
            }
        }

        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                int baseSpeed;
                if (CurrentEquipment != null)
                {
                    baseSpeed = _baseSpeed + CurrentEquipment.BonusSpeed;
                }
                else
                {
                    baseSpeed = _baseSpeed;
                }

                return baseSpeed;
            }
        }

        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        private Equipment _equipment;

        public Equipment CurrentEquipment
        {
            get => _equipment;
            private set { _equipment = value; }
        }

        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        private bool isAlive;

        public bool IsAlive
        {
            get => isAlive;
            set => isAlive = value;
        }


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s, float multiplier = 1.0f)
        {
            Debug.Log(multiplier);
            int damage;
            switch (s)
            {
                case Punch:
                    damage = s.Power - Defense;
                    CurrentHealth -= damage;
                    CheckIfAlive(ref _baseHealth);
                    break;
                case MegaPunch:
                    damage = s.Power - Defense;
                    CurrentHealth -= damage;
                    CheckIfAlive(ref _baseHealth);
                    break;
                case FireBall:
                    damage = (int)(s.Power * multiplier) - Defense;
                    CurrentHealth -= damage;
                    CheckIfAlive(ref _baseHealth);
                    break;
                case WaterBlouBlou:
                    damage = (int)(s.Power * multiplier) - Defense;
                    CurrentHealth -= damage;
                    CheckIfAlive(ref _baseHealth);
                    break;
                case MagicalGrass:
                    damage = (int)(s.Power*multiplier) - Defense;
                    CurrentHealth -= damage;
                    CheckIfAlive(ref _baseHealth);
                    break;
            }
        }

        /// <summary>
        /// Check if a character is still alive after receiving an attack
        /// </summary>
        /// <param name="lifePoints"></param>
        public void CheckIfAlive(ref int lifePoints)
        {
            if (lifePoints <= 0)
            {
                lifePoints = 0;
                isAlive = false;
            }
            else
            {
                isAlive = true;
            }
        }

        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment == null)
                throw new ArgumentNullException("newEquipment is null");

            CurrentEquipment = newEquipment;
        }

        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            CurrentEquipment = null;
        }
    }
}