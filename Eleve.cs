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
		public List<Note> notes { get; set; }

		/// <summary>
		/// Constructeur du modèle Eleve
		/// </summary>
		/// <param name="prenom">Prenom du nouvel élève</param>
		/// <param name="nom">Nom de famille du nouvel élève</param>
		public Eleve(String prenom, String nom)
		{
			if (prenom == null || prenom == "" || nom == null || nom = "")
				throw new ArgumentNullException("Les variables prénom et/ou nom de l'élève sont soit null, soit une chaîne vide.");

			this.prenom = prenom;
			this.nom = nom;
			this.notes = new List<Note>();
		}
	}
}