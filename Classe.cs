using System;
using System.Linq;

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
			try
			{
				if (nom == "")
					throw new Exception("Le nom donné à la classe est invalide.");
				this.nomClasse = nom;
				this.eleves = new List<Eleve>();
                this.matieres = new List<String>();
            }
			catch (Exception e)
			{
				Console.WriteLine($"Echec de la création de la classe: {e.Message}");
			}
		}

        /// <summary>
        /// Constructeur du modèle Classe
        /// </summary>
        /// <param name="nom">Nom de la classe à attribuer</param>
		/// <param name="eleves">Liste des élèves de cette classe</param>
        public Classe(String nom, List<Eleve> eleves)
        {
            try
            {
                if (nom == "")
                    throw new Exception("Le nom donné à la classe est invalide.");
                this.nomClasse = nom;
                this.eleves = eleves;
                this.matieres = new List<String>();

				foreach (Eleve eleve in eleves)
				{
					eleve.matieres = this.matieres;
				}
            }
            catch (Exception e)
            {
                Console.WriteLine($"Echec de la création de la classe: {e.Message}");
            }
        }

        /// <summary>
        /// Constructeur du modèle Classe
        /// </summary>
        /// <param name="nom">Nom de la classe à attribuer</param>
        public Classe(String nom, List<Eleve> eleves, List<String> matieres)
        {
            try
            {
                if (nom == "")
                    throw new Exception("Le nom donné à la classe est invalide.");
                this.nomClasse = nom;
                this.eleves = eleves;
                this.matieres = matieres;

                foreach (Eleve eleve in eleves)
                {
                    eleve.matieres = this.matieres;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Echec de la création de la classe: {e.Message}");
            }
        }

        /// <summary>
        /// Methode de classe pour ajouter un élève à la liste des élèves
        /// d'une classe
        /// </summary>
        /// <param name="prenom">Prénom du nouvel élève</param>
        /// <param name="nom">Nom de famille du nouvel élève</param>
        public void ajouterEleve(String prenom, String nom) 
		{
			try
			{
				if (this.eleves.Count < 30)
				{
					this.eleves.Add(new Eleve(prenom, nom));
					this.eleves.Last().matieres = this.matieres;
				}
                else
                {
                    throw new ArgumentOutOfRangeException("Le nombre maximale d'élèves dans cette classe a déjà été atteinte.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Echec de l'ajout de l'élève: {e.Message}");
            }
        }

		/// <summary>
		/// Methode de classe pour ajouter une matière à la liste
		/// des matières enseignées dans une classe
		/// </summary>
		/// <param name="nom">Nom de la matière</param>
		public void ajouterMatiere(String nom)
		{
			try
			{
				if (this.matieres.Count < 10)
				{
					this.matieres.Add(nom);
				}
				else
				{
					throw new ArgumentOutOfRangeException(nameof(nom), "Le nombre maximale de matière a déjà été atteinte.");
				}
			}
			catch (Exception e) when (e is ArgumentOutOfRangeException || e is ArgumentNullException)
			{
				Console.WriteLine($"Echec de l'ajout de la matière: {e.Message}");
			}
		}

		/// <summary>
		/// Calcule la moyenne pour une matière enseignée dans cette classe
		/// </summary>
		/// <param name="indexMatiere">Index de la matiere dans la liste</param>
		/// <returns>La moyenne de la classe dans la matière enseignée</returns>
		public float moyenneMatiere(int indexMatiere)
		{
			float moyenne = 0, tailleListe = this.eleves.Count;

			try
			{
				for (int i = 0; i < tailleListe; i++)
				{
					moyenne += this.eleves[i].moyenneMatiere(indexMatiere);
				}

                moyenne /= tailleListe;
            }
			catch (Exception e) when (e is DivideByZeroException)
			{
				Console.WriteLine($"Echec du calcule de la matière {this.matieres[indexMatiere]}: {e.Message}");
			}

			return MathF.Truncate(moyenne * 100) / 100;
		}

		/// <summary>
		/// Calcule la moyenne générale de la classe
		/// </summary>
		/// <returns>La moyenne générale de la classe</returns>
		public float moyenneGeneral()
		{
            float moyenne = 0, tailleListe = this.matieres.Count;

            try
            {
                for (int i = 0; i < tailleListe; i++)
                {
                    moyenne += this.moyenneMatiere(i);
                }

                moyenne /= tailleListe;
            }
            catch (Exception e) when (e is DivideByZeroException)
            {
                Console.WriteLine($"Echec du calcule de la moyenne generale: {e.Message}");
            }

			return MathF.Truncate(moyenne * 100) / 100;
        }
    }
}
