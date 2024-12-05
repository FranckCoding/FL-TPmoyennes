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

		public Eleve()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}