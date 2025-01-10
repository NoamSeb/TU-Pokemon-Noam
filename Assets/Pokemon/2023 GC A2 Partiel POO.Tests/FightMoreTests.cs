using System;
using _2023_GC_A2_Partiel_POO.Level_2;
using NUnit.Framework;

namespace _2023_GC_A2_Partiel_POO.Tests.Level_2
{
    public class FightMoreTests
    {
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer des features et les TU sur le reste du projet
        
        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
            // - un heal ne régénère pas plus que les HP Max
            // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
            // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type
        // - L'utilisation d'objets : Potion, SuperPotion, Vitess+, Attack+ etc.
        // - Gérer les PP (limite du nombre d'utilisation) d'une attaque,
            // si on selectionne une attack qui a 0 PP on inflige 0
        
        // Choisis ce que tu veux ajouter comme feature et fait en au max.
        // Les nouveaux TU doivent être dans ce fichier.
        // Modifiant des features il est possible que certaines valeurs
            // des TU précédentes ne matchent plus, tu as le droit de réadapter les valeurs
            // de ces anciens TU pour ta nouvelle situation.

            [Test]
            public void CheckIfSpellIsNull()
            {
                Character pikachu = new Character(100, 50, 30, 20, TYPE.NORMAL);
                Character bulbizarre = new Character(90, 60, 10, 200, TYPE.NORMAL);
                Fight f = new Fight(pikachu, bulbizarre);
                Punch p = new Punch();
                
                Assert.Throws<ArgumentNullException>(() =>
                {
                    // Equip character
                    f.ExecuteTurn(p,null);
                });
            }

            [Test]
            public void WaterAttackOnTypeFire()
            {
                Character Dracofeu = new Character(100, 50, 30, 10, TYPE.FIRE);
                Character Tiplouf = new Character(70, 30, 15, 30, TYPE.WATER);
                
                Fight f = new Fight(Dracofeu, Tiplouf);
                FireBall fb = new FireBall();
                WaterBlouBlou wbb = new WaterBlouBlou();
                
                f.ExecuteTurn(fb,wbb);
                Assert.That(Dracofeu.CurrentHealth,Is.EqualTo(94));
                Assert.That(Dracofeu.IsAlive,Is.True);
            }

            [Test]

            public void FireAttackOnWaterType()
            {
                Character Dracofeu = new Character(100, 50, 30, 40, TYPE.FIRE);
                Character Tiplouf = new Character(100, 20, 15, 30, TYPE.WATER);
                
                Fight f = new Fight(Dracofeu, Tiplouf);
                FireBall fb = new FireBall();
                WaterBlouBlou wbb = new WaterBlouBlou();
                
                f.ExecuteTurn(fb,wbb);
                Assert.That(Tiplouf.CurrentHealth,Is.EqualTo(90));
                Assert.That(Tiplouf.IsAlive,Is.True);
            }
    }
}
