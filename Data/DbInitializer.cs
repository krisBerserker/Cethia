using redestro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace redestro.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CethiaContext context)
        {
            // Look for any students.
            if (context.Stagiaire.Any())
            {
                return;   // DB has been seeded
            }

            var Kris = new Stagiaire
            {
                Nom = "Kris",
                Prenom = "Berserker",
                DateInscription = DateTime.Parse("2022-07-28")
            };

            var Djoums = new Stagiaire
            {
                Nom = "Djoums",
                Prenom = "BTC",
                DateInscription = DateTime.Parse("2022-07-31")
            };

            var Georges = new Stagiaire
            {
                Nom = "Georges",
                Prenom = "DevOps",
                DateInscription = DateTime.Parse("2016-09-01")
            };

            var Esmeralda = new Stagiaire
            {
                Nom = "Esmeralde",
                Prenom = "Jones",
                DateInscription = DateTime.Parse("2016-09-01")
            };

            var Docteur = new Instructeur
            {
                Nom = "Docteur",
                Prenom = "Abercrombie",
                DateEmbauche = DateTime.Parse("1995-03-11")
            };

            var Said = new Instructeur
            {
                Nom = "Said",
                Prenom = "bachar",
                DateEmbauche = DateTime.Parse("1995-03-11")
            };


           var John = new Instructeur
            {
                Nom = "John",
                Prenom = "doe",
                DateEmbauche = DateTime.Parse("1995-03-11")
            };


            var Flamingo = new Instructeur
            {
                Nom = "Flamingo",
                Prenom = "Donquixote",
                DateEmbauche = DateTime.Parse("1995-03-11")
            };


           


            var Constellation = new Marche
            {
                Libelle = "Application de gestion de stock",
                Budget = 700000,
                DateDebut = DateTime.Parse("2007-09-01"),
                Instructeur = Docteur
            };

            var Constellation2 = new Marche
            {
                Libelle = "Application de gestion de personnel",
                Budget = 350000,
                DateDebut = DateTime.Parse("2007-09-01"),
                Instructeur = Docteur
            };

            var Fokou = new Marche
            {
                Libelle = "Application mobile de notification",
                Budget = 350000,
                DateDebut = DateTime.Parse("2020-09-01"),
                Instructeur = Said
            };

            var Quieferou = new Marche
            {
                Libelle = "Site publicitaire",
                Budget = 200000,
                DateDebut = DateTime.Parse("2007-09-01"),
                Instructeur = Docteur
            };

            var Tache0 = new Tache
            {
                TacheID = 230,
                Libelle = "Conception",
                Priorite = 3,
                Marche = Fokou,
                Instructeurs = new List<Instructeur> { John, Said }
            };
     
           var Tache1 = new Tache
            {
                TacheID = 002,
                Libelle = "Modelisation",
                Priorite = 1,
                Marche = Constellation,
                Instructeurs = new List<Instructeur> { John, Said }
            };
var Tache2 = new Tache
            {
                TacheID = 111,
                Libelle = "API controlle",
                Priorite = 5,
                Marche = Fokou,
                Instructeurs = new List<Instructeur> { Docteur, Said }
            };
            var Tache3 = new Tache
            {
                TacheID = 1050,
                Libelle = "Integration",
                Priorite = 2,
                Marche = Fokou,
                Instructeurs = new List<Instructeur> { John, Flamingo }
            };
            var Tache4 = new Tache
            {
                TacheID = 321,
                Libelle = "Test unitaire",
                Priorite = 4,
                Marche = Fokou,
                Instructeurs = new List<Instructeur> { Said, Flamingo }
            };

            var Inscription = new Inscription[]
            {
                new Inscription {
                    Stagiaire = Kris,
                    Tache = Tache0,
                },
                     new Inscription {
                    Stagiaire = Djoums,
                    Tache = Tache1,
                },
                  
                     new Inscription {
                    Stagiaire = Kris,
                    Tache = Tache2,
                },
                  
                     new Inscription {
                    Stagiaire = Georges,
                    Tache = Tache3,
                },
                  
                    new Inscription {
                    Stagiaire = Djoums,
                    Tache = Tache3,
                },
                  
                     new Inscription {
                    Stagiaire = Kris,
                    Tache = Tache4,
                },
                  
                   
            };

            context.AddRange(Inscription);
            context.SaveChanges();
        }
    }
}