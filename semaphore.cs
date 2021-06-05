using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Forks
{
   public class semaphore
    {
            //Déclaration du SemaphoreSlim qui prendra en paramètre le nombre de places disponibles.
            static SemaphoreSlim doorman = new SemaphoreSlim(3);
            public semaphore() { }

           public void semaph()
            {
                Console.Title = "Exemple de SemaphoreSlim";

                //Création des threads.
                for (int i = 0; i < 10; i++)
                    new Thread(Entrer).Start(i);
                Console.ReadKey();
            }

            static void Entrer(object n)
            {
                Console.WriteLine("La personne #{0} veut entrer", n);

                //Le doorman attendra qu'il y ait de la place.
                doorman.Wait();
                Console.WriteLine("#{0} vient d'entrer dans le bar", n);
                Thread.Sleep((int)n * 1000);
                Console.WriteLine("#{0} a quitté le building !", n);

                //Le doorman peut maintenant faire entrer quelqu'un d'autre.
                doorman.Release();
            }
            public void rt() { }
        }
    }