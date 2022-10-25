using Newtonsoft.Json;

namespace FurnitureShop.Extentions
{
    public static class SessionExtention
    {
        public static void SetCart(this ISession session, object value)
        {
            session.SetString("Cart", JsonConvert.SerializeObject(value));
        }

        public static T GetCart<T>(this ISession session)
        {
            var sessionData = session.GetString("Cart");
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
