using System;

namespace HNI_TPmoyennes
{
	/// <summary>
	/// Description du modèle d'une Classe
	/// contenant un nom, la liste des élèves, des matières et la moyenne générale de la classe
	/// </summary>
	public class Classe
	{
		/// <summary>
		/// Nom de la classe
		/// </summary>
		public String nomClasse {  get; set; }

		/// <summary>
		/// Liste des élèves dans la classe
		/// </summary>
        public List<Eleve> eleves { get; set; }

        /// <summary>
        /// Liste des matières enseignées dans la classe avec les 
        /// moyennes associées
        /// </summary>
        public List<String> matieres { get; set; }

		/// <summary>
		/// Constructeur du modèle Classe
		/// </summary>
		/// <param name="nom">Nom de la classe à attribuer</param>
        public Classe(String nom)
		{
            this.nomClasse = nom;
			this.eleves = null;
			this.matieres = null;
			this.moyenneMatiere = null;
            this.moyenneGeneral = 0;
		}

		/// <summary>
		/// Methode de classe pour ajouter un élève à la liste des élèves
		/// d'une classe
		/// </summary>
		/// <param name="prenom">Prénom du nouvel élève</param>
		/// <param name="nom">Nom de famille du nouvel élève</param>
		public void ajouterEleve(String prenom, String nom) 
		{
			if (!this.eleves)
			{
				this.eleves = new List<Eleve> ();
			}

			if (this.eleves.Count < 30)
			{
				this.eleves.Add(new Eleve(prenom, nom));
			}
		}

		/// <summary>
		/// Methode de classe pour ajouter une matière à la liste
		/// des matières enseignées dans une classe
		/// </summary>
		/// <param name="nom">Nom de la matière</param>
		public void ajouterMatiere(String nom)
		{
			if (!this.matieres)
			{
				this.matieres = new List<String>();
			}

			if (this.matieres.Count < 10)
			{
				this.matieres.Add(nom);
			}
		}

		/// <summary>
		/// Calcule la moyenne pour une matière enseignée dans cette classe
		/// </summary>
		/// <param name="indexMatiere">Index de la matiere dans la liste</param>
		/// <returns>La moyenne de la classe dans la matière enseignée</returns>
		public int moyenneMatiere(int indexMatiere)
		{
			int somme = 0, tailleListe = this.eleves.Count;

			try
			{
				for (int i = 0; i < tailleListe; i++)
				{
					somme += this.eleves[i].moyenneMatiere(indexMatiere);
				}

                return somme / tailleListe;
            }
			catch (Exception e) when (e is DivideByZeroException)
			{
				Console.WriteLine($"Echec du calcule de la matière {this.matieres[indexMatiere]}: {e.Message}");
			}
			
		}
    }
}
