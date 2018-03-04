namespace Creational.Singleton
{
    public class Logger
    {
        private static Logger uniqueInstance;

        private Logger() { }

        public static Logger Instance {
        
            get{

                if (uniqueInstance == null) {
                    uniqueInstance = new Logger();
                } 

                return uniqueInstance;
            }
        }
          
            
    }
}
