using imprimante;
using System.Collections.Generic;
using System.Reflection.Metadata;


List<string> listEmploye = new List<string>();

listEmploye.Add("Safae");
listEmploye.Add("Samar");
listEmploye.Add("Sara");


List<DemandeImpression> Demande = new List<DemandeImpression>();


Console.WriteLine("Veuillez entrer votre nom");
string nomEmploye  = Console.ReadLine();

if (!listEmploye.Contains(nomEmploye))
{
    Console.WriteLine("Le nom n'est pas dans la liste.Vérifier votre entrée ! la première lettre en MAJ!");
}



else
    Console.WriteLine($"Bonjour {nomEmploye} ! Bienvenue dans le système de gestion des demandes d'impression.");



// Boucle principale
while (true)
{
    // Menu
    Console.WriteLine("\nQue voulez-vous faire ?");
    Console.WriteLine("1. Ajouter une demande d'impression");
    Console.WriteLine("2. Voir les demandes en cours");
    Console.WriteLine("3. Marquer une demande comme imprimée");
    Console.WriteLine("4. Quitter");

    // Lire l'entrée de l'utilisateur
    Console.Write("Votre choix : ");
    string choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            AjouterDemande();
            break;

        case "2":
            VoirDemandes();
            break;

        case "3":
            MarquerImpression();
            break;

        case "4":
            Console.WriteLine("Au revoir !");
            return;

        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
}



void AjouterDemande()
{
    // Demander les informations de la demande
    Console.Write("Nom du client : ");
    string nomClient = Console.ReadLine();
    Console.Write("Nom du document : ");
    string document = Console.ReadLine();
    Console.Write("Nombre de copies : ");
    int nombreCopies = int.Parse(Console.ReadLine());

    // Ajouter la demande à la liste
    Demande.Add(new DemandeImpression
    {
        NomClient = nomClient,
        Document = document,
        NombreCopies = nombreCopies,
        Imprimee = false
    });

    Console.WriteLine("Demande ajoutée.");
}


void VoirDemandes()
{
    if (Demande.Count == 0)
    {
        Console.WriteLine("Il n'y a aucune demande en cours.");
        return;
    }

    Console.WriteLine("Demandes en cours :");

    // Afficher toutes les demandes en cours
    for (int i = 0; i < Demande.Count; i++)
    {
        DemandeImpression demande = Demande[i];
        Console.WriteLine($"{i + 1}. {demande.NomClient} - {demande.Document} - {demande.NombreCopies} copies - {(demande.Imprimee ? "imprimée" : "non imprimée")}");
    }


}


void MarquerImpression()
{
    // Demander le numéro de la demande à marquer comme imprimée
    Console.Write("Numéro de la demande à marquer comme imprimée : ");
    int numeroDemande = int.Parse(Console.ReadLine()) - 1;

    // Vérifier si le numéro est valide
    if (numeroDemande < 0 || numeroDemande >= Demande.Count)
    {
        Console.WriteLine("Numéro de demande invalide.");
        return;
    }

    // Marquer la demande comme imprimée
    Demande[numeroDemande].Imprimee = true;

    Console.WriteLine("Demande marquée comme imprimée.");
}