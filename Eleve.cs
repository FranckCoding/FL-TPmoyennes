using System;

namespace HNI_TPmoyennes
{
	/// <summary>
	/// Décrit les informations d'un élève présent dans une classe
	/// </summary>
	public class Eleve
	{
		/// <summary>
		/// Prénom de l'élève
		/// </summary>
		public String prenom {  get; set; }
		/// <summary>
		/// Nom de famille de l'élève
		/// </summary>
		public String nom { get; set; }
		/// <summary>
		/// Liste des notes de l'élèves
		/// </summary>
		internal List<Note> notes { get; set; }
        /// <summary>
        /// Liste des matières enseignées dans la classe avec les 
        /// moyennes associées
        /// </summary>
        public List<String> matieres { get; set; }

        /// <summary>
        /// Constructeur du modèle Eleve
        /// </summary>
        /// <param name="prenom">Prenom du nouvel élève</param>
        /// <param name="nom">Nom de famille du nouvel élève</param>
        public Eleve(String prenom, String nom)
		{
			if (prenom == null || prenom == "" || nom == null || nom == "")
				throw new ArgumentNullException("Les variables prénom et/ou nom de l'élève sont soit null, soit une chaîne vide.");

			this.prenom = prenom;
			this.nom = nom;
			this.notes = new List<Note>();
			this.matieres = null;
		}

		/// <summary>
		/// Ajout d'une nouvelle note à la liste des notes de l'élève
		/// </summary>
		/// <param name="note">La nouvelle note à ajouter</param>
		internal void ajouterNote(Note note)
		{
			try
			{
				if (note == null)
					throw new Exception("La note est une entité nulle");

				this.notes.Add(note);
			}
			catch (Exception e)
			{
                Console.WriteLine($"Echec de l'ajout de la note: {e.Message}");
            }
		}

		/// <summary>
		/// Calcule la moyenne d'un élève pour une matière donnée
		/// </summary>
		/// <param name="indexMatiere">Index de la matière dont souhaite avoir la moyenne</param>
		/// <returns>Moyenne de l'élève sur une matière donnée</returns>
		public float moyenneMatiere(int indexMatiere)
		{
			float moyenne = 0, compte = 0;

			foreach (Note note in this.notes)
			{
				if (indexMatiere == note.matiere) 
				{
                    moyenne += note.note;
					compte++;
                }
            }

			if (compte > 0)
			{
				moyenne /= compte;
			}

            return MathF.Truncate(moyenne * 100) / 100;
		}

		/// <summary>
		/// Calcule la moyenne générale de l'élève
		/// </summary>
		/// <returns>La moyenne générale de l'élève</returns>
		public float moyenneGeneral()
		{
			float moyenne = 0;
			int nombreMatiere = this.matieres.Count;

            for (int i = 0; i < nombreMatiere; i++)
	        {
		        moyenne += this.moyenneMatiere(i);
			}

			moyenne /= nombreMatiere;


            return MathF.Truncate(moyenne * 100) / 100;
        }
    }
}