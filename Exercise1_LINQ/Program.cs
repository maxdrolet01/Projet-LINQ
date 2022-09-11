using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Exercise1_LINQ
{
    internal class Program
    {
        #region Declaration des listes global
        static List<string> lstName = new List<string>()
            {
                "Fremosss",
                 "Schizen",
                 "Zeradon",
                 "Droodinette",
                 "Samuel",
                 "Maxime",
                 "Mick",
                 "JM",
                 "Sepatricia",
                 "Pat"
            };
        static List<Monstre> lstMonstre = new List<Monstre>();
        #endregion 

        static void Main(string[] args)
        {
            GenererMonstre();
            Affichage();
            Console.ReadKey();
        }
        static void GenererMonstre()
        {

            Random random = new Random();
            DateTime today = DateTime.Now;

            // Creation des monstres
            for (int i = 0; i < 50; i++)
            {
                Monstre monster = new Monstre();
                DateTime tomorrow = today.AddDays(random.Next(0, 3000));
                DateTime past = today.AddDays(random.Next(-3000, -200));

                monster.mutationDate = i < 17
                        ? monster.mutationDate = tomorrow
                        : monster.mutationDate = past;

                monster.name = lstName[random.Next(0, 9)];
                monster.nbrArms = random.Next(0, 7);
                monster.nbrLegs = random.Next(0, 7);
                monster.nbrHeads = random.Next(0, 4);

                lstMonstre.Add(monster);
            }
        }

        static void Affichage()
        {
            // Affichage des monstres
            Console.WriteLine("Voici la liste des monstre : ");
            lstMonstre.ForEach(mstr => Console.WriteLine(mstr));           
            NextSegment();

            // Affichage des monstres sans tete
            Console.WriteLine("Voici la liste des monstres sans tete : ");
            lstMonstre.Where(x => x.nbrHeads == 0).ToList().ForEach(x => Console.WriteLine(x.name + " n'a pas de tete !"));
            NextSegment();

            // Affichage de la somme de tous les bras des monstres
            Console.WriteLine("Voici la somme de tous les bras des monstres : ");
            Console.WriteLine(lstMonstre.ToList().Sum(x => x.nbrArms));
            NextSegment();

            // Affiche et supprime le monstre le plus vieux
            Monstre oldestMonster = lstMonstre.OrderBy(x => x.mutationDate).First();
            Console.WriteLine($"Voici le monstre le plus vieux : \n  {oldestMonster}  \n Ce monstre sera supprimer si vous appuyez sur une touche");
            lstMonstre.Remove(oldestMonster);
            NextSegment();

            // Affiche et supprime les monstres laids (Nombre de tete et jambes qui sont pair)
            List<Monstre> uglyMonster = lstMonstre.Where(x => x.nbrHeads % 2 == 0 && x.nbrArms % 2 == 0).ToList();
            foreach (Monstre monstre in uglyMonster)
            {
                Console.WriteLine($"Ce monstre : {monstre} est trop laid, il sera supprimer."); 
                lstMonstre.Remove(monstre);
            }               
            NextSegment();

            // Affiche et recalcule les monstres qui n'ont pas de bras et de jambes
            Console.WriteLine("Voici la liste des monstre qui n'ont pas de bras et de jambes : ");
            List<Monstre> noLegNoArms = lstMonstre.Where(mstr => mstr.nbrArms == 0 && mstr.nbrLegs == 0).ToList();
            for (int i = 0; i < noLegNoArms.Count; i++)
            {
                Console.WriteLine(noLegNoArms[i]);
            }
            NextSegment();

            Random random = new Random();
            foreach (Monstre m in noLegNoArms)
            {
                int index = lstMonstre.IndexOf(m);
                lstMonstre[index].nbrLegs = random.Next(0, 7);
                lstMonstre[index].nbrArms = random.Next(0, 7);
                Console.WriteLine($"Ce monstre a maintenant : {lstMonstre[index]}");
            }
            NextSegment();
        }
        static void NextSegment()
        {
            Console.WriteLine("Appyez sur une touche pour continuer..."); Console.ReadKey();
            Console.Clear();
        }
    }
}