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
		public String nom {  get; set; }

		/// <summary>
		/// Liste des élèves dans la classe
		/// </summary>
        public List<Eleve> listEleve { get; set; }

        /// <summary>
        /// Liste des matières enseignées dans la classe avec les 
        /// moyennes associées
        /// </summary>
        public Dictionary<string, int> listMatiere { get; set; }

        /// <summary>
        /// Moyenne générale de la classe
        /// </summary>
        public int moyenneGeneral { get; set; }

		/// <summary>
		/// Constructeur du modèle Classe
		/// </summary>
		/// <param name="nom">Nom de la classe à attribuer</param>
        public Classe(String nom)
		{
            this.nom = nom;
		}
    }
}
