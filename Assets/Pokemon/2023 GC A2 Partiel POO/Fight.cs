using System;
using UnityEngine;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    public class Fight
    {
        public Fight(Character character1, Character character2)
        {
            Character1 = character1;
            Character2 = character2;
            if (character1 == null || character2 == null)
                throw new ArgumentNullException("Characters are null.");
        }

        public Character Character1 { get; }
        public Character Character2 { get; }

        /// <summary>
        /// Est-ce la condition de victoire/défaite a été rencontré ?
        /// </summary>
        public bool IsFightFinished = false;

        /// <summary>
        /// Jouer l'enchainement des attaques. Attention à bien gérer l'ordre des attaques par apport à la speed des personnages
        /// </summary>
        /// <param name="skillFromCharacter1">L'attaque selectionné par le joueur 1</param>
        /// <param name="skillFromCharacter2">L'attaque selectionné par le joueur 2</param>
        /// <exception cref="ArgumentNullException">si une des deux attaques est null</exception>
        public void ExecuteTurn(Skill skillFromCharacter1, Skill skillFromCharacter2)
        {
            if (skillFromCharacter1 == null || skillFromCharacter2 == null)
                throw new ArgumentNullException("Skills are null.");

            float multiplier;
            if (Character1.Speed > Character2.Speed)
            {
                multiplier = TypeResolver.GetFactor(Character1.BaseType, Character2.BaseType);
                Character2.ReceiveAttack(skillFromCharacter1, multiplier);
                if (!Character2.IsAlive)
                {
                    IsFightFinished = true;
                    return;
                }

                multiplier = TypeResolver.GetFactor(Character2.BaseType, Character1.BaseType);
                Character1.ReceiveAttack(skillFromCharacter2, multiplier);
                if (!Character1.IsAlive)
                {
                    IsFightFinished = true;
                }
            }
            else
            {
                multiplier = TypeResolver.GetFactor(Character2.BaseType, Character1.BaseType);
                Character1.ReceiveAttack(skillFromCharacter2, multiplier);
                if (!Character1.IsAlive)
                {
                    if (Character2.CurrentHealth >= 0)
                        Character2.IsAlive = true;

                    IsFightFinished = true;
                    return;
                }

                multiplier = TypeResolver.GetFactor(Character1.BaseType, Character2.BaseType);
                Character2.ReceiveAttack(skillFromCharacter1, multiplier);
                if (!Character2.IsAlive)
                {
                    IsFightFinished = true;
                }
            }
        }
    }
}