using System;

namespace _006_Reflection
{
    class MyDisposableClass : IDisposable
    {
        /// <summary>
        /// Chiamato dal client che vuole liberare le risorse "a mano".
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine("Chiamata al Dispose()!!!");

            // Ha come compito principale quello di pulire le risorse
            // unmanaged, ma può pulire anche quelle managed (cioè sotto il diretto controllo del CLR).
            Dispose(true);

            // Avendo già liberato tutte le risorse non serve richiamare il finalizer,
            // quindi avviso il GC di saltarlo e distruggere direttamente l'oggetto.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposeAll)
        {
            if(disposeAll)
            {
                Console.WriteLine("Dispose managed resources...");
                // Managed
                // ... release managed resources
            }

            Console.WriteLine("Dispose unmanaged resources...");
            // Unmanaged
            // ... release resources, as DB connection
        }

        /// <summary>
        /// Distruttore, o Finalizzatore.
        /// Chiamato dal GC. Il GC libera automaticamente le risorse managed, mentre per quelle unmanaged
        /// è necessario fornire il distruttore. 
        /// Il GC dopo aver invocato il distruttore, distrugge l'oggetto.
        /// </summary>
        ~MyDisposableClass()
        {
            Console.WriteLine("Chiamata al Finalizzatore!!!");
            Dispose(false);
        }


        public void UseSomeResorces()
        {
            Console.WriteLine("UseSomeResorces...");
        }
        
    }
}
