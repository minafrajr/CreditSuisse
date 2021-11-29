namespace CreditSuisse.Interfaces
{
    public interface IConfigServices
    {
        /// <summary>
        ///Return the valou of a configuration from App.Config through a key and convert to a type T
        /// </summary>
        /// <typeparam name="T">The type to convert</typeparam>
        /// <param name="key">The value from the App.Config </param>
        /// <returns></returns>
        T GetConfiguration<T>(string key);
    }
}
