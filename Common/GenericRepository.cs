using System.Collections.Generic;

namespace Common
{

	/*
     * 
     * Komentari:
     * 
     * 1. Nazovimo bilo koju klasu koju ćemo spremati u bazu - Entity.
     * 
     * 
     * 2. Ako imamo Generičku KLASU IGenericRepository<T> -> to znači da imamo različit tip
     *  za svaki entity koji želimo spremiti u bazu. Na primjer, ako imamo 2 entity-a: Tenant i User
     *  to bi značilo da imamo IGenericRepository<Tenant> i IGenericRepository<User> - dakle 2 različita
     *  repozitorija. Ukoliko bi naš model rastao i imali bi 50 različitih klasa koje spremamo u bazu -
     *  to bi značilo da imamo 50 različitih repozitorija. Istina je da bi sa generičkom klasom spriječili
     *  duplikaciju koda, međutim u memoriji bi morali istovremeno držati 50 različitih repozitorija,
     *  svaki sa svojom konekcijom na bazu što nije potrebno.
     *  
     *  Dakle, u ovom slučaju nam treba repozitorij čija klasa NIJE generička, nego koji ima generičke metode.
     *  Primjeti razliku između generičke klase i generičke metode - to je važno.
     *  
     *  Dakle ako klasa nije generička - onda imamo samo jedan repozitorij u memoriji, sa jednom konekcijom
     *  na bazu, a njene METODE su generičke i to nam omogućava da koristimo naš repozitorij za bilo koji Entity
     *  
     * 3. Molim te pogledaj malo što je KLASA a što INSTANCA KLASE - to su dvije bitne stvari za razlikovati
     * 
     * 4. Za početak, budući da si kreirao Common projekt - dodaj u njega folder Models i kreiraj apstraktnu klasu
     * 
     *   AbstractEntity. Svaki drugi Entity (Tenant, User) treba nasljediti AbstractEntity - pomoću te klase ćemo
     *   na neki način sve naše DB modele staviti pod isti znak
     *   
     * 5. Nasljeđivanje u objektno orjentiranom programiranju je jedan od najvažnijih koncepata i treba ga dobro razumjeti
     * 
     * Ako klasa X nasljeđuje klasu Y među njima se stvara tzv "IS-A relationship", X IS-A Y. To se čita "X je Y".
     * 
     * Dakle u našem slučaju ako User naslijedi AbstractEntity to znači User IS-A AbstractEntity, User JE AbstractEntity.
     * 
     * Primjeti jedan važan detalj: User JE AbstractEntity ali obrat ne vrijedi -> AbstractEntity NIJE USER
     * 
     * Ovaj koncept je jako važan tako da si slobodno uzmi vremena koliko ti treba i pokušaj ga razumjeti, ako što treba
     * pojasniti, proći ćemo skupa opet.
     * 
     * Posljedica ovoga je da svaka metoda koja kao parametar prima AbstractEntity - automatski će raditi ako se za parametar
     * pošalje u User.
     * 
     * 6. Sa svim ovim napisanim, za početak probaj samo definirati IGenericRepository interface, a MongoDB implementaciju
     *   ćemo napraviti kasnije
     *   
     *   Dakle interface bi trebao izgledati ovako:
     *   
     *   public interface IGenericRepository
     *   {
     *      ... generička metoda GetAll koja vraća listu a generički parametar treba imati constraint "where T : AbstractEntity"
     *      
     *          (za sada nemoj ni stavljati implementaciju GetById jer ću ti poslije pokazati kako za to možemo iskoristiti GetAll)
     *      
     *      ... generička metoda DeleteAsync koja prima T (entity koji se briše), isto ima constraint "where T : AbstractEntity"
     *      
     *      ... generička metoda SaveOrUpdateAsync koja prima entity koji se dodaje ili mijenja, isto ima constraint "where T : AbstractEntity"
     *   }
     *   
     *   
     *   Primjer kako se definiraju generičke metode u interface-u
     *   
     *   public class MyFancyClass
     *   {
     *   }
     *   
     *   public interface IMyGenericInterface
     *   {
     *      Task SendToTheMoonAsync<T>(T instanceOfT) where T : MyMyFancyClass;
     *   }
     * 
     */
	public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public virtual async IEnumerable<T> GetAll()
        {
            //dbset
            List<T>results = await dbSet.FindAsync(_ => true);
            return results.ToList();
        }

        public virtual T GetById(object id) 
        {
            var korisnik = dbSet.Find(p => p.Id == id).FirstOrDefault();
            return korisnik;
        }

        void Insert(T obj)
        {
            //dbset

        }
        void Update(T obj)
        {
            //dbset

        }
        void Delete(T obj)
        {
            //dbset

        }
    }



    //public interface IRepository
    //{
    //    Task<List<T>> GetAllAsync<T>() where T AbstractEntity;
    //}


    // Generic constraints in c#
}